using IntegrandoApi.Database;
using IntegrandoApi.Models;

namespace IntegrandoApi.Services
{
    public class VentaService
    {
        private VentaData Vdata;
        private ProductoService ProductoService;
        private ProductoVendidoService ProductoVendidoService;
        public VentaService(VentaData vdata, ProductoService productoservice, ProductoVendidoService ProductoVendidoService)
        {
            this.Vdata = vdata;
            this.ProductoService = productoservice;
            this.ProductoVendidoService = ProductoVendidoService;
        }
        public Venta ObtenerVenta(int id)
        {
            return this.Vdata.ObtenerVenta(id);
        }
        public List<Venta> ListarVentas(int idusuario)
        {
            IEnumerable<Venta> ventas = this.Vdata.ListarVentas();
            IEnumerable<Venta> ventasseleccionadas = from v in ventas where v.IdUsuario == idusuario select v;
            return ventasseleccionadas.ToList();
        }
        public bool CrearVenta(int idusuario, List<Producto> productos)
        {
            List<string> nombres = productos.Select(p => p.Descripciones).ToList();
            string comentario = string.Join(", ", nombres);
            Venta venta = new Venta(comentario, idusuario);
            int idventa = this.Vdata.CrearVentaConID(venta);
            try
            {
                foreach (var p in productos)
                {
                    Producto? productoactual = this.ProductoService.ObtenerProductoporid(p.Id);
                    if (productoactual is null)
                    {
                        throw new Exception("El producto no se encontro");
                    }
                    else
                    {
                        if (productoactual.Stock <= p.Stock)
                        {
                            throw new Exception("No hay suficiente stock");
                        }
                        else
                        {
                            productoactual.Stock -= p.Stock;
                            this.ProductoService.ModificarProducto(productoactual.Id, productoactual);
                        }
                    }
                }
                foreach (var p in productos)
                {
                    ProductoVendido pv = new ProductoVendido(p.Id, p.Stock, idventa);
                    this.ProductoVendidoService.CrearProductoVendido(pv);
                }
            }
            catch (Exception ex)
            {
                this.Vdata.EliminarVenta(idventa);
                throw new Exception(ex.Message);
            }

            return true;
        }
        public bool ModificarVenta(int id, Venta venta)
        {
            return this.Vdata.ModificarVenta(id, venta);
        }
        public bool EliminarVenta(int id)
        {
            return this.Vdata.EliminarVenta(id);
        }
    }
}
