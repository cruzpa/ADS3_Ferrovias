using System.Collections.Generic;

namespace BE
{
    public class Vagon
    {
        public int Numero { get; set; }
        public Categoria Categoria { get; set; }
        public List<Butaca> Butacas { get; set; }

        public Vagon(int numero, Categoria categoria)
        {

            Numero = numero;
            Categoria = categoria;
            Butacas = GenerarButacas(categoria);
        }

        //Cada vagón turista posee 72 asientos numerados,mientras que en Pullman y ejecutivo tienen 54 butacas
        private List<Butaca> GenerarButacas(Categoria categoria)
        {
            int cantidad = (categoria == Categoria.Turista) ? 72 : 54;
            var lista = new List<Butaca>(cantidad);

            for (int i = 1; i <= cantidad; i++)
            {
                lista.Add(new Butaca { Numero = i });
            }
            return lista;
        }
    }
}