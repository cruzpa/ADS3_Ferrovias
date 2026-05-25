using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class EstacionService
    {
        private List<Estacion> estaciones;

        public EstacionService() {

            estaciones = new List<Estacion>()
            {
                new Estacion("A", "CABA"),
                new Estacion("B", "CABA"),
                new Estacion("C", "CABA"),
                new Estacion("D", "CABA"),
                new Estacion("E", "CABA"),
                new Estacion("F", "CABA"),
                new Estacion("G", "Tres de Febrero"),
                new Estacion("H", "La Matanza"),
                new Estacion("I", "Morón"),
                new Estacion("J", "Morón"),
                new Estacion("K", "Morón"),
                new Estacion("L", "Ituzaingó"),
                new Estacion("M", "Merlo"),
                new Estacion("N", "Merlo"),
                new Estacion("O", "Moreno"),
                new Estacion("P", "Moreno"),
                new Estacion("Q", "Moreno"),
                new Estacion("R", "Moreno"),
                new Estacion("S", "Moreno"),
                new Estacion("T", "Moreno"),
                new Estacion("U", "Moreno"),
                new Estacion("V", "Moreno"),
                new Estacion("W", "Moreno"),
                new Estacion("X", "Moreno"),
                new Estacion("Y", "Moreno"),
                new Estacion("Z", "Moreno"),
            };
        }

        public void Crear(Estacion estacion)
        {
            ValidarEstacion(estacion);

            if (estaciones.Any(e => e.Nombre == estacion.Nombre))
            {
                throw new Exception("Ya existe una estacion con ese nombre");
            }

            estaciones.Add(estacion);
        }
        public void Editar(Estacion estacion)
        {
            ValidarEstacion(estacion);

            Estacion existente = estaciones.FirstOrDefault(e => e.Nombre == estacion.Nombre);

            if (existente == null)
            {
                throw new Exception("No existe una estacion con ese Nombre");
            }

            existente.Nombre = estacion.Nombre;
            existente.Localidad = estacion.Localidad;
            existente.Provincia = estacion.Provincia;
        }

        public void Borrar(Estacion estacion)
        {
            if (estacion == null || string.IsNullOrWhiteSpace(estacion.Nombre))
            {
                throw new Exception("Debe indicar el Nombre de la estacion");
            }

            Estacion existente = estaciones.FirstOrDefault(m => m.Nombre == estacion.Nombre);

            if (existente == null)
            {
                throw new Exception("No existe una estacion con ese Nombre");
            }

            estaciones.Remove(existente);
        }

        public List<Estacion> Listar()
        {
            return estaciones;
        }
        private void ValidarEstacion(Estacion estacion)
        {
            if (estacion == null)
            {
                throw new Exception("La estacion no puede ser null");
            }

            if (string.IsNullOrWhiteSpace(estacion.Nombre))
            {
                throw new Exception("El Nombre de la estacion es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(estacion.Localidad))
            {
                throw new Exception("La localidad de la estacion es obligatoria.");
            }
        }
    }
}
