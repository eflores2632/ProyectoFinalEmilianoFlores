using IntegrandoApi.Models;
using Microsoft.Data.SqlClient;
namespace IntegrandoApi.Database
{
    public class ProductoData
    {
        private string stringConnection = "Data Source=DESKTOP-TRA01FH;Database=coderhouse;Trusted_Connection=True;TrustServerCertificate=True;";
        public ProductoData() { }
        public Producto ObtenerProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM Producto where id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["Id"]);
                    string descripciones = reader.GetString(1);
                    decimal costo = reader.GetDecimal(2);
                    decimal precioventa = reader.GetDecimal(3);
                    int stock = Convert.ToInt32(reader["Stock"]);
                    int idusuario = Convert.ToInt32(reader["IdUsuario"]);
                    Producto productonuevo = new(idObtenido, descripciones, costo, precioventa, stock, idusuario);
                    return productonuevo;
                }
                else
                {
                    throw new Exception("Id no encontrado");
                }
            }
        }
        public List<Producto> ListarProductos()
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "SELECT * FROM Producto";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Producto> listaProductos = new List<Producto>();
                while (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string descripciones = reader.GetString(1);
                    decimal costo = reader.GetDecimal(2);
                    decimal precioventa = reader.GetDecimal(3);
                    int stock = Convert.ToInt32(reader["Stock"]);
                    int idusuario = Convert.ToInt32(reader["IdUsuario"]);
                    Producto productonuevo = new(idObtenido, descripciones, costo, precioventa, stock, idusuario);
                    listaProductos.Add(productonuevo);
                }
                return listaProductos;
            }
        }
        public bool CrearProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-TRA01FH;Database=coderhouse;Trusted_Connection=True;"))
            {
                string query = "INSERT INTO Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario) values (@descripciones,@costo,@precioVenta,@stock,@idUsuario)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("descripciones", producto.Descripciones);
                cmd.Parameters.AddWithValue("costo", producto.Costo);
                cmd.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("stock", producto.Stock);
                cmd.Parameters.AddWithValue("idUsuario", producto.IdUsuario);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool ModificarProducto(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "UPDATE Producto SET Descripciones = @descripciones,Costo = @costo,PrecioVenta = @precioVenta,Stock = @stock,IdUsuario = @idUsuario WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("descripciones", producto.Descripciones);
                cmd.Parameters.AddWithValue("costo", producto.Costo);
                cmd.Parameters.AddWithValue("precioVenta", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("stock", producto.Stock);
                cmd.Parameters.AddWithValue("idUsuario", producto.IdUsuario);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool EliminarProducto(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "DELETE FROM Producto WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
