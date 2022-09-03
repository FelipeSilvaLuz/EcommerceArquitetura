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
    public class BancoAppService : IBancoAppService
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly TextoSettings _textoSettings;

        public BancoAppService(
            IBancoRepository bancoRepository,
            IOptions<TextoSettings> options)
        {
            _bancoRepository = bancoRepository;
            _textoSettings = options.Value;
        }

        public RetornoGenerico Incluir(Banco dados)
        {
            if (String.IsNullOrEmpty(dados.Nome))
                return new RetornoGenerico(false, new List<string> { _textoSettings.PreenchaCampos });

            _bancoRepository.Incluir(dados);
            _bancoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroIncluido });
        }

        public RetornoGenerico Alterar(Banco dados)
        {
            if(String.IsNullOrEmpty(dados.Nome))
                return new RetornoGenerico(false, new List<string> { _textoSettings.PreenchaCampos });

            var retorno = _bancoRepository.Consultar(dados.Id);
            retorno.Nome = dados.Nome;

            _bancoRepository.Alterar(retorno);
            _bancoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroAlterado });
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
            {
                _bancoRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { _textoSettings.Removido });
            }
            else
                return new RetornoGenerico(false, new List<string> { _textoSettings.ErroRemover });
        }
    }
}