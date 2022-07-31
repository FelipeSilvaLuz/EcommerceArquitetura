using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Ecommerce.Application.Services
{
    public class BancoAppService : IBancoAppService
    {
        private readonly IBancoRepository _bancoRepository;

        public BancoAppService(IBancoRepository bancoRepository)
        {
            _bancoRepository = bancoRepository;
        }

        public RetornoGenerico Incluir(Banco dados)
        {
            if (String.IsNullOrEmpty(dados.Nome))
                return new RetornoGenerico(false, new List<string> { "Preencha o campo para continuar." });

            _bancoRepository.Incluir(dados);
            return new RetornoGenerico(true, new List<string> { "Registro incluido com sucesso." });
        }

        public RetornoGenerico Alterar(Banco dados)
        {
            if(String.IsNullOrEmpty(dados.Nome))
                return new RetornoGenerico(false, new List<string> { "Preencha o campo para continuar." });

            var retorno = _bancoRepository.Consultar(dados.Id);
            retorno.Nome = dados.Nome;

            _bancoRepository.Alterar(retorno);
            return new RetornoGenerico(true, new List<string> { "Registro alterado com sucesso." });
        }

        public Banco Consultar(int id, bool getDependencies)
        {
            return _bancoRepository.Consultar(id, getDependencies);
        }

        public List<Banco> Listar(bool getDependencies)
        {
            return _bancoRepository.Listar(getDependencies).ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_bancoRepository.Remover(id))
                return new RetornoGenerico(true, new List<string> { "Removido com sucesso" });
            else
                return new RetornoGenerico(false, new List<string> { "Erro ao remover" });
        }
    }
}