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
    public class LogrosUsuarioDAO
    {
        ConexionDAO Conexion = new ConexionDAO();
        public int Agregar(LogrosUsuarioBO Logro)
        {
            SqlCommand Comando = new SqlCommand("insert into LogrosUsuario values(@Logro,@Usuario)");
            Comando.Parameters.Add("@Logro", SqlDbType.Int).Value = Logro.CodigoLogro;
            Comando.Parameters.Add("@Usuario", SqlDbType.Int).Value = Logro.CodigoUsuario;
            return Conexion.EjecutarComando(Comando);
        }

        public bool LogroObtenido(int CodLogro, int Usuario)
        {
            int Resultado = 0;
            SqlCommand Comando = new SqlCommand("select Count(*) from LogrosUsuario where IdUsuario12 = '" + Usuario + "' and IdLogro1='" + CodLogro + "'", Conexion.Conectar());
            Conexion.Abrir();
            SqlDataReader Reader = Comando.ExecuteReader();
            if(Reader.Read())
            {
                Resultado = int.Parse(Reader[0].ToString());
            }
            Conexion.Cerrar();
            return (Resultado > 0);
        }

        public LogroBO BuscarLogro(int CodLogro)
        {
            LogroBO Logro = new LogroBO();
            SqlCommand Comando = new SqlCommand("select * from Logros where IdLogro ='" + CodLogro + "'", Conexion.Conectar());
            Conexion.Abrir();
            SqlDataReader Reader = Comando.ExecuteReader();
            if(Reader.Read())
            {
                Logro.CodigoLogro = int.Parse(Reader[0].ToString());
                Logro.Nombre = Reader[1].ToString();
                Logro.Imagen = Reader[2].ToString();
            }
            Conexion.Cerrar();
            return Logro;
        }

        public List<LogroBO> LogrosLista(int Usuario)
        {
            List<LogroBO> Lista = new List<LogroBO>();
            SqlCommand Comando = new SqlCommand("select Logros.IdLogro, Logros.Nombre, Logros.ImgLogro from Logros, LogrosUsuario where (Logros.IdLogro = LogrosUsuario.IdLogro1) and LogrosUsuario.IdUsuario12 = '"+Usuario+"'", Conexion.Conectar());
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while(Reader.Read())
            {
                LogroBO Logro = new LogroBO();
                Logro.CodigoLogro = int.Parse(Reader[0].ToString());
                Logro.Nombre = Reader[1].ToString();
                Logro.Imagen = Reader[2].ToString();
                Lista.Add(Logro);
            }
            Conexion.Cerrar();
            return Lista;
        }
    }
}
