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
    public class StatusAppService : IStatusAppService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly TextoSettings _textoSettings;

        public StatusAppService(
            IStatusRepository statusRepository,
            IOptions<TextoSettings> options)
        {
            _statusRepository = statusRepository;
            _textoSettings = options.Value;
        }

        public RetornoGenerico Incluir(Status dados)
        {
            if (String.IsNullOrEmpty(dados.Nome) || String.IsNullOrEmpty(dados.Descricao))
                return new RetornoGenerico(false, new List<string> { _textoSettings.PreenchaCampos });

            _statusRepository.Incluir(dados);
            _statusRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroIncluido });
        }

        public RetornoGenerico Alterar(Status dados)
        {
            if (String.IsNullOrEmpty(dados.Nome) || String.IsNullOrEmpty(dados.Descricao))
                return new RetornoGenerico(false, new List<string> { _textoSettings.PreenchaCampos });

            var retorno = _statusRepository.Consultar(dados.Id);
            retorno.Nome = dados.Nome;

            _statusRepository.Alterar(retorno);
            _statusRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroAlterado });
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
            {
                _statusRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { _textoSettings.Removido });
            }
            else
                return new RetornoGenerico(false, new List<string> { _textoSettings.ErroRemover });
        }
    }
}