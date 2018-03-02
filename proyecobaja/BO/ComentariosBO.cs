using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ComentariosBO
    {
        public int Codigo { get; set; }
        public string Comentario { get; set; }
        public int CodigoPublicacion { get; set; }
        public int CodigoUsuario { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
