using System;
using System.Collections.Generic;

namespace BE
{
    public class Factura
    {
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public Pasajero Pasajero { get; set; }
        public List<Pasaje> Pasajes { get; set; }
        public decimal Total { get; set; }

        public Factura()
        {
            Pasajes = new List<Pasaje>();
        }
    }
}
