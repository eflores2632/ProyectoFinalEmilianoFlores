using Microsoft.AspNetCore.Mvc;
namespace IntegrandoApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class NombreController : Controller
    {
        [HttpGet]
        public string Nombre()
        {
            return "Emiliano Flores";
        }
    }
}
