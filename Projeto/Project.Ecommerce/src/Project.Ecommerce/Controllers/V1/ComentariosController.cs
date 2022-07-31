using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;

namespace Project.Ecommerce.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class ComentariosController : Controller
    {
        private readonly IComentarioAppService _comentarioAppService;

        public ComentariosController(IComentarioAppService comentarioAppService)
        {
            _comentarioAppService = comentarioAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}