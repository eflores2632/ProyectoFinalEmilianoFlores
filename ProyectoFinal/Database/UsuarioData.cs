using IntegrandoApi.Models;
using Microsoft.Data.SqlClient;
namespace IntegrandoApi.Database
{
    public class UsuarioData
    {
        private string stringConnection = "Data Source=DESKTOP-TRA01FH;Database=coderhouse;Trusted_Connection=True;TrustServerCertificate=True;";
        public UsuarioData() { }
        public Usuario ObtenerUsuario(string nombreusuario)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM Usuario where nombreusuario = @nombreusuario";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("nombreusuario", nombreusuario);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["Id"]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string password = reader.GetString(4);
                    string mail = reader.GetString(5);
                    Usuario usuarionuevo = new(idObtenido, nombre, apellido, nombreUsuario, password, mail);
                    return usuarionuevo;
                }
                else
                {
                    throw new Exception("Id no encontrado");
                }
            }
        }
        public List<Usuario> ListarUsuarios()
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM Usuario";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Usuario> listaUsuarios = new List<Usuario>();
                while (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string password = reader.GetString(4);
                    string mail = reader.GetString(5);
                    Usuario usuarionuevo = new(idObtenido, nombre, apellido, nombreUsuario, password, mail);
                    listaUsuarios.Add(usuarionuevo);
                }
                return listaUsuarios;
            }
        }
        public bool CrearUsuario(Usuario user)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) values (@nombre,@apellido,@nombreUsuario,@contrasena,@mail)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("nombre", user.Nombre);
                cmd.Parameters.AddWithValue("apellido", user.Apellido);
                cmd.Parameters.AddWithValue("nombreUsuario", user.NombreUsuario);
                cmd.Parameters.AddWithValue("contrasena", user.Contrasena);
                cmd.Parameters.AddWithValue("mail", user.Mail);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool ModificarUsuario(int id, Usuario user)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "UPDATE Usuario SET Nombre = @nombre,Apellido = @apellido,NombreUsuario = @nombreUsuario,Contraseña = @contrasena,Mail = @mail WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("nombre", user.Nombre);
                cmd.Parameters.AddWithValue("apellido", user.Apellido);
                cmd.Parameters.AddWithValue("nombreUsuario", user.NombreUsuario);
                cmd.Parameters.AddWithValue("contrasena", user.Contrasena);
                cmd.Parameters.AddWithValue("mail", user.Mail);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool EliminarUsuario(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE FROM Usuario WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
