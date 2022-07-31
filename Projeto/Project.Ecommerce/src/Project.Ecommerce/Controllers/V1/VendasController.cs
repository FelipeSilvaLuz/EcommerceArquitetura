using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class VendasController : Controller
    {
        private readonly IVendaAppService _vendaAppService;

        public VendasController(IVendaAppService vendaAppService)
        {
            _vendaAppService = vendaAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}