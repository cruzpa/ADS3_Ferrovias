using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class GestionService
    {
        private readonly PasajeService pasajeService = new PasajeService();

        public decimal ObtenerRecaudacionTotal()
        {
            return ObtenerPasajesActivos()
                .Sum(pasaje => pasaje.CostoTotal);
        }

        public List<RecaudacionPorRuta> ObtenerRecaudacionPorRuta()
        {
            return ObtenerPasajesActivos()
                .GroupBy(pasaje => ObtenerRuta(pasaje))
                .Select(grupo => new RecaudacionPorRuta
                {
                    Ruta = grupo.Key,
                    Recaudacion = grupo.Sum(pasaje => pasaje.CostoTotal)
                })
                .ToList();
        }

        public List<RecaudacionPorCategoria> ObtenerRecaudacionPorCategoria()
        {
            return ObtenerPasajesActivos()
                .GroupBy(pasaje => pasaje.Vagon.Categoria)
                .Select(grupo => new RecaudacionPorCategoria
                {
                    Categoria = grupo.Key.ToString(),
                    Recaudacion = grupo.Sum(pasaje => pasaje.CostoTotal)
                })
                .ToList();
        }

        public int ObtenerCantidadPasajerosPorViaje(Viaje viaje)
        {
            if (viaje == null)
            {
                throw new Exception("Debe indicar un viaje");
            }

            return ObtenerPasajesActivos()
                .Count(pasaje => pasaje.Viaje.Numero == viaje.Numero);
        }

        public List<PasajerosPorRuta> ObtenerPasajerosPorRuta()
        {
            return ObtenerPasajesActivos()
                .GroupBy(pasaje => ObtenerRuta(pasaje))
                .Select(grupo => new PasajerosPorRuta
                {
                    Ruta = grupo.Key,
                    CantidadPasajeros = grupo.Count()
                })
                .ToList();
        }

        public List<PasajerosPorCategoria> ObtenerPasajerosPorCategoria()
        {
            return ObtenerPasajesActivos()
                .GroupBy(pasaje => pasaje.Vagon.Categoria)
                .Select(grupo => new PasajerosPorCategoria
                {
                    Categoria = grupo.Key.ToString(),
                    CantidadPasajeros = grupo.Count()
                })
                .ToList();
        }

        private List<Pasaje> ObtenerPasajesActivos()
        {
            return pasajeService.Listar()
                .Where(pasaje => !pasaje.Cancelado)
                .ToList();
        }

        private string ObtenerRuta(Pasaje pasaje)
        {
            return pasaje.Origen.Nombre + " - " + pasaje.Destino.Nombre;
        }
    }

    public class RecaudacionPorRuta
    {
        public string Ruta { get; set; }
        public decimal Recaudacion { get; set; }
    }

    public class RecaudacionPorCategoria
    {
        public string Categoria { get; set; }
        public decimal Recaudacion { get; set; }
    }

    public class PasajerosPorRuta
    {
        public string Ruta { get; set; }
        public int CantidadPasajeros { get; set; }
    }

    public class PasajerosPorCategoria
    {
        public string Categoria { get; set; }
        public int CantidadPasajeros { get; set; }
    }
}
