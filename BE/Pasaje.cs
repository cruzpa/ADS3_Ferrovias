using System;

namespace BE
{
    public class Pasaje
    {
        public int Numero { get; set; }
        public string ClienteUsername { get; set; }
        public Viaje Viaje { get; set; }
        public Pasajero Pasajero { get; set; }
        public Estacion Origen { get; set; }
        public Estacion Destino { get; set; }
        public Vagon Vagon { get; set; }
        public Butaca Butaca { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public DateTime FechaEmision { get; set; }
        public bool Cancelado { get; set; }
    }
}
