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
    class EscenariosDAO
    {
        ConexionDAO Conexion;

        public EscenariosDAO()
        {
            Conexion = new ConexionDAO();
        }        
        public int Agregar(EscenariosBO obj)
        {
            SqlCommand Cmd = new SqlCommand("insert into Escenarios (Nombre,NivelDesbloq) values(@Nombre,@NivelDesbloq)");
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = obj.Nombre;
            Cmd.Parameters.Add("@NivelDesbloq", SqlDbType.Int).Value = obj.NivelDesbloqueado;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Modificar(EscenariosBO obj)
        {
            SqlCommand Cmd = new SqlCommand("update Escenarios set Nombre = @Nombre,NivelDesbloq = @NivelDesbloq where IdEscenario = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = obj.Nombre;
            Cmd.Parameters.Add("@NivelDesbloq", SqlDbType.Int).Value = obj.NivelDesbloqueado;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Eliminar(EscenariosBO obj)
        {
            SqlCommand Cmd = new SqlCommand("delete Escenarios where IdEscenario = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;
            return Conexion.EjecutarComando(Cmd);
        }
        public DataSet TablaEscenarios()
        {
            return Conexion.EjecutarSentencia(new SqlCommand("select * from Escenarios"));
        }
    }
}
