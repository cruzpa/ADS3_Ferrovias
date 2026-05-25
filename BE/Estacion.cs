using System.Collections.Generic;

namespace BE
{
    public class Estacion
    {
        public string Nombre { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }

        public Estacion(string Nombre, string Localidad, string Provincia = "Buenos Aires")
        {
            this.Nombre = Nombre;
            this.Localidad = Localidad;
            this.Provincia = Provincia;
        }

    }
}
