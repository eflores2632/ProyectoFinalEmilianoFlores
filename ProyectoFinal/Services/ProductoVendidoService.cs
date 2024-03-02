using IntegrandoApi.Database;
using IntegrandoApi.Models;

namespace IntegrandoApi.Services
{
    public class ProductoVendidoService
    {
        private ProductoVendidoData PVdata;
        private VentaData VentaData;
        public ProductoVendidoService(ProductoVendidoData pvdata, VentaData vdata)
        {
            this.PVdata = pvdata;
            this.VentaData = vdata;
        }
        public List<ProductoVendido> ObtenerProductoVendido(int idusuario)
        {
            IEnumerable<ProductoVendido> productosvendidos = this.PVdata.ListarPrductosVendidos();
            IEnumerable<Venta> ventas = this.VentaData.ListarVentas();
            IEnumerable<Venta> ventasselesccionadas = from v in ventas where v.IdUsuario == idusuario select v;
            IEnumerable<ProductoVendido> seleccionados = from vs in ventasselesccionadas
                                                         join pv in productosvendidos on vs.Id equals pv.IdVenta
                                                         select pv;

            return seleccionados.ToList();
        }
        public List<ProductoVendido> ListarPrductosVendidos()
        {
            return this.PVdata.ListarPrductosVendidos();
        }
        public bool CrearProductoVendido(ProductoVendido productovendido)
        {
            return this.PVdata.CrearProductoVendido(productovendido);
        }
        public bool ModificarProductoVendido(int id, ProductoVendido productovendido)
        {
            return this.PVdata.ModificarProductoVendido(id, productovendido);
        }
        public bool EliminarProductoVendido(int id)
        {
            return this.PVdata.EliminarProductoVendido(id);
        }
    }
}
