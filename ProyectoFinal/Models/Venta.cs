using System.Text.Json.Serialization;

namespace IntegrandoApi.Models
{

    public class Venta
    {
        private int id;
        private int idUsuario;
        private string comentarios;
        public Venta(string comentarios, int idUsuario)
        {
            this.comentarios = comentarios;
            this.idUsuario = idUsuario;
        }
        [JsonConstructorAttribute]
        public Venta(int id, string comentarios, int idUsuario) : this(comentarios, idUsuario)
        {
            this.id = id;
        }
        public int Id { get => id; set => id = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
    }
}