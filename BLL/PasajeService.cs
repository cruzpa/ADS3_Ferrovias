using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PasajeService
    {
        public void Crear(Pasaje pasaje)
        {
            ValidarPasaje(pasaje);
            ValidarRecorridoContratado(pasaje);
            ValidarButacaDisponible(pasaje);

            pasaje.Viaje.Pasajes.Add(pasaje);
        }

        public void Borrar(Pasaje pasaje)
        {
            ValidarPasaje(pasaje);

            if (!pasaje.Viaje.Pasajes.Contains(pasaje))
            {
                throw new Exception("El pasaje no pertenece al viaje indicado");
            }

            pasaje.Viaje.Pasajes.Remove(pasaje);
        }

        public void Cancelar(Pasaje pasaje)
        {
            ValidarPasaje(pasaje);

            if (DateTime.Now > pasaje.Viaje.FechaHoraSalida.AddHours(-48))
            {
                throw new Exception("El pasaje solo puede cancelarse con 48 horas de antelación");
            }

            pasaje.Cancelado = true;
        }

        public List<Pasaje> Listar(Viaje viaje)
        {
            if (viaje == null)
            {
                throw new Exception("El viaje no puede ser nulo");
            }

            return viaje.Pasajes;
        }

        private void ValidarButacaDisponible(Pasaje nuevoPasaje)
        {
            List<Estacion> estacionesOrdenadas = ObtenerEstacionesOrdenadas(nuevoPasaje.Viaje);

            bool butacaOcupada = nuevoPasaje.Viaje.Pasajes.Any(pasajeExistente =>
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

            if (pasaje.Viaje.Pasajes == null)
            {
                pasaje.Viaje.Pasajes = new List<Pasaje>();
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
