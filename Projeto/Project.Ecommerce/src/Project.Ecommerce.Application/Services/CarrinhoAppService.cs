using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Ecommerce.Application.Services
{
    public class CarrinhoAppService : ICarrinhoAppService
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        public CarrinhoAppService(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        public RetornoGenerico Incluir(Carrinho dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _carrinhoRepository.Incluir(dados);
            _carrinhoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { "Registro incluido com sucesso." });
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
            return new RetornoGenerico(true, new List<string> { "Registro alterado com sucesso." });
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
                return new RetornoGenerico(true, new List<string> { "Removido com sucesso" });
            }
            else
                return new RetornoGenerico(false, new List<string> { "Erro ao remover" });
        }

        public RetornoGenerico ValidarCampos(Carrinho dados)
        {
            List<string> mensagens = new List<string>();

            if (dados.IdProduto == 0)
                mensagens.Add("Informe um Produto para continuar.");

            if (dados.IdUsuario == 0)
                mensagens.Add("Informe um Usuário para continuar.");

            if (dados.Quantidade == 0)
                mensagens.Add("Informe uma Quantidade para continuar.");

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}