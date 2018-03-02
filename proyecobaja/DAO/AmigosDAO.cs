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
    public class AmigosDAO
    {
        ConexionDAO Conexion = new ConexionDAO();

        public class Amistad
        {
            public UsuariosBO Usuario1 { get; set; }
            public UsuariosBO Usuario2 { get; set; }
            public int Estatus { get; set; }
        }


        public int Agregar(AmigosBO Amigo)
        {
            SqlCommand Comando = new SqlCommand("insert into Amigos values(@ID1, @ID2,@Estatus)");
            Comando.Parameters.Add("@ID1", SqlDbType.Int).Value = Amigo.CodigoUsuario1;
            Comando.Parameters.Add("@ID2", SqlDbType.Int).Value = Amigo.CodigoUsuario2;
            Comando.Parameters.Add("@Estatus", SqlDbType.Int).Value = Amigo.Estatus;
            return Conexion.EjecutarComando(Comando);
        }

        public int ModificarEstatus(AmigosBO Amigo)
        {
            SqlCommand Comando = new SqlCommand("update Amigos set Estatus = @Estatus where IdUsuario10 = @ID1 and IdUsuario11 = @ID2");
            Comando.Parameters.Add("@ID1", SqlDbType.Int).Value = Amigo.CodigoUsuario1;
            Comando.Parameters.Add("@ID2", SqlDbType.Int).Value = Amigo.CodigoUsuario2;
            Comando.Parameters.Add("@Estatus", SqlDbType.Int).Value = Amigo.Estatus;
            return Conexion.EjecutarComando(Comando);
        }

        public int EliminarAmistad(AmigosBO Amigo)
        {
            SqlCommand Comando = new SqlCommand("delete from Amigos where IdUsuario10 = @ID1 and IdUsuario11 = @ID2");
            Comando.Parameters.Add("@ID1", SqlDbType.Int).Value = Amigo.CodigoUsuario1;
            Comando.Parameters.Add("@ID2", SqlDbType.Int).Value = Amigo.CodigoUsuario2;
            return Conexion.EjecutarComando(Comando);
        }

        public List<Amistad> Solicitudes(int ID)
        {
            List<Amistad> Lista = new List<Amistad>();
            UsuariosDAO Usuario = new UsuariosDAO();
            SqlCommand Comando = new SqlCommand("select * from Amigos where IdUsuario11='" + ID + "' and Estatus = 1");
            SqlDataReader Reader;
            Comando.Connection=Conexion.Conectar();
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while(Reader.Read())
            {
                Amistad Amistad = new Amistad()
                {
                    Usuario1 = Usuario.BuscarUsuario(int.Parse(Reader[1].ToString())),
                    Usuario2 = Usuario.BuscarUsuario(int.Parse(Reader[2].ToString())),
                    Estatus = int.Parse(Reader[3].ToString())
                };

                Lista.Add(Amistad);

            }
            Conexion.Cerrar();
            return Lista;
        }

        public List<Amistad> Amigos(int ID)
        {
            List<Amistad> Lista = new List<Amistad>();
            UsuariosDAO Usuario = new UsuariosDAO();
            SqlCommand Comando = new SqlCommand("select * from Amigos where (IdUsuario11='" + ID + "' or IdUsuario10='" + ID + "') and Estatus = 2");
            SqlDataReader Reader;
            Comando.Connection = Conexion.Conectar();
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                Amistad Amistad = new Amistad()
                {
                    Usuario1 = Usuario.BuscarUsuario(int.Parse(Reader[1].ToString())),
                    Usuario2 = Usuario.BuscarUsuario(int.Parse(Reader[2].ToString())),
                    Estatus = int.Parse(Reader[3].ToString())
                };

                Lista.Add(Amistad);

            }
            Conexion.Cerrar();
            return Lista;
        }

        public List<Amistad> AmigosChat(int ID)
        {
            List<Amistad> Lista = new List<Amistad>();
            UsuariosDAO Usuario = new UsuariosDAO();
            SqlCommand Comando = new SqlCommand("select * from Amigos where (IdUsuario11='" + ID + "' or IdUsuario10='"+ID+"') and Estatus = 2");
            SqlDataReader Reader;
            Comando.Connection = Conexion.Conectar();
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                Amistad Amistad = new Amistad()
                {
                    Usuario1 = Usuario.BuscarUsuario(int.Parse(Reader[1].ToString())),
                    Usuario2 = Usuario.BuscarUsuario(int.Parse(Reader[2].ToString())),
                    Estatus = int.Parse(Reader[3].ToString())
                };

                Lista.Add(Amistad);

            }
            Conexion.Cerrar();
            return Lista;
        }

        public int AmistadExistente(int ID, int ID2)
        {
            int Resultado = 0;
            SqlCommand Comando = new SqlCommand("select count(*) from Amigos where ((IdUsuario11='" + ID + "' and IdUsuario10='" + ID2 + "') or (IdUsuario11='" + ID2 + "' and IdUsuario10='" + ID + "')) and Estatus = 2");
            SqlDataReader Reader;
            Comando.Connection = Conexion.Conectar();
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                int.TryParse(Reader[0].ToString(), out Resultado);
            }
            Conexion.Cerrar();
            return Resultado;
        }

    }
}
