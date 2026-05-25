using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class RecorridoService
    {
        private static readonly Dictionary<string, Recorrido> recorridos = new Dictionary<string, Recorrido>();

        static RecorridoService()
        {
            List<Estacion> estaciones = new EstacionService().Listar();
            List<Estacion> paradasVocales = new List<Estacion>
            {
                estaciones[4],  // E
                estaciones[8],  // I
                estaciones[14], // O
                estaciones[20]  // U
            };

            List<Estacion> paradasConsonantes = estaciones
                .Where(e => !"AEIOUZ".Contains(e.Nombre))
                .ToList();

            List<Estacion> sinParadas = new List<Estacion>();

            List<Estacion> paradasFJ = new List<Estacion>
            {
                estaciones[5], // F
                estaciones[9]  // J
            };

            List<Estacion> paradasKLMNOP = new List<Estacion>
            {
                estaciones[10], // K
                estaciones[11], // L
                estaciones[12], // M
                estaciones[13], // N
                estaciones[14], // O
                estaciones[15]  // P
            };

            Crear("Ramal A-Z, paradas: A + VOCALES + Z", estaciones, paradasVocales);
            Crear("Ramal A-Z, paradas: A + CONSONANTES + Z", estaciones, paradasConsonantes);
            Crear("Ramal A-Z, sin paradas", estaciones, sinParadas);
            Crear("Ramal A-Z, paradas: F y J", estaciones, paradasFJ);
            Crear("Ramal A-Z, paradas: KLMNOP", estaciones, paradasKLMNOP);
        }

        public static Recorrido Crear(string nombre, List<Estacion> estaciones, List<Estacion> paradas)
        {
            ValidarCrear(nombre, estaciones);

            Recorrido recorrido = new Recorrido
            {
                Nombre = nombre,
                Origen = estaciones.First(),
                Destino = estaciones.Last()
            };

            for (int i = 0; i < estaciones.Count - 1; i++)
            {
                recorrido.Tramos.Add(new Tramo
                {
                    Origen = estaciones[i],
                    Destino = estaciones[i + 1],
                    DistanciaKilometros = 5,
                    TiempoEstimado = TimeSpan.FromMinutes(8)
                });
            }

            foreach (var parada in paradas)
            {
                if (estaciones.Contains(parada))
                {
                    recorrido.Paradas.Add(parada);
                } else
                {
                    throw new Exception($"La parada {parada.Nombre} no forma parte del recorrido");
                }
            }

            recorridos[nombre] = recorrido;

            return recorrido;
        }

        public static List<Recorrido> Listar()
        {
            return recorridos.Values.ToList();
        }

        private static void ValidarCrear(string nombre, List<Estacion> estaciones)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre del recorrido es obligatorio");
            }

            if (estaciones == null || estaciones.Count < 2)
            {
                throw new Exception("El recorrido debe tener al menos dos estaciones");
            }
        }
    }
}
