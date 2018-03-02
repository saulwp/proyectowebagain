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
    class EnemigosDAO
    {
        ConexionDAO Conexion;

        public EnemigosDAO()
        {
            Conexion = new ConexionDAO();
        }
        public int Agregar(EnemigosBO obj)
        {
            SqlCommand Cmd = new SqlCommand("insert into Enemigos (Nombre,Puntos,IdEscenario2) values(@Nombre,@Puntos,@CodEsce)");
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = obj.Nombre;
            Cmd.Parameters.Add("@Puntos", SqlDbType.Int).Value = obj.Puntos;
            Cmd.Parameters.Add("@CodEsce", SqlDbType.Int).Value = obj.CodigoEscenario;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Modificar(EnemigosBO obj)
        {
            SqlCommand Cmd = new SqlCommand("update Enemigos set Nombre = @Nombre,Puntos = @Puntos,IdEscenario2 = @CodEsce where IdEnemigo = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.CodigoEnemigo;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = obj.Nombre;
            Cmd.Parameters.Add("@Puntos", SqlDbType.Int).Value = obj.Puntos;
            Cmd.Parameters.Add("@CodEsce", SqlDbType.Int).Value = obj.CodigoEscenario;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Eliminar(EnemigosBO obj)
        {
            SqlCommand Cmd = new SqlCommand("delete Enemigos where IdEnemigo = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.CodigoEnemigo;
            return Conexion.EjecutarComando(Cmd);
        }
        public DataSet TablaEnemigos()
        {
            return Conexion.EjecutarSentencia(new SqlCommand("select * from Enemigos"));
        }
    }
}
