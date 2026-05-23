using System;
using System.Collections.Generic;

namespace BE
{
    public class Viaje
    {
        public int Numero { get; set; }
        public Recorrido Recorrido { get; set; }
        public Formacion Formacion { get; set; }
        public Maquinista Maquinista { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public TimeSpan DuracionEstimada { get; set; }
        public decimal ValorBaseKilometro { get; set; }
        public List<Pasaje> Pasajes { get; set; }

        public Viaje()
        {
            Pasajes = new List<Pasaje>();
        }
    }
}
