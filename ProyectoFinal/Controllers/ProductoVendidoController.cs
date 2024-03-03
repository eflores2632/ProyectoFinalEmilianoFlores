using IntegrandoApi.Models;
using IntegrandoApi.Services;
using Microsoft.AspNetCore.Mvc;
namespace IntegrandoApi.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductoVendidoController : Controller
    {
        private ProductoVendidoService PVService;
        public ProductoVendidoController(ProductoVendidoService pvService)
        {
            this.PVService = pvService;
        }
        [HttpGet]
        [Route("obtenerproductovendidos/{idusuario}")]
        public ActionResult<List<ProductoVendido>> ObtenerProducto(int idusuario)
        {
            if (idusuario < 0)
            {
                return BadRequest("El id de usuario no puede ser negativo");
            }
            else
            {
                return this.PVService.ObtenerProductoVendido(idusuario);
            }
        }
    }
}
