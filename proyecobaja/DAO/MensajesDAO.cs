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
    public class MensajesDAO
    {
        ConexionDAO Conexion;

        public class Chats
        {
            public UsuariosBO Remitente { get; set; }
            public DateTime FechaHora { get; set; }
            public int NumeroMensajes { get; set; }
            public string UltimoMensaje { get; set; }
        }


        public MensajesDAO()
        {
            Conexion = new ConexionDAO();
        }
        public int Agregar(MensajesBO obj)
        {
            SqlCommand Cmd = new SqlCommand("insert into Mensajes values(@UsuRecibe,@UsuEnvia,@Mensaje,@FechaHora,@Estatus)");
            Cmd.Parameters.Add("@UsuRecibe", SqlDbType.Int).Value = obj.CodigoUsuarioRecibe;
            Cmd.Parameters.Add("@UsuEnvia", SqlDbType.Int).Value = obj.CodigoUsuarioEnvia;
            Cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar).Value = obj.Mensaje;
            Cmd.Parameters.Add("@FechaHora", SqlDbType.DateTime).Value = obj.FechaHora;
            Cmd.Parameters.Add("@Estatus", SqlDbType.Int).Value = obj.Estatus;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Modificar(MensajesBO obj)
        {
            SqlCommand Cmd = new SqlCommand("update Mensajes set IdUsuarioRec = @UsuRecibe,IdUsuarioEnv = @UsuEnvia,Mensaje = @Mensaje,FechaHora = @FechaHora,Estatus = @Estatus where x = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;
            Cmd.Parameters.Add("@UsuRecibe", SqlDbType.Int).Value = obj.CodigoUsuarioRecibe;
            Cmd.Parameters.Add("@UsuEnvia", SqlDbType.Int).Value = obj.CodigoUsuarioEnvia;
            Cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar).Value = obj.Mensaje;
            Cmd.Parameters.Add("@FechaHora", SqlDbType.DateTime).Value = obj.FechaHora;
            Cmd.Parameters.Add("@Estatus", SqlDbType.Int).Value = obj.Estatus;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Eliminar(MensajesBO obj)
        {
            SqlCommand Cmd = new SqlCommand("delete Mensajes where IdUsuarioRec = @UsuRecibe || IdUsuarioEnv = @UsuEnvia");
            //Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;
            Cmd.Parameters.Add("@UsuRecibe", SqlDbType.Int).Value = obj.CodigoUsuarioRecibe;
            Cmd.Parameters.Add("@UsuEnvia", SqlDbType.Int).Value = obj.CodigoUsuarioEnvia;
            return Conexion.EjecutarComando(Cmd);
        }
        public DataSet TablaMensajes()
        {
            return Conexion.EjecutarSentencia(new SqlCommand("select * from Mensajes"));
        }

        public List<Chats> ListaChats(int ID)
        {
            UsuariosDAO Usuarios = new UsuariosDAO();
            List<MensajesDAO.Chats> Lista = new List<MensajesDAO.Chats>();
            SqlCommand Comando = new SqlCommand("exec Chats " + ID);
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while(Reader.Read())
            {
                MensajesDAO.Chats chats = new MensajesDAO.Chats()
                {
                    Remitente = Usuarios.BuscarUsuario(int.Parse(Reader[0].ToString())),
                    FechaHora = DateTime.Parse(Reader[1].ToString()),
                    NumeroMensajes = int.Parse(Reader[2].ToString()),
                    UltimoMensaje = Reader[3].ToString()
                };
                Lista.Add(chats);
            }
            Conexion.Cerrar();
            return Lista;
        }

        public List<MensajesBO> Chat(int ID, int ID2)
        {
            UsuariosDAO Usuarios = new UsuariosDAO();
            List<MensajesBO> Lista = new List<MensajesBO>();
            SqlCommand Comando = new SqlCommand("exec Chat " + ID + ","+ID2);
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                MensajesBO chats = new MensajesBO()
                {
                    Codigo = int.Parse(Reader[0].ToString()),
                    Enviar = Usuarios.BuscarUsuario(int.Parse(Reader[1].ToString())),
                    Recibe = Usuarios.BuscarUsuario(int.Parse(Reader[2].ToString())),
                    FechaHora = DateTime.Parse(Reader[3].ToString()),
                    Mensaje = Reader[4].ToString()
                };
                Lista.Add(chats);
            }
            Conexion.Cerrar();
            return Lista;
        }

    }
}
