using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class VentaPasajeService
    {
        private readonly PasajeService pasajeService = new PasajeService();

        public Pasaje VenderPasaje(Viaje viaje, Pasajero pasajero, Estacion origen, Estacion destino, Vagon vagon, Butaca butaca)
        {
            Pasaje pasaje = new Pasaje
            {
                Numero = ObtenerProximoNumero(viaje),
                Viaje = viaje,
                Pasajero = pasajero,
                Origen = origen,
                Destino = destino,
                Vagon = vagon,
                Butaca = butaca,
                FechaEmision = DateTime.Now,
                Cancelado = false
            };

            CalcularImporte(pasaje);
            pasajeService.Crear(pasaje);

            return pasaje;
        }

        private int ObtenerProximoNumero(Viaje viaje)
        {
            List<Pasaje> pasajes = pasajeService.ObtenerPasajesDeViaje(viaje);

            if (!pasajes.Any())
            {
                return 1;
            }

            return pasajes.Max(p => p.Numero) + 1;
        }

        private void CalcularImporte(Pasaje pasaje)
        {
            decimal importeBase = CalcularImporteBase(pasaje);
            decimal recargoCategoria = CalcularRecargoCategoria(importeBase, pasaje.Vagon.Categoria);
            decimal descuentoParadas = CalcularDescuentoParadas(importeBase, pasaje);
            decimal descuentoMenor = CalcularDescuentoMenor(importeBase + recargoCategoria - descuentoParadas, pasaje.Pasajero);

            pasaje.DescuentoAplicado = descuentoParadas + descuentoMenor;
            pasaje.CostoTotal = importeBase + recargoCategoria - pasaje.DescuentoAplicado;
        }

        private decimal CalcularImporteBase(Pasaje pasaje)
        {
            decimal distancia = CalcularDistanciaContratada(pasaje);
            return distancia * pasaje.Viaje.ValorBaseKilometro;
        }

        private decimal CalcularDistanciaContratada(Pasaje pasaje)
        {
            List<Tramo> tramosContratados = ObtenerTramosContratados(pasaje);
            return tramosContratados.Sum(t => t.DistanciaKilometros);
        }

        private List<Tramo> ObtenerTramosContratados(Pasaje pasaje)
        {
            List<Tramo> tramos = pasaje.Viaje.Recorrido.Tramos;
            int indiceOrigen = BuscarIndiceTramoPorOrigen(tramos, pasaje.Origen);
            int indiceDestino = BuscarIndiceTramoPorDestino(tramos, pasaje.Destino);

            if (indiceOrigen == -1 || indiceDestino == -1 || indiceOrigen > indiceDestino)
            {
                throw new Exception("El origen y destino deben coincidir con extremos de tramos del recorrido");
            }

            return tramos.Skip(indiceOrigen).Take(indiceDestino - indiceOrigen + 1).ToList();
        }

        private int BuscarIndiceTramoPorOrigen(List<Tramo> tramos, Estacion origen)
        {
            return tramos.FindIndex(t => EsMismaEstacion(t.Origen, origen));
        }

        private int BuscarIndiceTramoPorDestino(List<Tramo> tramos, Estacion destino)
        {
            return tramos.FindIndex(t => EsMismaEstacion(t.Destino, destino));
        }

        private decimal CalcularRecargoCategoria(decimal importeBase, Categoria categoria)
        {
            if (categoria == Categoria.Pullman)
            {
                return importeBase * 0.05m;
            }

            if (categoria == Categoria.Ejecutivo)
            {
                return importeBase * 0.10m;
            }

            return 0;
        }

        private decimal CalcularDescuentoParadas(decimal importeBase, Pasaje pasaje)
        {
            int cantidadParadas = ObtenerCantidadParadasContratadas(pasaje);
            return importeBase * cantidadParadas * 0.02m;
        }

        private int ObtenerCantidadParadasContratadas(Pasaje pasaje)
        {
            List<Tramo> tramosContratados = ObtenerTramosContratados(pasaje);
            List<Estacion> paradas = pasaje.Viaje.Recorrido.Paradas;

            return paradas.Count(parada =>
                !EsMismaEstacion(parada, pasaje.Origen) &&
                !EsMismaEstacion(parada, pasaje.Destino) &&
                tramosContratados.Any(tramo => TramoContieneEstacion(tramo, parada))
            );
        }

        private bool TramoContieneEstacion(Tramo tramo, Estacion estacion)
        {
            return EsMismaEstacion(tramo.Origen, estacion) ||
                   EsMismaEstacion(tramo.Destino, estacion);
        }

        private decimal CalcularDescuentoMenor(decimal importe, Pasajero pasajero)
        {
            if (CalcularEdad(pasajero.FechaNacimiento) < 12)
            {
                return importe * 0.50m;
            }

            return 0;
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Today.Year - fechaNacimiento.Year;

            if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            return edad;
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
    }
}
