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
    public class VariacaoAppService : IVariacaoAppService
    {
        private readonly IVariacaoRepository _variacaoRepository;
        private readonly TextoSettings _textoSettings;

        public VariacaoAppService(
            IVariacaoRepository variacaoRepository,
            IOptions<TextoSettings> options)
        {
            _variacaoRepository = variacaoRepository;
            _textoSettings = options.Value;
        }

        public RetornoGenerico Incluir(Variacao dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _variacaoRepository.Incluir(dados);
            _variacaoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroIncluido });
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
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroAlterado });
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
                return new RetornoGenerico(true, new List<string> { _textoSettings.Removido });
            }
            else
                return new RetornoGenerico(false, new List<string> { _textoSettings.ErroRemover });
        }

        public RetornoGenerico ValidarCampos(Variacao dados)
        {
            List<string> mensagens = new List<string>();

            if (String.IsNullOrEmpty(dados.Nome))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Nome));

            if (String.IsNullOrEmpty(dados.Descricao))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Descricao));

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}