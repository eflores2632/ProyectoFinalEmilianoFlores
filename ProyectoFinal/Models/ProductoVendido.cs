using System.Text.Json.Serialization;

namespace IntegrandoApi.Models
{
    public class ProductoVendido
    {
        private int id;
        private int idProducto;
        private int stock;
        private int idVenta;
        public ProductoVendido(int idProducto, int stock, int idVenta)
        {
            this.idProducto = idProducto;
            this.stock = stock;
            this.idVenta = idVenta;
        }
        [JsonConstructorAttribute]
        public ProductoVendido(int id, int idProducto, int stock, int idVenta) : this(idProducto, stock, idVenta)
        {
            this.id = id;
        }
        public int Id { get => id; set => id = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Stock { get => stock; set => stock = value; }
        public int IdVenta { get => idVenta; set => idVenta = value; }
    }
}
