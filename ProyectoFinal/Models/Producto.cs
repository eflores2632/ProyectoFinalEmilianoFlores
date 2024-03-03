using System.Text.Json.Serialization;

namespace IntegrandoApi.Models
{
    public class Producto
    {
        private int id;
        private string descripciones;
        private decimal costo;
        private decimal precioVenta;
        private int stock;
        private int idUsuario;

        public Producto(string descripciones, decimal costo, decimal precioVenta, int stock, int idUsuario)
        {
            this.descripciones = descripciones;
            this.costo = costo;
            this.precioVenta = precioVenta;
            this.stock = stock;
            this.idUsuario = idUsuario;
        }
        [JsonConstructorAttribute]
        public Producto(int id, string descripciones, decimal costo, decimal precioVenta, int stock, int idUsuario) : this(descripciones, costo, precioVenta, stock, idUsuario)
        {
            this.id = id;
        }
        public int Id { get => id; set => id = value; }
        public string Descripciones { get => descripciones; set => descripciones = value; }
        public decimal Costo { get => costo; set => costo = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Stock { get => stock; set => stock = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}