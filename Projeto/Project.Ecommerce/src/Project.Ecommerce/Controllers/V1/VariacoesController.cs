using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class VariacoesController : Controller
    {
        private readonly IVariacaoAppService _variacaoppservice;

        public VariacoesController(IVariacaoAppService variacaoAppService)
        {
            _variacaoppservice = variacaoAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}