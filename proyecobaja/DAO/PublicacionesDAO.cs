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
    public class PublicacionesDAO
    {
        
        ConexionDAO Conexion;
        public PublicacionesDAO()
        {
            Conexion = new ConexionDAO();
        }
        public int Agregar(PublicacionesBO obj)
        {
            SqlCommand Cmd = new SqlCommand("insert into Publicaciones (Titulo,Cuerpo,IdUsuario1,FechaHora,Prioridad,ImgPrev) output INSERTED.IdPublicacion values(@Titulo,@Contenido,@CodUsu,@FechaHora,@Prioridad,@ImgPrev) ");
            Cmd.Parameters.Add("@Titulo", SqlDbType.VarChar).Value = obj.Titulo;
            Cmd.Parameters.Add("@Contenido", SqlDbType.VarChar).Value = obj.Contenido;
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            Cmd.Parameters.Add("@FechaHora", SqlDbType.DateTime).Value = obj.FechaHora;
            Cmd.Parameters.Add("@Prioridad", SqlDbType.Int).Value = obj.Prioridad;
            Cmd.Parameters.Add("@ImgPrev", SqlDbType.VarChar).Value = obj.ImagenPreview;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Modificar(PublicacionesBO obj)
        {
            SqlCommand Cmd = new SqlCommand("Update Publicaciones Set Titulo = @Titulo,Cuerpo = @Contenido,IdUsuario1 = @CodUsu,FechaHora = @FechaHora where IdPublicacion = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;
            Cmd.Parameters.Add("@Titulo", SqlDbType.VarChar).Value = obj.Titulo;
            Cmd.Parameters.Add("@Contenido", SqlDbType.VarChar).Value = obj.Contenido;
            Cmd.Parameters.Add("@CodUsu", SqlDbType.Int).Value = obj.CodigoUsuario;
            Cmd.Parameters.Add("@FechaHora", SqlDbType.DateTime).Value = obj.FechaHora;
            Cmd.Parameters.Add("@ImgPrev", SqlDbType.VarChar).Value = obj.ImagenPreview;
            return Conexion.EjecutarComando(Cmd);
        }
        public int Eliminar(PublicacionesBO obj)
        {
            SqlCommand Cmd = new SqlCommand("delete Publicaciones where IdPublicacion = @Cod");
            Cmd.Parameters.Add("@Cod", SqlDbType.Int).Value = obj.Codigo;
            return Conexion.EjecutarComando(Cmd);
        }
        public DataSet ListarPublicaciones()
        {
            return Conexion.EjecutarSentencia(new SqlCommand("select * from Publicaciones"));
        }

        public List<PublicacionesBO> ListaPeliculas()
        {
            List<PublicacionesBO> Publicaciones = new List<PublicacionesBO>();
            SqlCommand Comando = new SqlCommand("Select * from Publicaciones");
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while(Reader.Read())
            {
                PublicacionesBO Publicacion = new PublicacionesBO()
                {
                    Codigo = int.Parse(Reader[0].ToString()),
                    Titulo = Reader[1].ToString(),
                    Contenido = Reader[2].ToString(),
                    CodigoUsuario = int.Parse(Reader[3].ToString()),
                    FechaHora = DateTime.Parse(Reader[4].ToString())
                };
                Publicaciones.Add(Publicacion);
            }
            Conexion.Cerrar();
            return Publicaciones;
        }

        public PublicacionesBO BuscarPublicacion(int ID)
        {
            SqlCommand Comando = new SqlCommand("Select * from Publicaciones where IdPublicacion='"+ID+"'");
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            PublicacionesBO Publicacion = new PublicacionesBO();
            Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                Publicacion = new PublicacionesBO()
                {
                    Codigo = int.Parse(Reader[0].ToString()),
                    Titulo = Reader[1].ToString(),
                    Contenido = Reader[2].ToString(),
                    CodigoUsuario = int.Parse(Reader[3].ToString()),
                    FechaHora = DateTime.Parse(Reader[4].ToString()),
                    ImagenPreview = Reader[6].ToString()
                };
                
            }
            Conexion.Cerrar();
            return Publicacion;
        }


        public List<PublicacionesBO> NoticiasFront()
        {
            ComentariosDAO Comentarios = new ComentariosDAO();
            List<PublicacionesBO> Publicaciones = new List<PublicacionesBO>();
            SqlCommand Comando = new SqlCommand("Select * from Publicaciones where Prioridad=1");
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                PublicacionesBO Publicacion = new PublicacionesBO()
                {
                    Codigo = int.Parse(Reader[0].ToString()),
                    Titulo = Reader[1].ToString(),
                    Contenido = Reader[2].ToString(),
                    CodigoUsuario = int.Parse(Reader[3].ToString()),
                    FechaHora = DateTime.Parse(Reader[4].ToString()),
                    NumeroComentarios = Comentarios.NumeroComentarios(int.Parse(Reader[0].ToString())),
                    ImagenPreview = Reader[6].ToString()
                };
                Publicaciones.Add(Publicacion);
            }
            Conexion.Cerrar();
            return Publicaciones;
        }
        public List<PublicacionesBO> PublicacionesFront()
        {
            ComentariosDAO Comentarios = new ComentariosDAO();
            List<PublicacionesBO> Publicaciones = new List<PublicacionesBO>();
            SqlCommand Comando = new SqlCommand("Select * from Publicaciones where Prioridad=0");
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                PublicacionesBO Publicacion = new PublicacionesBO()
                {
                    Codigo = int.Parse(Reader[0].ToString()),
                    Titulo = Reader[1].ToString(),
                    Contenido = Reader[2].ToString(),
                    CodigoUsuario = int.Parse(Reader[3].ToString()),
                    FechaHora = DateTime.Parse(Reader[4].ToString()),
                    NumeroComentarios = Comentarios.NumeroComentarios(int.Parse(Reader[0].ToString())),
                    ImagenPreview = Reader[6].ToString()
                };
                Publicaciones.Add(Publicacion);
            }
            Conexion.Cerrar();
            return Publicaciones;
        }
        public List<PublicacionesBO> MisPublicaciones(int ID)
        {
            ComentariosDAO Comentarios = new ComentariosDAO();
            List<PublicacionesBO> Publicaciones = new List<PublicacionesBO>();
            SqlCommand Comando = new SqlCommand("Select * from Publicaciones where IdUsuario1='"+ID+"'");
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                PublicacionesBO Publicacion = new PublicacionesBO()
                {
                    Codigo = int.Parse(Reader[0].ToString()),
                    Titulo = Reader[1].ToString(),
                    Contenido = Reader[2].ToString(),
                    CodigoUsuario = int.Parse(Reader[3].ToString()),
                    FechaHora = DateTime.Parse(Reader[4].ToString()),
                    NumeroComentarios = Comentarios.NumeroComentarios(int.Parse(Reader[0].ToString())),
                    ImagenPreview = Reader[6].ToString()
                };
                Publicaciones.Add(Publicacion);
            }
            Conexion.Cerrar();
            return Publicaciones;
        }
        public List<PublicacionesBO> PaginacionPubs(int Numero)
        {
            ComentariosDAO Comentarios = new ComentariosDAO();
            List<PublicacionesBO> Publicaciones = new List<PublicacionesBO>();
            SqlCommand Comando = new SqlCommand("exec PaginacionPub "+Numero);
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                PublicacionesBO Publicacion = new PublicacionesBO()
                {
                    Codigo = int.Parse(Reader[1].ToString()),
                    Titulo = Reader[2].ToString(),
                    Contenido = Reader[3].ToString(),
                    CodigoUsuario = int.Parse(Reader[4].ToString()),
                    FechaHora = DateTime.Parse(Reader[5].ToString()),
                    NumeroComentarios = Comentarios.NumeroComentarios(int.Parse(Reader[1].ToString())),
                    ImagenPreview = Reader[7].ToString()
                };
                Publicaciones.Add(Publicacion);
            }
            Conexion.Cerrar();
            return Publicaciones;
        }
        public int CantidadPubs()
        {
            int Cantidad = 0;
            SqlCommand Comando = new SqlCommand("Select Count(*) from Publicaciones");
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                Cantidad = int.Parse(Reader[0].ToString());
            }
            Conexion.Cerrar();
            return Cantidad;
        }

        public List<PublicacionesBO> ResultadosPubs()
        {
            ComentariosDAO Comentarios = new ComentariosDAO();
            List<PublicacionesBO> Publicaciones = new List<PublicacionesBO>();
            SqlCommand Comando = new SqlCommand("Select * from Publicaciones");
            Comando.Connection = Conexion.Conectar();
            SqlDataReader Reader;
            Conexion.Abrir();
            Reader = Comando.ExecuteReader();
            while (Reader.Read())
            {
                PublicacionesBO Publicacion = new PublicacionesBO()
                {
                    Codigo = int.Parse(Reader[0].ToString()),
                    Titulo = Reader[1].ToString(),
                    Contenido = Reader[2].ToString(),
                    CodigoUsuario = int.Parse(Reader[3].ToString()),
                    FechaHora = DateTime.Parse(Reader[4].ToString()),
                    NumeroComentarios = Comentarios.NumeroComentarios(int.Parse(Reader[0].ToString())),
                    ImagenPreview = Reader[6].ToString()
                };
                Publicaciones.Add(Publicacion);
            }
            Conexion.Cerrar();
            return Publicaciones;
        }


    }
}
