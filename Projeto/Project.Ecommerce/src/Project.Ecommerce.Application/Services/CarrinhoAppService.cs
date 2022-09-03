using Microsoft.Extensions.Options;
using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.CrossCutting.Settings;
using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Project.Ecommerce.Application.Services
{
    public class CarrinhoAppService : ICarrinhoAppService
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly TextoSettings _textoSettings;

        public CarrinhoAppService(
            ICarrinhoRepository carrinhoRepository,
            IOptions<TextoSettings> options)
        {
            _carrinhoRepository = carrinhoRepository;
            _textoSettings = options.Value;
        }

        public RetornoGenerico Incluir(Carrinho dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _carrinhoRepository.Incluir(dados);
            _carrinhoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroIncluido });
        }

        public RetornoGenerico Alterar(Carrinho dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            var retorno = _carrinhoRepository.Consultar(dados.Id);
            retorno.Quantidade = dados.Quantidade;

            _carrinhoRepository.Alterar(retorno);
            _carrinhoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroAlterado });
        }

        public Carrinho Consultar(int id, bool getDependencies)
        {
            return _carrinhoRepository.Consultar(id, getDependencies);
        }

        public List<Carrinho> Listar(bool getDependencies)
        {
            return _carrinhoRepository.Listar(getDependencies).ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_carrinhoRepository.Remover(id))
            {
                _carrinhoRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { _textoSettings.Removido });
            }
            else
                return new RetornoGenerico(false, new List<string> { _textoSettings.ErroRemover });
        }

        public RetornoGenerico ValidarCampos(Carrinho dados)
        {
            List<string> mensagens = new List<string>();

            if (dados.IdProduto == 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Produto));

            if (dados.IdUsuario == 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Usuario));

            if (dados.Quantidade == 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Quantidade));

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}