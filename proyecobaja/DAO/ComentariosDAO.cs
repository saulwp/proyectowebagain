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
    public class ComentariosDAO
    {
        public class Comentario:ComentariosBO
        {
            public UsuariosBO Usuario;
        }

        ConexionDAO Conexion;
        public ComentariosDAO()
        {
            Conexion = new ConexionDAO();
        }
        public int Agregar(ComentariosBO obj)
        {
            SqlCommand Cmd = new SqlCommand("insert into Comentarios (Comentario,IdPublicacion1,IdUsuario2,FehcaHora) values(@Comentario,@CodPubli,@CodUsu,@FechaHora)");
            Cmd.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = obj.Comentario;
            Cmd.Parameters.Add("@CodPubli", SqlDbType.Int).Value = obj.CodigoPublicacion;
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            Cmd.Parameters.Add("@FechaHora", SqlDbType.DateTime).Value = obj.FechaHora;           
            return Conexion.EjecutarComando(Cmd);
        }
        public int Modificar(ComentariosBO obj)
        {
            SqlCommand Cmd = new SqlCommand("Update Comentarios Set Comentario = @Comentario,IdPublicacion1 = @CodPubli,IdUsuario2 = @CodUsu,FechaHora = @FechaHora where IdComentario = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;
            Cmd.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = obj.Comentario;
            Cmd.Parameters.Add("@CodPubli", SqlDbType.Int).Value = obj.CodigoPublicacion;
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            Cmd.Parameters.Add("@FechaHora", SqlDbType.DateTime).Value = obj.FechaHora;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Eliminar(ComentariosBO obj)
        {
            SqlCommand Cmd = new SqlCommand("delete Comentarios where IdComentario = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;          
            return Conexion.EjecutarComando(Cmd);
        }
        public DataSet ListarComentarios()
        {
            return Conexion.EjecutarSentencia(new SqlCommand("select * from Comentarios"));
        }

        public List<Comentario> ListaComentarios(int ID)
        {
            List<Comentario> Lista = new List<Comentario>();
            SqlCommand Comando = new SqlCommand("Select * from Comentarios where IdPublicacion1='" + ID + "' order by FehcaHora desc ");
            Comando.Connection = Conexion.Conectar();
            UsuariosDAO Usuarios = new UsuariosDAO();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                Comentario Comentario = new Comentario()
                {
                    Codigo = int.Parse(Reader[0].ToString()),
                    Comentario = Reader[1].ToString(),
                    CodigoPublicacion = int.Parse(Reader[2].ToString()),
                    CodigoUsuario = int.Parse(Reader[3].ToString()),
                    FechaHora = DateTime.Parse(Reader[4].ToString()),
                    Usuario = Usuarios.BuscarUsuario(int.Parse(Reader[3].ToString())),
                   
                };
                Lista.Add(Comentario);

            }
            Conexion.Cerrar();
            return Lista;
        }

        public int NumeroComentarios(int ID)
        {
            SqlCommand Comando = new SqlCommand("select count(*) from Comentarios where IdPublicacion1 ='" + ID +"'", Conexion.Conectar());
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            int Resultado = 0;
            if(Reader.Read())
            {
                Resultado = int.Parse(Reader[0].ToString());
            }
            Conexion.Cerrar();
            return Resultado;
        }



    }
}
