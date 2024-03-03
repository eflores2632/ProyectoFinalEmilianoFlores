using IntegrandoApi.Models;
using IntegrandoApi.Services;
using Microsoft.AspNetCore.Mvc;
namespace IntegrandoApi.Controllers
{
    [ApiController]
    [Route("api/Venta/")]
    public class VentaController : Controller
    {
        private VentaService Vservice;
        public VentaController(VentaService vservice)
        {
            this.Vservice = vservice;
        }
        [HttpGet]
        [Route("{idusuario}")]
        public ActionResult<List<Venta>> ObtenerVentas(int idusuario)
        {
            return this.Vservice.ListarVentas(idusuario);
        }

        [HttpPost]
        [Route("{idusuario}")]
        public ActionResult CrearVenta(int idusuario, [FromBody] List<Producto> productos)
        {
            try
            {
                this.Vservice.CrearVenta(idusuario, productos);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
