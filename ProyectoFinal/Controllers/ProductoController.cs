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
                return BadRequest("El id de usuario no puede ser nulo");
            }
            else
            {
                return this.Pservice.ObtenerProducto(idusuario);
            }
        }
        [HttpPost]
        public ActionResult CrearProducto([FromBody] Producto product)
        {

            if (this.Pservice.CrearProducto(product))
            {
                return Ok();
            }
            else
            {
                return BadRequest("No se pudo crear el producto");
            }
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
                return BadRequest("No se pudo modificar el producto");
            }
        }
        [HttpDelete]
        [Route("{idproducto}")]
        public ActionResult EliminarProducto(int idproducto)
        {
            if (idproducto < 0)
            {
                return BadRequest("El id del prducto no puede ser negativo");
            }
            else
            {
                if (this.Pservice.EliminarProducto(idproducto))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("No se pudo eliminar el producto");
                }
            }
        }
    }
}
