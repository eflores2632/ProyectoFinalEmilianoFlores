using IntegrandoApi.Models;
using Microsoft.Data.SqlClient;
namespace IntegrandoApi.Database
{
    public class ProductoVendidoData
    {
        private string stringConnection = "Data Source=DESKTOP-TRA01FH;Database=coderhouse;Trusted_Connection=True;TrustServerCertificate=True;";
        public ProductoVendidoData() { }
        public ProductoVendido ObtenerProductoVendido(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM ProductoVendido where id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["Id"]);
                    int idproducto = Convert.ToInt32(reader["IdProducto"]);
                    int stock = Convert.ToInt32(reader["Stock"]);
                    int idventa = Convert.ToInt32(reader["IdVenta"]);
                    ProductoVendido productonuevo = new ProductoVendido(idObtenido, idproducto, stock, idventa);
                    return productonuevo;
                }
                else
                {
                    throw new Exception("Id no encontrado");
                }
            }
        }
        public List<ProductoVendido> ListarPrductosVendidos()
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM ProductoVendido";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ProductoVendido> listaproductosnuevos = new List<ProductoVendido>();
                while (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["Id"]);
                    int idproducto = Convert.ToInt32(reader["IdProducto"]);
                    int stock = Convert.ToInt32(reader["Stock"]);
                    int idventa = Convert.ToInt32(reader["IdVenta"]);
                    ProductoVendido productovendidonuevo = new(idObtenido, idproducto, stock, idventa);
                    listaproductosnuevos.Add(productovendidonuevo);
                }
                return listaproductosnuevos;
            }
        }
        public bool CrearProductoVendido(ProductoVendido productovendido)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta) values (@stock,@idproducto,@idventa)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("Stock", productovendido.Stock);
                cmd.Parameters.AddWithValue("IdProducto", productovendido.IdProducto);
                cmd.Parameters.AddWithValue("IdVenta", productovendido.IdVenta);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool ModificarProductoVendido(int id, ProductoVendido productovendido)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "UPDATE Producto SET Stock = @stock,IdProducto = @idproducto,IdVenta = @idventa WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("stock", productovendido.Stock);
                cmd.Parameters.AddWithValue("idproducto", productovendido.IdProducto);
                cmd.Parameters.AddWithValue("idventa", productovendido.IdVenta);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool EliminarProductoVendido(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE FROM ProductoVendido WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
