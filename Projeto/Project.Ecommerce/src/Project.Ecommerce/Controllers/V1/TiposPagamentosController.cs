using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class TiposPagamentosController : Controller
    {
        private readonly ITipoPagamentoAppService _tipospagamentosAppService;

        public TiposPagamentosController(ITipoPagamentoAppService tipospagamentosAppService)
        {
            _tipospagamentosAppService = tipospagamentosAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}