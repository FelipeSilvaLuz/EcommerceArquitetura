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
    public class EnderecosController : BaseController
    {
        private readonly IEnderecoAppService _enderecoAppService;

        public EnderecosController(IEnderecoAppService enderecoAppService)
        {
            _enderecoAppService = enderecoAppService;
        }

        /// <summary>
        /// Incluir Endereco
        /// </summary>
        /// <remarks>
        /// # Alterar Endereco
        /// 
        /// Incluir um Endereco na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     POST /Endereco
        ///     {
        ///         "IdUsuario": 1,    
        ///         "NomeEndereco": "teste nome",    
        ///         "Numero": "123",    
        ///         "Complemento": "teste Complemento",    
        ///         "Cep": "teste Cep",    
        ///         "Cidade": "teste Cidade",    
        ///         "Bairro": "teste Bairro",    
        ///         "Estado": "teste Estado",    
        ///         "Referencia": "teste Referencia"    
        ///     }
        /// </remarks> 
        /// <param name="obj">Endereco</param>        
        /// <response code="200">Endereco incluido com sucesso</response>
        /// <response code="400">Endereco não encontrado</response>
        [HttpPost]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Incluir([FromBody] Endereco obj)
        {
            obj.CriadoPor = NomeUsuarioLogado;
            return Ok(_enderecoAppService.Incluir(obj));
        }

        /// <summary>
        /// Consultar Endereco
        /// </summary>
        /// <remarks>
        /// # Consultar Endereco
        /// 
        /// Consulta um Endereco na base de dados.
        /// </remarks>
        /// <param name="id">Id do Endereco</param>     
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna um Endereco</response>
        /// <response code="400">Endereco não encontrado</response>
        [HttpGet("{id}", Name = "GetEndereco")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Consultar(int id, bool getDependencies = false)
        {
            return Ok(_enderecoAppService.Consultar(id, getDependencies));
        }

        /// <summary>
        /// Listar Enderecos
        /// </summary>
        /// <remarks>
        /// # Listar Enderecos
        /// 
        /// Lista Enderecos da base de dados.
        /// </remarks>
        /// <param name="getDependencies">Listar dependências do objeto</param> 
        /// <response code="200">Retorna uma lista de Enderecos</response>
        /// <response code="400">Enderecos não encontrados</response>
        [HttpGet]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Listar(bool getDependencies = false)
        {
            return Ok(_enderecoAppService.Listar(getDependencies));
        }

        /// <summary>
        /// Alterar Endereco
        /// </summary>
        /// <remarks>
        /// # Alterar Endereco
        /// 
        /// Altera um Endereco na base de dados.
        /// 
        /// # Sample request:
        ///
        ///     PUT /Endereco
        ///     {
        ///         "id": 1,
        ///         "NomeEndereco": "teste nome",    
        ///         "Numero": "123",    
        ///         "Complemento": "teste Complemento",    
        ///         "Cep": "teste Cep",    
        ///         "Cidade": "teste Cidade",    
        ///         "Bairro": "teste Bairro",    
        ///         "Estado": "teste Estado",    
        ///         "Referencia": "teste Referencia"    
        ///     }
        /// </remarks> 
        /// <param name="obj">Endereco</param>        
        /// <response code="200">Endereco alterado com sucesso</response>
        /// <response code="400">ID informado não é válido</response>
        [HttpPut]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Alterar([FromBody] Endereco obj)
        {
            obj.AlteradoPor = NomeUsuarioLogado;
            return Ok(_enderecoAppService.Alterar(obj));
        }

        /// <summary>
        /// Remover Endereco
        /// </summary>
        /// <remarks>
        /// # Remover Endereco
        /// 
        /// Remove um Endereco da base de dados.
        /// </remarks>
        /// <param name="id">Id do Endereco</param>        
        /// <response code="200">Endereco removido com sucesso</response>
        /// <response code="400">Endereco não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoGenerico), StatusCodes.Status400BadRequest)]
        public IActionResult Remover(int id)
        {
            return Ok(_enderecoAppService.Remover(id));
        }
    }
}