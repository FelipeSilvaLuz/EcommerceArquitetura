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
    public class BancosController : Controller
    {
        private readonly IBancoAppService _bancoAppService;

        public BancosController(IBancoAppService bancoAppService)
        {
            _bancoAppService = bancoAppService;
        }

        /// <summary>
        /// Incluir Banco
        /// </summary>
        /// <remarks>
        /// # Alterar Banco
        /// 
        /// Incluir um Banco na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /Banco
        ///     {
        ///         "id": 1,
        ///         "Nome": "teste nome"        
        ///     }
        /// </remarks> 
        /// <param name="obj">Banco</param>        
        /// <response code="200">Banco incluido com sucesso</response>
        /// <response code="400">Banco não encontrado</response>
        [HttpPost]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Incluir([FromBody] Banco obj)
        {
            return Ok(_bancoAppService.Incluir(obj));
        }

        /// <summary>
        /// Consultar Banco
        /// </summary>
        /// <remarks>
        /// # Consultar Banco
        /// 
        /// Consulta um Banco na base de dados.
        /// </remarks>
        /// <param name="id">Id do Banco</param>     
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna um Banco</response>
        /// <response code="400">Banco não encontrado</response>
        [HttpGet("{id}", Name = "GetBanco")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id, bool getDependencies = false)
        {
            return Ok(_bancoAppService.Consultar(id, getDependencies));
        }

        /// <summary>
        /// Listar Bancos
        /// </summary>
        /// <remarks>
        /// # Listar Bancos
        /// 
        /// Lista Bancos da base de dados.
        /// </remarks>
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma lista de Bancos</response>
        /// <response code="400">Bancos não encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Listar(bool getDependencies = false)
        {
            return Ok(_bancoAppService.Listar(getDependencies));
        }

        /// <summary>
        /// Alterar Banco
        /// </summary>
        /// <remarks>
        /// # Alterar Banco
        /// 
        /// Altera um Banco na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /Banco
        ///     {
        ///         "id": 1,
        ///         "Nome": "teste nome"        
        ///     }
        /// </remarks> 
        /// <param name="obj">Banco</param>        
        /// <response code="200">Banco alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromBody] Banco obj)
        {
            return Ok(_bancoAppService.Alterar(obj));
        }

        /// <summary>
        /// Remover Banco
        /// </summary>
        /// <remarks>
        /// # Remover Banco
        /// 
        /// Remove um Banco da base de dados.
        /// </remarks>
        /// <param name="id">Id do Banco</param>        
        /// <response code="200">Banco removido com sucesso</response>
        /// <response code="400">Banco não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Remover(int id)
        {
            return Ok(_bancoAppService.Remover(id));
        }
    }
}