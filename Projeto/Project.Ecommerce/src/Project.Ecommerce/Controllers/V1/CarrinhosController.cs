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
    public class CarrinhosController : BaseController
    {
        private readonly ICarrinhoAppService _carrinhosAppService;

        public CarrinhosController(ICarrinhoAppService carrinhosAppService)
        {
            _carrinhosAppService = carrinhosAppService;
        }

        /// <summary>
        /// Incluir Carrinho
        /// </summary>
        /// <remarks>
        /// # Alterar Carrinho
        /// 
        /// Incluir um Carrinho na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /Carrinho
        ///     {
        ///         "IdUsuario": 1,       
        ///         "IdProduto": 1,      
        ///         "Quantidade": 2        
        ///     }
        /// </remarks> 
        /// <param name="obj">Carrinho</param>        
        /// <response code="200">Carrinho incluido com sucesso</response>
        /// <response code="400">Carrinho não encontrado</response>
        [HttpPost]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Incluir([FromBody] Carrinho obj)
        {
            obj.CriadoPor = NomeUsuarioLogado;
            return Ok(_carrinhosAppService.Incluir(obj));
        }

        /// <summary>
        /// Consultar Carrinho
        /// </summary>
        /// <remarks>
        /// # Consultar Carrinho
        /// 
        /// Consulta um Carrinho na base de dados.
        /// </remarks>
        /// <param name="id">Id do Carrinho</param>     
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna um Carrinho</response>
        /// <response code="400">Carrinho não encontrado</response>
        [HttpGet("{id}", Name = "GetCarrinho")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id, bool getDependencies = false)
        {
            return Ok(_carrinhosAppService.Consultar(id, getDependencies));
        }

        /// <summary>
        /// Listar Carrinhos
        /// </summary>
        /// <remarks>
        /// # Listar Carrinhos
        /// 
        /// Lista Carrinhos da base de dados.
        /// </remarks>
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma lista de Carrinhos</response>
        /// <response code="400">Carrinhos não encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Listar(bool getDependencies = false)
        {
            return Ok(_carrinhosAppService.Listar(getDependencies));
        }

        /// <summary>
        /// Alterar Carrinho
        /// </summary>
        /// <remarks>
        /// # Alterar Carrinho
        /// 
        /// Altera um Carrinho na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /Carrinho
        ///     {
        ///         "id": 1,
        ///         "IdUsuario": 1,       
        ///         "IdProduto": 1,      
        ///         "Quantidade": 2      
        ///     }
        /// </remarks> 
        /// <param name="obj">Carrinho</param>        
        /// <response code="200">Carrinho alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        [HttpPut]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromBody] Carrinho obj)
        {
            obj.AlteradoPor = NomeUsuarioLogado;
            return Ok(_carrinhosAppService.Alterar(obj));
        }

        /// <summary>
        /// Remover Carrinho
        /// </summary>
        /// <remarks>
        /// # Remover Carrinho
        /// 
        /// Remove um Carrinho da base de dados.
        /// </remarks>
        /// <param name="id">Id do Carrinho</param>        
        /// <response code="200">Carrinho removido com sucesso</response>
        /// <response code="400">Carrinho não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Remover(int id)
        {
            return Ok(_carrinhosAppService.Remover(id));
        }
    }
}