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
    public class VendasController : BaseController
    {
        private readonly IVendaAppService _vendaAppService;

        public VendasController(IVendaAppService vendaAppService)
        {
            _vendaAppService = vendaAppService;
        }

        /// <summary>
        /// Incluir Venda
        /// </summary>
        /// <remarks>
        /// # Incluir Venda
        /// 
        /// Incluir uma Venda na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /Venda
        ///     {
        ///         "IdUsuario": 1,    
        ///         "IdProduto": 1,    
        ///         "IdEndereco": 1,    
        ///         "TipoPagamento": "teste",    
        ///         "Valor": 1,    
        ///         "Quantidade": 1
        ///     }
        /// </remarks> 
        /// <param name="obj">Venda</param>        
        /// <response code="200">Venda incluida com sucesso</response>
        /// <response code="400">Venda não encontrada</response>
        [HttpPost]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Incluir([FromBody] Venda obj)
        {
            obj.CriadoPor = NomeUsuarioLogado;
            return Ok(_vendaAppService.Incluir(obj));
        }

        /// <summary>
        /// Consultar Venda
        /// </summary>
        /// <remarks>
        /// # Consultar Venda
        /// 
        /// Consulta uma Venda na base de dados.
        /// </remarks>
        /// <param name="id">Id da Venda</param>     
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma Venda</response>
        /// <response code="400">Venda não encontrado</response>
        [HttpGet("{id}", Name = "GetVenda")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id, bool getDependencies = false)
        {
            return Ok(_vendaAppService.Consultar(id, getDependencies));
        }

        /// <summary>
        /// Listar Vendas
        /// </summary>
        /// <remarks>
        /// # Listar Vendas
        /// 
        /// Lista Vendas da base de dados.
        /// </remarks>
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma lista de Vendas</response>
        /// <response code="400">Vendas não encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Listar(bool getDependencies = false)
        {
            return Ok(_vendaAppService.Listar(getDependencies));
        }

        /// <summary>
        /// Alterar Venda
        /// </summary>
        /// <remarks>
        /// # Alterar Venda
        /// 
        /// Altera uma Venda na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /Venda
        ///     {
        ///         "id": 1,
        ///         "IdUsuario": 1,    
        ///         "IdProduto": 1,    
        ///         "IdEndereco": 1,    
        ///         "TipoPagamento": "teste",    
        ///         "Valor": 1,    
        ///         "Quantidade": 1
        ///     }
        /// </remarks> 
        /// <param name="obj">Venda</param>        
        /// <response code="200">Venda alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        [HttpPut]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromBody] Venda obj)
        {
            obj.AlteradoPor = NomeUsuarioLogado;
            return Ok(_vendaAppService.Alterar(obj));
        }

        /// <summary>
        /// Remover Venda
        /// </summary>
        /// <remarks>
        /// # Remover Venda
        /// 
        /// Remove uma Venda da base de dados.
        /// </remarks>
        /// <param name="id">Id da Venda</param>        
        /// <response code="200">Venda removido com sucesso</response>
        /// <response code="400">Venda não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Remover(int id)
        {
            return Ok(_vendaAppService.Remover(id));
        }
    }
}