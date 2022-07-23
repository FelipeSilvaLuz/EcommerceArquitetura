using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    public class BancosController : Controller
    {
        private readonly ITiposPagamentosAppService _tipospagamentosappservice;

        public BancosController(ITiposPagamentosAppService tipospagamentosappservice)
        {
            _tipospagamentosappservice = tipospagamentosappservice;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}