using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BO;

namespace DAO
{
    public class LikesDAO
    {
        ConexionDAO Conexion;
        public LikesDAO()
        {
            Conexion = new ConexionDAO();
        }
        public int Agregar(LikesBO Like)
        {
            SqlCommand Comando = new SqlCommand("insert into Likes values(@Usuario, @Publicacion)");
            Comando.Parameters.Add("@Usuario", SqlDbType.Int).Value = Like.CodigoUsuario13;
            Comando.Parameters.Add("@Publicacion", SqlDbType.Int).Value = Like.CodigoPublicacion;
            return Conexion.EjecutarComando(Comando);
        }

       
    }
}
