using Microsoft.Extensions.Options;
using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.CrossCutting.Settings;
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
        private readonly TextoSettings _textoSettings;

        public ProdutoAppService(
            IProdutoRepository produtoRepository,
            IOptions<TextoSettings> options)
        {
            _produtoRepository = produtoRepository;
            _textoSettings = options.Value;
        }

        public RetornoGenerico Incluir(Produto dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _produtoRepository.Incluir(dados);
            _produtoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroIncluido });
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
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroAlterado });
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
                return new RetornoGenerico(true, new List<string> { _textoSettings.Removido });
            }
            else
                return new RetornoGenerico(false, new List<string> { _textoSettings.ErroRemover });
        }

        public RetornoGenerico ValidarCampos(Produto dados)
        {
            List<string> mensagens = new List<string>();

            if (dados.IdCategoria == 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Cidade));

            if (dados.IdVariacao == 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Bairro));

            if (String.IsNullOrEmpty(dados.Nome))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Nome));

            if (String.IsNullOrEmpty(dados.Descricao))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Descricao));

            if (dados.Quantidade == 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Quantidade));

            if (dados.Valor == 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Valor));

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}