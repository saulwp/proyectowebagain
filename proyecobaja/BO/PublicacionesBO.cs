using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class PublicacionesBO
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public int CodigoUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public int Prioridad { get; set; }
        public string ImagenPreview { get; set; }


        //Campos Extra
        public int NumeroComentarios { get; set; }

    }
}
