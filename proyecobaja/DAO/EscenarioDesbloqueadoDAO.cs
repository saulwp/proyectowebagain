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
    class EscenarioDesbloqueadoDAO
    {
        ConexionDAO Conexion;

        public EscenarioDesbloqueadoDAO()
        {
            Conexion = new ConexionDAO();
        }
        public int Agregar(EscenarioDesbloqueadoBO obj)
        {
            SqlCommand Cmd = new SqlCommand("insert into EscenarioDesbloq (IdEscenario1,IdUsuario7) values(@CodEscen,@CodUsu)");
            Cmd.Parameters.Add("@CodEscen", SqlDbType.Int).Value = obj.CodigoEscenario;
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Modificar(EscenarioDesbloqueadoBO obj)
        {
            SqlCommand Cmd = new SqlCommand("update EscenarioDesbloq set IdEscenario1 = @CodEscen,IdUsuario7 = @CodUsu where IdEscenario1 = @CodEscen || IdUsuario7 = @CodUsu");
            Cmd.Parameters.Add("@CodEscen", SqlDbType.Int).Value = obj.CodigoEscenario;
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Eliminar(EscenarioDesbloqueadoBO obj)
        {
            SqlCommand Cmd = new SqlCommand("delete EscenarioDesbloq where IdEscenario1 = @CodEscen || IdUsuario7 = @CodUsu");
            Cmd.Parameters.Add("@CodEscen", SqlDbType.Int).Value = obj.CodigoEscenario;
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            return Conexion.EjecutarComando(Cmd);
        }
        public DataSet TablaEscenarioDesbloq()
        {
            return Conexion.EjecutarSentencia(new SqlCommand("select * from EscenarioDesbloq"));
        }
    }
}
