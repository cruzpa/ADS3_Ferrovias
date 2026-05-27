using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PasajeService
    {
        private static readonly Dictionary<int, List<Pasaje>> pasajesPorViaje = new Dictionary<int, List<Pasaje>>();

        static PasajeService()
        {
            CargarPasajesIniciales();
        }

        public void Crear(Pasaje pasaje)
        {
            ValidarPasaje(pasaje);
            ValidarRecorridoContratado(pasaje);
            ValidarButacaDisponible(pasaje);

            ObtenerPasajesDeViaje(pasaje.Viaje).Add(pasaje);
        }

        public void Borrar(Pasaje pasaje)
        {
            ValidarPasaje(pasaje);

            List<Pasaje> pasajes = ObtenerPasajesDeViaje(pasaje.Viaje);

            if (!pasajes.Contains(pasaje))
            {
                throw new Exception("El pasaje no pertenece al viaje indicado");
            }

            pasajes.Remove(pasaje);
        }

        public void Cancelar(Pasaje pasaje)
        {
            ValidarPasaje(pasaje);

            if (pasaje.Cancelado)
            {
                throw new Exception("El pasaje ya se encuentra cancelado");
            }

            if (DateTime.Now > pasaje.Viaje.FechaHoraSalida.AddHours(-48))
            {
                throw new Exception("El pasaje solo puede cancelarse con 48 horas de antelación");
            }

            pasaje.Cancelado = true;
        }

        public List<Pasaje> Listar()
        {
            return pasajesPorViaje.Values
                .SelectMany(pasajes => pasajes)
                .ToList();
        }

        public List<Pasaje> ListarPorCliente(string identificadorCliente)
        {
            if (string.IsNullOrWhiteSpace(identificadorCliente))
            {
                return new List<Pasaje>();
            }

            return Listar()
                .Where(pasaje => PerteneceAlCliente(pasaje, identificadorCliente))
                .ToList();
        }

        public List<Pasaje> ObtenerPasajesDeViaje(Viaje viaje)
        {
            if (viaje == null)
            {
                throw new Exception("El viaje no puede ser nulo");
            }

            if (!pasajesPorViaje.ContainsKey(viaje.Numero))
            {
                pasajesPorViaje[viaje.Numero] = new List<Pasaje>();
            }

            return pasajesPorViaje[viaje.Numero];
        }


        private void ValidarButacaDisponible(Pasaje nuevoPasaje)
        {
            List<Estacion> estacionesOrdenadas = ObtenerEstacionesOrdenadas(nuevoPasaje.Viaje);

            bool butacaOcupada = ObtenerPasajesDeViaje(nuevoPasaje.Viaje).Any(pasajeExistente =>
                !pasajeExistente.Cancelado &&
                pasajeExistente.Vagon.Numero == nuevoPasaje.Vagon.Numero &&
                pasajeExistente.Butaca.Numero == nuevoPasaje.Butaca.Numero &&
                HaySuperposicion(pasajeExistente, nuevoPasaje, estacionesOrdenadas)
            );

            if (butacaOcupada)
            {
                throw new Exception("La butaca ya está ocupada para ese tramo");
            }
        }

        private bool PerteneceAlCliente(Pasaje pasaje, string identificadorCliente)
        {
            if (pasaje == null || pasaje.Pasajero == null)
            {
                return false;
            }

            return Coincide(pasaje.ClienteUsername, identificadorCliente) ||
                   Coincide(pasaje.Pasajero.Dni, identificadorCliente) ||
                   Coincide(pasaje.Pasajero.Nombre, identificadorCliente) ||
                   Coincide(pasaje.Pasajero.Apellido, identificadorCliente);
        }

        private bool Coincide(string valor, string identificadorCliente)
        {
            return !string.IsNullOrWhiteSpace(valor) &&
                   valor.Equals(identificadorCliente, StringComparison.OrdinalIgnoreCase);
        }

        private static void CargarPasajesIniciales()
        {
            if (pasajesPorViaje.Any())
            {
                return;
            }

            Recorrido recorrido = RecorridoService.Listar().First();
            Viaje viaje = new Viaje
            {
                Numero = 1,
                Recorrido = recorrido,
                Formacion = new Formacion("F001"),
                FechaHoraSalida = DateTime.Today.AddHours(8),
                DuracionEstimada = TimeSpan.FromMinutes(25 * 8 + recorrido.Paradas.Count * 15),
                ValorBaseKilometro = 2
            };

            Vagon vagon = viaje.Formacion.Vagones.First(v => v.Numero == 3);

            pasajesPorViaje[viaje.Numero] = new List<Pasaje>
            {
                CrearPasajeInicial(viaje, vagon, 1, 1, "pablo", "Pasajero", "Inicial 1"),
                CrearPasajeInicial(viaje, vagon, 2, 2, "pablo", "Pasajero", "Inicial 2")
            };
        }

        private static Pasaje CrearPasajeInicial(Viaje viaje, Vagon vagon, int numeroPasaje, int numeroButaca, string clienteUsername, string nombre, string apellido)
        {
            return new Pasaje
            {
                Numero = numeroPasaje,
                ClienteUsername = clienteUsername,
                Viaje = viaje,
                Pasajero = new Pasajero
                {
                    Dni = clienteUsername,
                    Nombre = nombre,
                    Apellido = apellido,
                    FechaNacimiento = new DateTime(1990, 1, 1)
                },
                Origen = viaje.Recorrido.Origen,
                Destino = viaje.Recorrido.Destino,
                Vagon = vagon,
                Butaca = vagon.Butacas.First(b => b.Numero == numeroButaca),
                CostoTotal = 230,
                DescuentoAplicado = 0,
                FechaEmision = DateTime.Today,
                Cancelado = false
            };
        }

        private bool HaySuperposicion(Pasaje pasajeExistente, Pasaje nuevoPasaje, List<Estacion> estacionesOrdenadas)
        {
            int origenExistente = BuscarIndiceEstacion(estacionesOrdenadas, pasajeExistente.Origen);
            int destinoExistente = BuscarIndiceEstacion(estacionesOrdenadas, pasajeExistente.Destino);
            int origenNuevo = BuscarIndiceEstacion(estacionesOrdenadas, nuevoPasaje.Origen);
            int destinoNuevo = BuscarIndiceEstacion(estacionesOrdenadas, nuevoPasaje.Destino);

            return origenNuevo < destinoExistente && destinoNuevo > origenExistente;
        }

        private void ValidarRecorridoContratado(Pasaje pasaje)
        {
            List<Estacion> estacionesOrdenadas = ObtenerEstacionesOrdenadas(pasaje.Viaje);

            int origen = BuscarIndiceEstacion(estacionesOrdenadas, pasaje.Origen);
            int destino = BuscarIndiceEstacion(estacionesOrdenadas, pasaje.Destino);

            if (origen == -1)
            {
                throw new Exception("El origen del pasaje no pertenece al recorrido del viaje");
            }

            if (destino == -1)
            {
                throw new Exception("El destino del pasaje no pertenece al recorrido del viaje");
            }

            if (origen >= destino)
            {
                throw new Exception("El origen debe estar antes que el destino en el recorrido");
            }
        }

        private List<Estacion> ObtenerEstacionesOrdenadas(Viaje viaje)
        {
            if (viaje.Recorrido == null)
            {
                throw new Exception("El viaje debe tener un recorrido");
            }

            List<Estacion> estaciones = new List<Estacion>();

            foreach (Tramo tramo in viaje.Recorrido.Tramos)
            {
                AgregarEstacionSiNoExiste(estaciones, tramo.Origen);
                AgregarEstacionSiNoExiste(estaciones, tramo.Destino);
            }

            if (!estaciones.Any())
            {
                AgregarEstacionSiNoExiste(estaciones, viaje.Recorrido.Origen);

                foreach (Estacion parada in viaje.Recorrido.Paradas)
                {
                    AgregarEstacionSiNoExiste(estaciones, parada);
                }

                AgregarEstacionSiNoExiste(estaciones, viaje.Recorrido.Destino);
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

        private void ValidarPasaje(Pasaje pasaje)
        {
            if (pasaje == null)
            {
                throw new Exception("El pasaje no puede ser nulo");
            }

            if (pasaje.Viaje == null)
            {
                throw new Exception("El pasaje debe tener un viaje");
            }

            if (pasaje.Pasajero == null)
            {
                throw new Exception("El pasaje debe tener un pasajero");
            }

            if (pasaje.Origen == null)
            {
                throw new Exception("El pasaje debe tener una estación de origen");
            }

            if (pasaje.Destino == null)
            {
                throw new Exception("El pasaje debe tener una estación de destino");
            }

            if (pasaje.Vagon == null)
            {
                throw new Exception("El pasaje debe tener un vagón");
            }

            if (pasaje.Butaca == null)
            {
                throw new Exception("El pasaje debe tener una butaca");
            }
        }
    }
}
