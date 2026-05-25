using System.Collections.Generic;

namespace BE
{
    public class Formacion
    {
        public string Codigo { get; set; }
        public List<Vagon> Vagones { get; set; }

        public Formacion(string codigo)
        {
            Codigo = codigo;
            Vagones = new List<Vagon>()
            {
                new Vagon(1, Categoria.Ejecutivo),
                new Vagon(2, Categoria.Pullman),
                new Vagon(3, Categoria.Turista),
                new Vagon(4, Categoria.Turista),
                new Vagon(5, Categoria.Turista)
            };
        }
    }
}
