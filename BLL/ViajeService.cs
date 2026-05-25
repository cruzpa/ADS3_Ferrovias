using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ViajeService
    {
        private readonly List<Viaje> viajes;

        public ViajeService()
        {
            viajes = CrearViajesIniciales();
        }

        public List<ViajeResultadoBusqueda> BuscarViajes(DateTime fechaSalida, Estacion origen, Estacion destino, int cantidadPasajeros, string categoria)
        {
            ValidarBusqueda(origen, destino, cantidadPasajeros, categoria);

            Categoria categoriaSeleccionada = ObtenerCategoria(categoria);

            return viajes
                .Where(viaje => viaje.FechaHoraSalida.Date == fechaSalida.Date)
                .Where(viaje => ContieneTrayecto(viaje, origen, destino))
                .Select(viaje => CrearResultadoBusqueda(viaje, origen, destino, cantidadPasajeros, categoriaSeleccionada))
                .Where(resultado => resultado.LugaresDisponibles >= cantidadPasajeros)
                .ToList();
        }

        public List<Viaje> Listar()
        {
            return viajes;
        }

        public void Crear(Viaje viaje)
        {
            ValidarViaje(viaje);

            if (viajes.Any(v => v.Numero == viaje.Numero))
            {
                throw new Exception("Ya existe un viaje con ese número");
            }

            viajes.Add(viaje);
        }

        private ViajeResultadoBusqueda CrearResultadoBusqueda(Viaje viaje, Estacion origen, Estacion destino, int cantidadPasajeros, Categoria categoria)
        {
            List<Tramo> tramosContratados = ObtenerTramosEntre(viaje, origen, destino);
            int cantidadParadas = ObtenerParadasEntre(viaje, origen, destino).Count;

            return new ViajeResultadoBusqueda
            {
                FechaSalida = viaje.FechaHoraSalida.Date,
                HoraSalida = viaje.FechaHoraSalida.TimeOfDay,
                Origen = origen.Nombre,
                Destino = destino.Nombre,
                DuracionEstimada = CalcularDuracion(tramosContratados, cantidadParadas).ToString(@"hh\:mm"),
                CantidadParadas = cantidadParadas,
                Categoria = categoria.ToString(),
                LugaresDisponibles = ContarButacasDisponibles(viaje, origen, destino, categoria),
                PrecioEstimado = CalcularPrecioEstimado(viaje, tramosContratados, cantidadParadas, categoria) * cantidadPasajeros,
                Viaje = viaje
            };
        }

        private decimal CalcularPrecioEstimado(Viaje viaje, List<Tramo> tramosContratados, int cantidadParadas, Categoria categoria)
        {
            decimal distanciaTotal = tramosContratados.Sum(tramo => tramo.DistanciaKilometros);
            decimal importeBase = distanciaTotal * viaje.ValorBaseKilometro;
            decimal descuentoParadas = importeBase * cantidadParadas * 0.02m;
            decimal importeConDescuento = importeBase - descuentoParadas;

            return importeConDescuento + CalcularRecargoCategoria(importeConDescuento, categoria);
        }

        private decimal CalcularRecargoCategoria(decimal importe, Categoria categoria)
        {
            if (categoria == Categoria.Pullman)
            {
                return importe * 0.05m;
            }

            if (categoria == Categoria.Ejecutivo)
            {
                return importe * 0.10m;
            }

            return 0;
        }

        private TimeSpan CalcularDuracion(List<Tramo> tramosContratados, int cantidadParadas)
        {
            TimeSpan duracionTramos = TimeSpan.Zero;

            foreach (Tramo tramo in tramosContratados)
            {
                duracionTramos = duracionTramos.Add(tramo.TiempoEstimado);
            }

            return duracionTramos.Add(TimeSpan.FromMinutes(cantidadParadas * 15));
        }

        private int ContarButacasDisponibles(Viaje viaje, Estacion origen, Estacion destino, Categoria categoria)
        {
            return viaje.Formacion.Vagones
                .Where(vagon => vagon.Categoria == categoria)
                .SelectMany(vagon => vagon.Butacas.Select(butaca => new { Vagon = vagon, Butaca = butaca }))
                .Count(asiento => EstaButacaDisponible(viaje, asiento.Vagon, asiento.Butaca, origen, destino));
        }

        private bool EstaButacaDisponible(Viaje viaje, Vagon vagon, Butaca butaca, Estacion origen, Estacion destino)
        {
            List<Estacion> estacionesOrdenadas = ObtenerEstacionesOrdenadas(viaje);
            int origenNuevo = BuscarIndiceEstacion(estacionesOrdenadas, origen);
            int destinoNuevo = BuscarIndiceEstacion(estacionesOrdenadas, destino);

            return !viaje.Pasajes.Any(pasaje =>
                !pasaje.Cancelado &&
                pasaje.Vagon.Numero == vagon.Numero &&
                pasaje.Butaca.Numero == butaca.Numero &&
                HaySuperposicion(pasaje, origenNuevo, destinoNuevo, estacionesOrdenadas)
            );
        }

        private bool HaySuperposicion(Pasaje pasaje, int origenNuevo, int destinoNuevo, List<Estacion> estacionesOrdenadas)
        {
            int origenExistente = BuscarIndiceEstacion(estacionesOrdenadas, pasaje.Origen);
            int destinoExistente = BuscarIndiceEstacion(estacionesOrdenadas, pasaje.Destino);

            return origenNuevo < destinoExistente && destinoNuevo > origenExistente;
        }

        private bool ContieneTrayecto(Viaje viaje, Estacion origen, Estacion destino)
        {
            List<Estacion> estacionesComerciales = ObtenerEstacionesComerciales(viaje);
            int indiceOrigen = BuscarIndiceEstacion(estacionesComerciales, origen);
            int indiceDestino = BuscarIndiceEstacion(estacionesComerciales, destino);

            return indiceOrigen >= 0 && indiceDestino >= 0 && indiceOrigen < indiceDestino;
        }

        private List<Estacion> ObtenerEstacionesComerciales(Viaje viaje)
        {
            List<Estacion> estaciones = new List<Estacion>();

            AgregarEstacionSiNoExiste(estaciones, viaje.Recorrido.Origen);

            foreach (Estacion parada in viaje.Recorrido.Paradas)
            {
                AgregarEstacionSiNoExiste(estaciones, parada);
            }

            AgregarEstacionSiNoExiste(estaciones, viaje.Recorrido.Destino);

            return OrdenarEstacionesSegunRecorrido(viaje, estaciones);
        }

        private List<Estacion> OrdenarEstacionesSegunRecorrido(Viaje viaje, List<Estacion> estaciones)
        {
            List<Estacion> estacionesOrdenadas = ObtenerEstacionesOrdenadas(viaje);

            return estaciones
                .OrderBy(estacion => BuscarIndiceEstacion(estacionesOrdenadas, estacion))
                .ToList();
        }

        private List<Tramo> ObtenerTramosEntre(Viaje viaje, Estacion origen, Estacion destino)
        {
            List<Tramo> tramos = viaje.Recorrido.Tramos;
            int indiceOrigen = tramos.FindIndex(tramo => EsMismaEstacion(tramo.Origen, origen));
            int indiceDestino = tramos.FindIndex(tramo => EsMismaEstacion(tramo.Destino, destino));

            if (indiceOrigen == -1 || indiceDestino == -1 || indiceOrigen > indiceDestino)
            {
                throw new Exception("El origen y destino deben pertenecer al recorrido del viaje");
            }

            return tramos.Skip(indiceOrigen).Take(indiceDestino - indiceOrigen + 1).ToList();
        }

        private List<Estacion> ObtenerParadasEntre(Viaje viaje, Estacion origen, Estacion destino)
        {
            List<Estacion> estacionesOrdenadas = ObtenerEstacionesOrdenadas(viaje);
            int indiceOrigen = BuscarIndiceEstacion(estacionesOrdenadas, origen);
            int indiceDestino = BuscarIndiceEstacion(estacionesOrdenadas, destino);

            return viaje.Recorrido.Paradas
                .Where(parada =>
                {
                    int indiceParada = BuscarIndiceEstacion(estacionesOrdenadas, parada);
                    return indiceParada > indiceOrigen && indiceParada < indiceDestino;
                })
                .ToList();
        }

        private List<Estacion> ObtenerEstacionesOrdenadas(Viaje viaje)
        {
            List<Estacion> estaciones = new List<Estacion>();

            foreach (Tramo tramo in viaje.Recorrido.Tramos)
            {
                AgregarEstacionSiNoExiste(estaciones, tramo.Origen);
                AgregarEstacionSiNoExiste(estaciones, tramo.Destino);
            }

            return estaciones;
        }

        private void AgregarEstacionSiNoExiste(List<Estacion> estaciones, Estacion estacion)
        {
            if (estacion != null && !estaciones.Any(e => EsMismaEstacion(e, estacion)))
            {
                estaciones.Add(estacion);
            }
        }

        private int BuscarIndiceEstacion(List<Estacion> estaciones, Estacion estacion)
        {
            return estaciones.FindIndex(e => EsMismaEstacion(e, estacion));
        }

        private Categoria ObtenerCategoria(string categoria)
        {
            Categoria categoriaSeleccionada;

            if (!Enum.TryParse(categoria, out categoriaSeleccionada))
            {
                throw new Exception("La categoría seleccionada no es válida");
            }

            return categoriaSeleccionada;
        }

        private void ValidarBusqueda(Estacion origen, Estacion destino, int cantidadPasajeros, string categoria)
        {
            if (origen == null)
            {
                throw new Exception("Debe indicar una estación de origen");
            }

            if (destino == null)
            {
                throw new Exception("Debe indicar una estación de destino");
            }

            if (EsMismaEstacion(origen, destino))
            {
                throw new Exception("El origen y el destino no pueden ser iguales");
            }

            if (cantidadPasajeros <= 0)
            {
                throw new Exception("La cantidad de pasajeros debe ser mayor a cero");
            }

            if (string.IsNullOrWhiteSpace(categoria))
            {
                throw new Exception("Debe indicar una categoría");
            }
        }

        private void ValidarViaje(Viaje viaje)
        {
            if (viaje == null)
            {
                throw new Exception("El viaje no puede ser nulo");
            }

            if (viaje.Recorrido == null || viaje.Recorrido.Tramos == null || !viaje.Recorrido.Tramos.Any())
            {
                throw new Exception("El viaje debe tener un recorrido con tramos");
            }

            if (viaje.Formacion == null || viaje.Formacion.Vagones == null || !viaje.Formacion.Vagones.Any())
            {
                throw new Exception("El viaje debe tener una formación con vagones");
            }
        }

        private bool EsMismaEstacion(Estacion unaEstacion, Estacion otraEstacion)
        {
            if (unaEstacion == null || otraEstacion == null)
            {
                return false;
            }

            return unaEstacion.Nombre == otraEstacion.Nombre &&
                   unaEstacion.Localidad == otraEstacion.Localidad &&
                   unaEstacion.Provincia == otraEstacion.Provincia;
        }

        private List<Viaje> CrearViajesIniciales()
        {
            List<Recorrido> recorridos = RecorridoService.Listar();

            List<Viaje> viajesIniciales = new List<Viaje>();

            int numeroViaje = 1;
            DateTime fecha = DateTime.Today;

            TimeSpan[] horarios = new TimeSpan[]
            {
        TimeSpan.FromHours(8),
        TimeSpan.FromHours(14)
            };

            foreach (Recorrido recorrido in recorridos)
            {
                foreach (TimeSpan horario in horarios)
                {
                    viajesIniciales.Add(new Viaje
                    {
                        Numero = numeroViaje,
                        Recorrido = recorrido,
                        Formacion = new Formacion("F" + numeroViaje.ToString("000")),
                        Maquinista = new Maquinista
                        {
                            Dni = (10000000 + numeroViaje).ToString(),
                            Nombre = "Maquinista",
                            Apellido = numeroViaje.ToString()
                        },
                        FechaHoraSalida = fecha.Add(horario),
                        DuracionEstimada = CalcularDuracion(recorrido.Tramos, recorrido.Paradas.Count),
                        ValorBaseKilometro = 2
                    });

                    numeroViaje++;
                }
            }

            return viajesIniciales;
        }
    }
}
