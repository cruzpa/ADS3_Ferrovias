using System;
using System.Collections.Generic;

namespace BE
{
    public class Tramo
    {
        public Estacion Origen { get; set; }
        public Estacion Destino { get; set; }
        public decimal DistanciaKilometros { get; set; }
        public TimeSpan TiempoEstimado { get; set; }
        public List<Estacion> EstacionesIntermedias { get; set; }

        public Tramo()
        {
            EstacionesIntermedias = new List<Estacion>();
        }
    }
}
