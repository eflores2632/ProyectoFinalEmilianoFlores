using IntegrandoApi.Models;
using IntegrandoApi.Services;
using Microsoft.AspNetCore.Mvc;
namespace IntegrandoApi.Controllers
{
    [ApiController]
    [Route("api/")]
    public class VentaController : Controller
    {
        private VentaService Vservice;
        public VentaController(VentaService vservice)
        {
            this.Vservice = vservice;
        }
        [HttpGet]
        [Route("obtenerventa/{id}")]
        public ActionResult<Venta> ObtenerVenta(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            else
            {
                return this.Vservice.ObtenerVenta(id);
            }
        }
        [HttpGet]
        [Route("listarventas")]
        public ActionResult<List<Venta>> ObtenerVentas()
        {
            return this.Vservice.ListarVentas();
        }
        [HttpPost]
        [Route("crearventa")]
        public ActionResult CrearVenta([FromBody] Venta venta)
        {
            try
            {
                if (this.Vservice.CrearVenta(venta))
                {
                    return Ok();
                }
                else { return BadRequest(); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return BadRequest(); }
        }
        [HttpPut]
        [Route("modificarventa")]
        public ActionResult ModificarVenta([FromBody] Venta venta)
        {
            if (this.Vservice.ModificarVenta(venta.Id, venta))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("eliminarventa/{id}")]
        public ActionResult EliminarVenta(int id)
        {
            if (this.Vservice.EliminarVenta(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
