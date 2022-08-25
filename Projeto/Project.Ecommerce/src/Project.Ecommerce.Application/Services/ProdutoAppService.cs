using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Ecommerce.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoAppService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public RetornoGenerico Incluir(Produto dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _produtoRepository.Incluir(dados);
            _produtoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { "Registro incluido com sucesso." });
        }

        public RetornoGenerico Alterar(Produto dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            var retorno = _produtoRepository.Consultar(dados.Id);

            retorno.Nome = dados.Nome;
            retorno.Descricao = dados.Descricao;
            retorno.Quantidade = dados.Quantidade;
            retorno.Valor = dados.Valor;

            _produtoRepository.Alterar(retorno);
            _produtoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { "Registro alterado com sucesso." });
        }

        public Produto Consultar(int id, bool getDependencies)
        {
            return _produtoRepository.Consultar(id, getDependencies);
        }

        public List<Produto> Listar(bool getDependencies)
        {
            return _produtoRepository.Listar(getDependencies).ToList();
        }

        public List<Produto> ListarPorCategoriaEVariacao(int? idCategoria, int? idVariacao, bool getDependencies)
        {
            var produtos = _produtoRepository.Listar(getDependencies);

            if (!idCategoria.Equals(null))
                produtos = produtos.Where(x => x.IdCategoria.Equals(idCategoria));

            if (!idVariacao.Equals(null))
                produtos = produtos.Where(x => x.IdVariacao.Equals(idVariacao));

            return produtos.ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_produtoRepository.Remover(id))
            {
                _produtoRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { "Removido com sucesso" });
            }
            else
                return new RetornoGenerico(false, new List<string> { "Erro ao remover" });
        }

        public RetornoGenerico ValidarCampos(Produto dados)
        {
            List<string> mensagens = new List<string>();

            if (dados.IdCategoria == 0)
                mensagens.Add("Informe uma Cidade para continuar.");

            if (dados.IdVariacao == 0)
                mensagens.Add("Informe um Bairro para continuar.");

            if (String.IsNullOrEmpty(dados.Nome))
                mensagens.Add("Informe um Nome para continuar.");

            if (String.IsNullOrEmpty(dados.Descricao))
                mensagens.Add("Informe uma Descricao para continuar.");

            if (dados.Quantidade == 0)
                mensagens.Add("Informe uma Quantidade para continuar.");

            if (dados.Valor == 0)
                mensagens.Add("Informe um Valor para continuar.");

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}