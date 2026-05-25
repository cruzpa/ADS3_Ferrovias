using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ViajeResultadoBusqueda
    {
        public DateTime FechaSalida { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string DuracionEstimada { get; set; }
        public int CantidadParadas { get; set; }
        public string Categoria { get; set; }
        public int LugaresDisponibles { get; set; }
        public decimal PrecioEstimado { get; set; }
        public Viaje Viaje { get; set; }
    }
}
