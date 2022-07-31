using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class EnderecosController : Controller
    {
        private readonly IEnderecoAppService _enderecoAppService;

        public EnderecosController(IEnderecoAppService enderecoAppService)
        {
            _enderecoAppService = enderecoAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}