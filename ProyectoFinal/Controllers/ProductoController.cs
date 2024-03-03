using IntegrandoApi.Models;
using IntegrandoApi.Services;
using Microsoft.AspNetCore.Mvc;
namespace IntegrandoApi.Controllers
{
    [ApiController]
    [Route("api/Producto/")]
    public class ProductoController : Controller
    {
        private ProductoService Pservice;
        public ProductoController(ProductoService pservice)
        {
            this.Pservice = pservice;
        }
        [HttpGet]
        [Route("{idusuario}")]
        public ActionResult<List<Producto>> ObtenerProducto(int idusuario)
        {
            if (idusuario < 0)
            {
                return BadRequest();
            }
            else
            {
                return this.Pservice.ObtenerProducto(idusuario);
            }
        }
        [HttpPost]
        public ActionResult CrearProducto([FromBody] Producto product)
        {
            try
            {
                if (this.Pservice.CrearProducto(product))
                {
                    return Ok();
                }
                return Ok();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return BadRequest(); }
        }
        [HttpPut]
        public ActionResult ModificarProducto([FromBody] Producto product)
        {
            if (this.Pservice.ModificarProducto(product.Id, product))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("{idproducto}")]
        public ActionResult EliminarProducto(int idproducto)
        {
            if (this.Pservice.EliminarProducto(idproducto))
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
