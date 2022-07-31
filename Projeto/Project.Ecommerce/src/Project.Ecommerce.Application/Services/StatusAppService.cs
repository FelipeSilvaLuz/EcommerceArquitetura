using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Ecommerce.Application.Services
{
    public class StatusAppService : IStatusAppService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusAppService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public RetornoGenerico Incluir(Status dados)
        {
            if (String.IsNullOrEmpty(dados.Nome) || String.IsNullOrEmpty(dados.Descricao))
                return new RetornoGenerico(false, new List<string> { "Preencha o campo para continuar." });

            _statusRepository.Incluir(dados);
            return new RetornoGenerico(true, new List<string> { "Registro incluido com sucesso." });
        }

        public RetornoGenerico Alterar(Status dados)
        {
            if (String.IsNullOrEmpty(dados.Nome) || String.IsNullOrEmpty(dados.Descricao))
                return new RetornoGenerico(false, new List<string> { "Preencha o campo para continuar." });

            var retorno = _statusRepository.Consultar(dados.Id);
            retorno.Nome = dados.Nome;

            _statusRepository.Alterar(retorno);
            return new RetornoGenerico(true, new List<string> { "Registro alterado com sucesso." });
        }

        public Status Consultar(int id, bool getDependencies)
        {
            return _statusRepository.Consultar(id, getDependencies);
        }

        public List<Status> Listar(bool getDependencies)
        {
            return _statusRepository.Listar(getDependencies).ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_statusRepository.Remover(id))
                return new RetornoGenerico(true, new List<string> { "Removido com sucesso" });
            else
                return new RetornoGenerico(false, new List<string> { "Erro ao remover" });
        }
    }
}