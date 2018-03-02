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
    class CheckPointsDAO
    {
        ConexionDAO Conexion;

        public CheckPointsDAO()
        {
            Conexion = new ConexionDAO();
        }
        public int Agregar(CheckPointsBO obj)
        {
            SqlCommand Cmd = new SqlCommand("insert into CheckPoints (IdEscenario3,IdUsuario8) values(@CodEsce,@CodUsu)");
            Cmd.Parameters.Add("@CodEsce", SqlDbType.Int).Value = obj.CodigoEscenario;
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Modificar(CheckPointsBO obj)
        {
            SqlCommand Cmd = new SqlCommand("update CheckPoints set IdEscenario3 = @CodEsce,IdUsuario8 = @CodUsu where IdEscenario3 = @CodEsce || IdUsuario8 = @CodUsu");
            Cmd.Parameters.Add("@CodEsce", SqlDbType.Int).Value = obj.CodigoEscenario;
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Eliminar(CheckPointsBO obj)
        {
            SqlCommand Cmd = new SqlCommand("delete CheckPoints where IdEscenario3 = @CodEsce || IdUsuario8 = @CodUsu");
            Cmd.Parameters.Add("@CodEsce", SqlDbType.Int).Value = obj.CodigoEscenario;
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            return Conexion.EjecutarComando(Cmd);
        }
        public DataSet TablaCheckPoints()
        {
            return Conexion.EjecutarSentencia(new SqlCommand("select * from CheckPoints"));
        }
    }
}
