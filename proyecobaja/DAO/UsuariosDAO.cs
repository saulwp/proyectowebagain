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
    public class UsuariosDAO
    {
        ConexionDAO Conexion;
        public UsuariosDAO()
        {
            Conexion = new ConexionDAO();
        }

        public int Agregar(UsuariosBO Usuario)
        {
            SqlCommand Comando = new SqlCommand("insert into Usuarios values(@Nick, @Contra, @Foto, @Correo, @Nombre, @Apellido, @IdTipo)");
            Comando.Parameters.Add("@Nick", SqlDbType.VarChar).Value = Usuario.NickName;
            Comando.Parameters.Add("@Contra", SqlDbType.VarChar).Value = Usuario.Contraseña;
            Comando.Parameters.Add("@Foto", SqlDbType.VarChar).Value = Usuario.FotoPerfil;
            Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Usuario.Correo;
            Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Usuario.Nombre;
            Comando.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = Usuario.Apellido;
            Comando.Parameters.Add("@IdTipo", SqlDbType.Int).Value = Usuario.IDTipo;
            return Conexion.EjecutarComando(Comando);
        }
        public int Modificar(UsuariosBO Usuario)
        {
            SqlCommand Comando = new SqlCommand("update Usuarios set NickName = @Nick,Contraseña = @Contra,FotoPerfil = @Foto,Correo = @Correo,Nombre = @Nombre,Apellido = @Apellido,IdTipo1 = @IdTipo where IdUsuario = @Cod");
            Comando.Parameters.Add("@Cod", SqlDbType.Int).Value = Usuario.Codigo;
            Comando.Parameters.Add("@Nick", SqlDbType.VarChar).Value = Usuario.NickName;
            Comando.Parameters.Add("@Contra", SqlDbType.VarChar).Value = Usuario.Contraseña;
            Comando.Parameters.Add("@Foto", SqlDbType.VarChar).Value = Usuario.FotoPerfil;
            Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Usuario.Correo;
            Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Usuario.Nombre;
            Comando.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = Usuario.Apellido;
            Comando.Parameters.Add("@IdTipo", SqlDbType.Int).Value = Usuario.IDTipo;
            return Conexion.EjecutarComando(Comando);
        }
        public int Eliminar(UsuariosBO Usuario)
        {
            SqlCommand Comando = new SqlCommand("delete Usuarios where IdUsuario = @Cod");
            Comando.Parameters.Add("@Cod", SqlDbType.Int).Value = Usuario.Codigo;
            return Conexion.EjecutarComando(Comando);
        }

        public UsuariosBO BuscarUsuario(string Usuario, string Contraseña)
        {
            string Sentencia = string.Format("select * from Usuarios where NickName ='{0}' and Contraseña='{1}'", Usuario, Contraseña);
            SqlCommand Comando = new SqlCommand(Sentencia);
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            UsuariosBO UsuarioBO = new UsuariosBO();
            if(Reader.Read())
            {
                UsuarioBO.Codigo = int.Parse(Reader[0].ToString());
                UsuarioBO.NickName = Reader[1].ToString();
                UsuarioBO.Contraseña = Reader[2].ToString();
                UsuarioBO.FotoPerfil = Reader[3].ToString();
                UsuarioBO.Correo = Reader[4].ToString();
                UsuarioBO.Nombre = Reader[5].ToString();
                UsuarioBO.Apellido = Reader[6].ToString();
                UsuarioBO.IDTipo = int.Parse(Reader[7].ToString());
            }
            Conexion.Cerrar();
            return UsuarioBO;
        }

        public UsuariosBO BuscarPerfil(string Usuario)
        {
            string Sentencia = string.Format("select * from Usuarios where NickName ='{0}'", Usuario);
            SqlCommand Comando = new SqlCommand(Sentencia);
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            UsuariosBO UsuarioBO = new UsuariosBO();
            if (Reader.Read())
            {
                UsuarioBO.Codigo = int.Parse(Reader[0].ToString());
                UsuarioBO.NickName = Reader[1].ToString();
                UsuarioBO.Contraseña = Reader[2].ToString();
                UsuarioBO.FotoPerfil = Reader[3].ToString();
                UsuarioBO.Correo = Reader[4].ToString();
                UsuarioBO.Nombre = Reader[5].ToString();
                UsuarioBO.Apellido = Reader[6].ToString();
                UsuarioBO.IDTipo = int.Parse(Reader[7].ToString());
            }
            Conexion.Cerrar();
            return UsuarioBO;
        }

        public UsuariosBO BuscarUsuario(int ID)
        {
            string Sentencia = string.Format("select * from Usuarios where IdUsuario ='{0}'", ID);
            SqlCommand Comando = new SqlCommand(Sentencia);
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            UsuariosBO UsuarioBO = new UsuariosBO();
            if (Reader.Read())
            {
                UsuarioBO.Codigo = int.Parse(Reader[0].ToString());
                UsuarioBO.NickName = Reader[1].ToString();
                UsuarioBO.FotoPerfil = Reader[3].ToString();
                UsuarioBO.Correo = Reader[4].ToString();
                UsuarioBO.Nombre = Reader[5].ToString();
                UsuarioBO.Apellido = Reader[6].ToString();
                UsuarioBO.IDTipo = int.Parse(Reader[7].ToString());
            }
            Conexion.Cerrar();
            return UsuarioBO;
        }

        public UsuariosBO BuscarUsuario(string Correo)
        {
            string Sentencia = string.Format("select * from Usuarios where Correo ='{0}'", Correo);
            SqlCommand Comando = new SqlCommand(Sentencia);
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            UsuariosBO UsuarioBO = new UsuariosBO();
            if (Reader.Read())
            {
                UsuarioBO.Codigo = int.Parse(Reader[0].ToString());
                UsuarioBO.NickName = Reader[1].ToString();
                UsuarioBO.FotoPerfil = Reader[3].ToString();
                UsuarioBO.Correo = Reader[4].ToString();
                UsuarioBO.Nombre = Reader[5].ToString();
                UsuarioBO.Apellido = Reader[6].ToString();
                UsuarioBO.IDTipo = int.Parse(Reader[7].ToString());
            }
            Conexion.Cerrar();
            return UsuarioBO;
        }

        public DataSet TablaUsuarios()
        {
            return Conexion.EjecutarSentencia(new SqlCommand("select * from Usuarios"));
        }

        public int CambiarContraseña(UsuariosBO Usuario)
        {
            SqlCommand Comando = new SqlCommand("update Usuarios set Contraseña = @Contra where IdUsuario = @Cod");
            Comando.Parameters.Add("@Cod", SqlDbType.Int).Value = Usuario.Codigo;
            Comando.Parameters.Add("@Contra", SqlDbType.VarChar).Value = Usuario.Contraseña;
            return Conexion.EjecutarComando(Comando);

        }

        public List<UsuariosBO> BuscarUsuarios()
        {
            List<UsuariosBO> Lista = new List<UsuariosBO>();
            string Sentencia = string.Format("select * from Usuarios");
            SqlCommand Comando = new SqlCommand(Sentencia);
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while(Reader.Read())
            {
                UsuariosBO UsuarioBO = new UsuariosBO();
                UsuarioBO.Codigo = int.Parse(Reader[0].ToString());
                UsuarioBO.NickName = Reader[1].ToString();
                UsuarioBO.FotoPerfil = Reader[3].ToString();
                UsuarioBO.Correo = Reader[4].ToString();
                UsuarioBO.Nombre = Reader[5].ToString();
                UsuarioBO.Apellido = Reader[6].ToString();
                UsuarioBO.IDTipo = int.Parse(Reader[7].ToString());
                Lista.Add(UsuarioBO);
            }
            Conexion.Cerrar();
            return Lista;
        }



    }
}
