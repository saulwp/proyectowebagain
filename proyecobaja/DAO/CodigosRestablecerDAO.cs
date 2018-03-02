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
    public class CodigosRestablecerDAO
    {
        ConexionDAO Conexion;
        public CodigosRestablecerDAO()
        {
            Conexion = new ConexionDAO();
        }

        public int Agregar(CodigosRestablecerBO Codigos)
        {
            SqlCommand Comando = new SqlCommand("Insert into CodigosRestablecer values(@Codigo, @Usado, @IdUsuario,@Fecha)");
            Comando.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Codigos.Codigo;
            Comando.Parameters.Add("@Usado", SqlDbType.Int).Value = Codigos.Usado;
            Comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Codigos.CodigoUsuario;
            Comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = Codigos.FechaGeneracion.ToString("yyyy/MM/dd");
            return Conexion.EjecutarComando(Comando);
        }

        public bool VerficarCodigo(string Codigo)
        {
            SqlCommand Comando = new SqlCommand("select Count(*) from CodigosRestablecer where Codigo ='" + Codigo + "'");
            return (Conexion.EjecutarComando(Comando) > 0);
        }

        public CodigosRestablecerBO BuscarCodigo(string Codigo)
        {
            SqlCommand Comando = new SqlCommand("select * from CodigosRestablecer where Codigo ='" + Codigo + "'");
            SqlDataReader Reader;
            Comando.Connection = Conexion.Conectar();
            Conexion.Abrir();

            Reader = Comando.ExecuteReader();
            CodigosRestablecerBO CodigoBO = new CodigosRestablecerBO();
            if(Reader.Read())
            {
                CodigoBO = new CodigosRestablecerBO()
                {
                    Codigo = Reader[0].ToString(),
                    Usado = int.Parse(Reader[1].ToString()),
                    CodigoUsuario = int.Parse(Reader[2].ToString()),
                    FechaGeneracion = DateTime.Parse(Reader[3].ToString())
                };
            }

            Conexion.Cerrar();
            return CodigoBO;
        }

        public int CodigoUsado(CodigosRestablecerBO Codigos)
        {
            SqlCommand Comando = new SqlCommand("update CodigosRestablecer set Usuado = 1 where Codigo ='"+Codigos.Codigo+"' and Usuado = 0");
            return Conexion.EjecutarComando(Comando);
        }


    }
}
