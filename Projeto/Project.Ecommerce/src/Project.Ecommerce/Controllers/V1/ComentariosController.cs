using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;

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
        /// <summary>
        /// Incluir Comentario
        /// </summary>
        /// <remarks>
        /// # Alterar Comentario
        /// 
        /// Incluir um Comentario na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /Comentario
        ///     {
        ///         "IdProduto" : 1,
        ///         "Titulo" : "teste titulo",
        ///         "Texto" : "teste texto",
        ///         "Nota": 1
        ///     }
        /// </remarks> 
        /// <param name="obj">Comentario</param>        
        /// <response code="200">Comentario incluido com sucesso</response>
        /// <response code="400">Comentario não encontrado</response>
        [HttpPost]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Incluir([FromBody] Comentario obj)
        {
            return Ok(_comentarioAppService.Incluir(obj));
        }

        /// <summary>
        /// Consultar Comentario
        /// </summary>
        /// <remarks>
        /// # Consultar Comentario
        /// 
        /// Consulta um Comentario na base de dados.
        /// </remarks>
        /// <param name="id">Id do Comentario</param>     
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna um Comentario</response>
        /// <response code="400">Comentario não encontrado</response>
        [HttpGet("{id}", Name = "GetComentario")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id, bool getDependencies = false)
        {
            return Ok(_comentarioAppService.Consultar(id, getDependencies));
        }

        /// <summary>
        /// Listar Comentarios
        /// </summary>
        /// <remarks>
        /// # Listar Comentarios
        /// 
        /// Lista Comentarios da base de dados.
        /// </remarks>
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma lista de Comentarios</response>
        /// <response code="400">Comentarios não encontradas</response>
        [HttpGet]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Listar(bool getDependencies = false)
        {
            return Ok(_comentarioAppService.Listar(getDependencies));
        }

        /// <summary>
        /// Alterar Comentario
        /// </summary>
        /// <remarks>
        /// # Alterar Comentario
        /// 
        /// Altera um Comentario na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /Comentario
        ///     {
        ///         "id": 1,
        ///         "IdProduto" : 1,
        ///         "Titulo" : "teste titulo",
        ///         "Texto" : "teste texto",
        ///         "Nota": 1  
        ///     }
        /// </remarks> 
        /// <param name="obj">Comentario</param>        
        /// <response code="200">Comentario alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        [HttpPut]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromBody] Comentario obj)
        {
            return Ok(_comentarioAppService.Alterar(obj));
        }

        /// <summary>
        /// Remover Comentario
        /// </summary>
        /// <remarks>
        /// # Remover Comentario
        /// 
        /// Remove um Comentario da base de dados.
        /// </remarks>
        /// <param name="id">Id do Comentario</param>        
        /// <response code="200">Comentario removido com sucesso</response>
        /// <response code="400">Comentario não encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Remover(int id)
        {
            return Ok(_comentarioAppService.Remover(id));
        }
    }
}