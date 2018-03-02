using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class CodigosRestablecerBO
    {
        public string Codigo { get; set; }
        public int Usado { get; set; }
        public int CodigoUsuario { get; set; }
        public DateTime FechaGeneracion { get; set; }
    }
}
