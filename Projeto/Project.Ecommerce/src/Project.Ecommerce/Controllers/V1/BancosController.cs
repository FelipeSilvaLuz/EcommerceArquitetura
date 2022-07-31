using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class BancosController : Controller
    {
        private readonly IBancoAppService _bancoAppService;

        public BancosController(IBancoAppService bancoAppService)
        {
            _bancoAppService = bancoAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}