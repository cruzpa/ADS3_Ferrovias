using System.Collections.Generic;

namespace BE
{
    public class Recorrido
    {
        public string Nombre { get; set; }
        public Estacion Origen { get; set; }
        public Estacion Destino { get; set; }
        public List<Tramo> Tramos { get; set; }
        public List<Estacion> Paradas { get; set; }

        public Recorrido()
        {
            Tramos = new List<Tramo>();
            Paradas = new List<Estacion>();
        }
    }
}
