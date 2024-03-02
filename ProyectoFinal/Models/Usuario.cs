using System.Text.Json.Serialization;

namespace IntegrandoApi.Models
{

    public class Usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string nombreUsuario;
        private string contrasena;
        private string mail;

        public Usuario(string nombre, string apellido, string nombreUsuario, string contrasena, string mail)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nombreUsuario = nombreUsuario;
            this.contrasena = contrasena;
            this.mail = mail;
        }
        [JsonConstructorAttribute]
        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string contrasena, string mail) : this(nombre, apellido, nombreUsuario, contrasena, mail)
        {
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Mail { get => mail; set => mail = value; }
    }
}