using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class TiposPagamentosController : Controller
    {
        private readonly ITipoPagamentoAppService _tipospagamentosAppService;

        public TiposPagamentosController(ITipoPagamentoAppService tipospagamentosAppService)
        {
            _tipospagamentosAppService = tipospagamentosAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}