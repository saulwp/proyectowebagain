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
    class InventarioDAO
    {
        //Enemigos,Items,Escenario
        ConexionDAO Conexion;

        public InventarioDAO()
        {
            Conexion = new ConexionDAO();
        }
        public int Agregar(InventarioBO obj)
        {
            SqlCommand Cmd = new SqlCommand("insert into Inventario (IdUsuario6,IdItem1) values(@CodUsu,@CodItem)");
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            Cmd.Parameters.Add("@CodItem", SqlDbType.Int).Value = obj.CodigoItem;            
            return Conexion.EjecutarComando(Cmd);
        }
        public int Modificar(InventarioBO obj)
        {
            SqlCommand Cmd = new SqlCommand("update Inventario set Idusuario6 = @CodUsu,IdItem1 = @CodItem where IdInventario = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            Cmd.Parameters.Add("@CodItem", SqlDbType.Int).Value = obj.CodigoItem;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Eliminar(InventarioBO obj)
        {
            SqlCommand Cmd = new SqlCommand("delete Inventario where IdInventario = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;            
            return Conexion.EjecutarComando(Cmd);
        }
        public DataSet TablaInventario()
        {
            return Conexion.EjecutarSentencia(new SqlCommand("select * from Inventario"));
        }
    }
}
