using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class CarrinhosController : Controller
    {
        private readonly ICarrinhoAppService _carrinhosAppService;

        public CarrinhosController(ICarrinhoAppService carrinhosAppService)
        {
            _carrinhosAppService = carrinhosAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}