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
    public class TipoUsuarioDAO
    {
        ConexionDAO Conexion;
        public TipoUsuarioDAO()
        {
            Conexion = new ConexionDAO();
        }
        public int Agregar(TipoUsuarioBO obj)
        {
            SqlCommand Cmd = new SqlCommand("insert into TipoUsuario (Tipo) values(@Tipo)");
            Cmd.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = obj.Tipo;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Modificar(TipoUsuarioBO obj)
        {
            SqlCommand Cmd = new SqlCommand("update TipoUsuario set Tipo = @Tipo where IdTipo = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;
            Cmd.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = obj.Tipo;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Eliminar(TipoUsuarioBO obj)
        {
            SqlCommand Cmd = new SqlCommand("delete TipoUsuario where IdTipo = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;
            return Conexion.EjecutarComando(Cmd);
        }
        public DataSet TablaTipoUsuario()
        {
            return Conexion.EjecutarSentencia(new SqlCommand("select * from TipoUsuario"));
        }

        public List<TipoUsuarioBO> ListaTipos()
        {
            SqlCommand Comando = new SqlCommand("Select * from TipoUsuario");
            SqlDataReader Reader;
            Comando.Connection = Conexion.Conectar();
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            List<TipoUsuarioBO> Lista = new List<TipoUsuarioBO>();
            TipoUsuarioBO tipo = new TipoUsuarioBO();
            while (Reader.Read())
            {
                tipo = new TipoUsuarioBO()
                {
                    Codigo = int.Parse(Reader[0].ToString()),
                    Tipo = Reader[1].ToString()
                };
                Lista.Add(tipo);
            }
            return Lista;


        }




    }
}
