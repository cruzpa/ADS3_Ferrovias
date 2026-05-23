using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Pasajero
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Pasajero Responsable { get; set; }
        public string ParentescoResponsable { get; set; }
    }


}
