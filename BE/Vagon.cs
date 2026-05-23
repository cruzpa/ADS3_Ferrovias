using System.Collections.Generic;

namespace BE
{
    public class Vagon
    {
        public int Numero { get; set; }
        public Categoria Categoria { get; set; }
        public List<Butaca> Butacas { get; set; }

        public Vagon()
        {
            Butacas = new List<Butaca>();
        }
    }
}
