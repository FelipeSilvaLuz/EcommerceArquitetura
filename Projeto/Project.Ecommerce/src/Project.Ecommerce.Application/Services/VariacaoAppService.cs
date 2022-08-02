using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Ecommerce.Application.Services
{
    public class VariacaoAppService : IVariacaoAppService
    {
        private readonly IVariacaoRepository _variacaoRepository;

        public VariacaoAppService(IVariacaoRepository variacaoRepository)
        {
            _variacaoRepository = variacaoRepository;
        }
        public RetornoGenerico Incluir(Variacao dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _variacaoRepository.Incluir(dados);
            _variacaoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { "Registro incluido com sucesso." });
        }

        public RetornoGenerico Alterar(Variacao dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            var retorno = _variacaoRepository.Consultar(dados.Id);

            retorno.Nome = dados.Nome;
            retorno.Descricao = dados.Descricao;

            _variacaoRepository.Alterar(retorno);
            _variacaoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { "Registro alterado com sucesso." });
        }

        public Variacao Consultar(int id, bool getDependencies)
        {
            return _variacaoRepository.Consultar(id, getDependencies);
        }

        public List<Variacao> Listar(bool getDependencies)
        {
            return _variacaoRepository.Listar(getDependencies).ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_variacaoRepository.Remover(id))
            {
                _variacaoRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { "Removido com sucesso" });
            }
            else
                return new RetornoGenerico(false, new List<string> { "Erro ao remover" });
        }

        public RetornoGenerico ValidarCampos(Variacao dados)
        {
            List<string> mensagens = new List<string>();

            if (String.IsNullOrEmpty(dados.Nome))
                mensagens.Add("Informe um Nome para continuar.");

            if (String.IsNullOrEmpty(dados.Descricao))
                mensagens.Add("Informe uma Descricao para continuar.");

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}