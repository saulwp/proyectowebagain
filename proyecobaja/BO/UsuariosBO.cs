using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BO
{
    public class UsuariosBO
    {
        public int Codigo { get; set; }
        public string NickName { get; set; }
        public string Contraseña { get; set; }
        public string FotoPerfil { get; set; }
        public HttpPostedFileBase FotoPerfilFile { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IDTipo { get; set; }

    }
}
