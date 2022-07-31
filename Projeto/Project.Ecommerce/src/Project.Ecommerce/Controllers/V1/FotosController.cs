using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class FotosController : Controller
    {
        private readonly IFotoAppService _fotoAppService;

        public FotosController(IFotoAppService fotoAppService)
        {
            _fotoAppService = fotoAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}