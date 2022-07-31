using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaAppService _categoriasAppService;

        public CategoriasController(ICategoriaAppService categoriasAppService)
        {
            _categoriasAppService = categoriasAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}