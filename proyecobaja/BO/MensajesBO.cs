using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class MensajesBO
    {
        public int Codigo { get; set; }
        public int CodigoUsuarioRecibe { get; set; }
        public int CodigoUsuarioEnvia { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaHora { get; set; }
        public int Estatus { get; set; }

        //Extra
        public UsuariosBO Recibe { get; set; }
        public UsuariosBO Enviar { get; set; }

    }
}
