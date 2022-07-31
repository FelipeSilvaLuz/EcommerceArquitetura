using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class CaracteristicasController : Controller
    {
        private readonly ICaracteristicaAppService _caracteristicaAppService;

        public CaracteristicasController(ICaracteristicaAppService caracteristicaAppService)
        {
            _caracteristicaAppService = caracteristicaAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}