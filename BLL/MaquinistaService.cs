using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class MaquinistaService
    {
        private readonly List<Maquinista> maquinistas = new List<Maquinista>();

        public void Crear(Maquinista maquinista)
        {
            ValidarMaquinista(maquinista);

            if (maquinistas.Any(m => m.Dni == maquinista.Dni))
            {
                throw new Exception("Ya existe un maquinista con ese DNI");
            }

            maquinistas.Add(maquinista);
        }

        public void Editar(Maquinista maquinista)
        {
            ValidarMaquinista(maquinista);

            Maquinista existente = maquinistas.FirstOrDefault(m => m.Dni == maquinista.Dni);

            if (existente == null)
            {
                throw new Exception("No existe un maquinista con ese DNI");
            }

            existente.Nombre = maquinista.Nombre;
            existente.Apellido = maquinista.Apellido;
            existente.FormacionesHabilitadas = maquinista.FormacionesHabilitadas;
        }

        public void Borrar(Maquinista maquinista)
        {
            if (maquinista == null || string.IsNullOrWhiteSpace(maquinista.Dni))
            {
                throw new Exception("Debe indicar el DNI del maquinista");
            }

            Maquinista existente = maquinistas.FirstOrDefault(m => m.Dni == maquinista.Dni);

            if (existente == null)
            {
                throw new Exception("No existe un maquinista con ese DNI");
            }

            maquinistas.Remove(existente);
        }

        public List<Maquinista> Listar()
        {
            return maquinistas;
        }

        private void ValidarMaquinista(Maquinista maquinista)
        {
            if (maquinista == null)
            {
                throw new Exception("El maquinista no puede ser nulo");
            }

            if (string.IsNullOrWhiteSpace(maquinista.Dni))
            {
                throw new Exception("El DNI del maquinista es obligatorio");
            }

            if (string.IsNullOrWhiteSpace(maquinista.Nombre))
            {
                throw new Exception("El nombre del maquinista es obligatorio");
            }

            if (string.IsNullOrWhiteSpace(maquinista.Apellido))
            {
                throw new Exception("El apellido del maquinista es obligatorio");
            }
        }
    }
}
