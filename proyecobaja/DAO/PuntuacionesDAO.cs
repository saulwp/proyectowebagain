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
    public class PuntuacionesDAO
    {
        ConexionDAO Conexion;

        public PuntuacionesDAO()
        {
            Conexion = new ConexionDAO();
        }
        public int Agregar(PuntuacionesBO obj)
        {
            SqlCommand Cmd = new SqlCommand("insert into Puntuaciones (IdUsuario5,Puntuacion) values(@CodUsu,@Puntuacion)");
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            Cmd.Parameters.Add("@Puntuacion", SqlDbType.Int).Value = obj.Puntuacion;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Modificar(PuntuacionesBO obj)
        {
            SqlCommand Cmd = new SqlCommand("update Puntuaciones set IdUsuario5 = @CodUsu,Puntuacion = @Puntuacion where IdPuntuacion = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            Cmd.Parameters.Add("@Puntuacion", SqlDbType.Int).Value = obj.Puntuacion;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Eliminar(PuntuacionesBO obj)
        {
            SqlCommand Cmd = new SqlCommand("delete Puntuaciones where IdPuntuacion = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;
            return Conexion.EjecutarComando(Cmd);
        }
        public DataSet TablaPuntuaciones()
        {
            return Conexion.EjecutarSentencia(new SqlCommand("select * from Puntuaciones"));
        }

        public int TotalPuntos(int ID)
        {
            int Total = 0;
            SqlCommand Comando = new SqlCommand("Select SUM(Puntuaciones.Puntuacion) from Puntuaciones where Puntuaciones.IdUsuario5 ='" + ID + "'");
            SqlDataReader Reader;
            Comando.Connection = Conexion.Conectar();
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            if(Reader.Read())
            {
                int.TryParse(Reader[0].ToString(), out ID);
            }
            Conexion.Cerrar();
            return Total;
        }

    }
}
