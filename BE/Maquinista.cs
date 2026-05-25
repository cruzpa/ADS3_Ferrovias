using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Maquinista
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<string> CodigosFormacionesHabilitadas { get; set; }

        public Maquinista()
        {
        }
    }
}
