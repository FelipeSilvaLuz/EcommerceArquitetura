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
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        /// <summary>
        /// Incluir Produto
        /// </summary>
        /// <remarks>
        /// # Incluir Produto
        /// 
        /// Incluir um Produto na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /Produto
        ///     {
        ///         "IdCategoria": 1,    
        ///         "IdVariacao": 1,    
        ///         "Nome": "teste",    
        ///         "Descricao": "teste Complemento",    
        ///         "Quantidade": 2,    
        ///         "Valor": 0.0   
        ///     }
        /// </remarks> 
        /// <param name="obj">Produto</param>        
        /// <response code="200">Produto incluido com sucesso</response>
        /// <response code="400">Produto não encontrado</response>
        [HttpPost]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Incluir([FromBody] Produto obj)
        {
            return Ok(_produtoAppService.Incluir(obj));
        }

        /// <summary>
        /// Consultar Produto
        /// </summary>
        /// <remarks>
        /// # Consultar Produto
        /// 
        /// Consulta um Produto na base de dados.
        /// </remarks>
        /// <param name="id">Id do Produto</param>     
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna um Produto</response>
        /// <response code="400">Produto não encontrado</response>
        [HttpGet("{id}", Name = "GetProduto")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id, bool getDependencies = false)
        {
            return Ok(_produtoAppService.Consultar(id, getDependencies));
        }

        /// <summary>
        /// Listar Produtos
        /// </summary>
        /// <remarks>
        /// # Listar Produtos
        /// 
        /// Lista Produtos da base de dados.
        /// </remarks>
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma lista de Produtos</response>
        /// <response code="400">Produtos não encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Listar(bool getDependencies = false)
        {
            return Ok(_produtoAppService.Listar(getDependencies));
        }

        /// <summary>
        /// Alterar Produto
        /// </summary>
        /// <remarks>
        /// # Alterar Produto
        /// 
        /// Altera um Produto na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /Produto
        ///     {
        ///         "id": 1,
        ///         "IdCategoria": 1,    
        ///         "IdVariacao": 1,    
        ///         "Nome": "teste",    
        ///         "Descricao": "teste Complemento",    
        ///         "Quantidade": 2,    
        ///         "Valor": 0.0   
        ///     }
        /// </remarks> 
        /// <param name="obj">Produto</param>        
        /// <response code="200">Produto alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        [HttpPut]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromBody] Produto obj)
        {
            return Ok(_produtoAppService.Alterar(obj));
        }

        /// <summary>
        /// Remover Produto
        /// </summary>
        /// <remarks>
        /// # Remover Produto
        /// 
        /// Remove um Produto da base de dados.
        /// </remarks>
        /// <param name="id">Id do Produto</param>        
        /// <response code="200">Produto removido com sucesso</response>
        /// <response code="400">Produto não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Remover(int id)
        {
            return Ok(_produtoAppService.Remover(id));
        }
    }
}