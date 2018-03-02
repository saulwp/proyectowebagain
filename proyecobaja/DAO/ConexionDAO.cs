using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class ConexionDAO
    {
        private string CadenaConexion = "Data Source=den1.mssql1.gear.host;Initial Catalog=mayandb;Persist Security Info=True;User ID=mayandb;Password=DreamTeam100*";
        //private string CadenaConexion = "workstation id=mayanbd.mssql.somee.com;packet size=4096;user id=Pato_9_SQLLogin_1;pwd=vv4t19qlfi;data source=mayanbd.mssql.somee.com;persist security info=False;initial catalog=mayanbd";
        //private string CadenaConexion = "Data Source=SIGNAL-1\\SQLEXPRESS; Initial Catalog=lol; Integrated Security =True";
        SqlConnection Conexion;
        SqlCommand Comando;
        SqlDataAdapter Adapter;
        DataSet Datos;

        public ConexionDAO()
        {
            Comando = new SqlCommand();
            Adapter = new SqlDataAdapter();
        }

        public SqlConnection Conectar()
        {
            Conexion = new SqlConnection(CadenaConexion);
            return Conexion;
        }

        public void Abrir()
        {
            Conexion.Open();
        }
        public void Cerrar()
        {
            Conexion.Close();
        }

        public int EjecutarComando(SqlCommand comando)
        {
            //try
            {
                Comando = comando;
                Comando.Connection = Conectar();
                Abrir();
                int ID = 0;
                {
                    var Result = Comando.ExecuteScalar();
                    if(Result!=null)
                    {
                        int.TryParse(Result.ToString(), out ID);
                    }
                }
                Cerrar();
                return ID;
            }
            //catch
            {
                return 0;
            }
        }

        public SqlDataReader EjecutarReader(SqlCommand comando)
        {
            SqlDataReader Reader;
            Comando = comando;
            Comando.Connection = Conectar();
            Abrir();
            Reader = Comando.ExecuteReader();
            Cerrar();
            return Reader;
        }

        public DataSet EjecutarSentencia(SqlCommand comando)
        {
            try
            {
                Comando = comando;
                Datos = new DataSet();
                Comando.Connection = Conectar();
                Adapter = new SqlDataAdapter();
                Adapter.SelectCommand = Comando;
                Abrir();
                Adapter.Fill(Datos);
                Cerrar();
                return Datos;
            }
            catch
            {
                return Datos;
            }

        }






    }
}
