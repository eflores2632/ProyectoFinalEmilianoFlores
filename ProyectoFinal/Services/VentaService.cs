using IntegrandoApi.Database;
using IntegrandoApi.Models;

namespace IntegrandoApi.Services
{
    public class VentaService
    {
        private VentaData Vdata;
        public VentaService(VentaData vdata)
        {
            this.Vdata = vdata;
        }
        public Venta ObtenerVenta(int id)
        {
            return this.Vdata.ObtenerVenta(id);
        }
        public List<Venta> ListarVentas()
        {
            return this.Vdata.ListarVentas();
        }
        public bool CrearVenta(Venta venta)
        {
            return this.Vdata.CrearVenta(venta);
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
