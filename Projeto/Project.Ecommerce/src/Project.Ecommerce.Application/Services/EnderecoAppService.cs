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
    public class EnderecoAppService : IEnderecoAppService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IPesquisasExternasAppService _pesquisasExternasAppService;
        private readonly TextoSettings _textoSettings;

        public EnderecoAppService(
            IEnderecoRepository enderecoRepository,
            IPesquisasExternasAppService pesquisasExternasAppService,
            IOptions<TextoSettings> options)
        {
            _enderecoRepository = enderecoRepository;
            _pesquisasExternasAppService = pesquisasExternasAppService;
            _textoSettings = options.Value;
        }

        public RetornoGenerico Incluir(Endereco dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _enderecoRepository.Incluir(dados);
            _enderecoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroIncluido });
        }

        public RetornoGenerico Alterar(Endereco dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            var retorno = _enderecoRepository.Consultar(dados.Id);

            retorno.NomeEndereco = dados.NomeEndereco;
            retorno.Numero = dados.Numero;
            retorno.Complemento = dados.Complemento;
            retorno.Cep = dados.Cep;
            retorno.Cidade = dados.Cidade;
            retorno.Bairro = dados.Bairro;
            retorno.Estado = dados.Estado;
            retorno.Referencia = dados.Referencia;

            _enderecoRepository.Alterar(retorno);
            _enderecoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroAlterado });
        }

        public Endereco Consultar(int id, bool getDependencies)
        {
            return _enderecoRepository.Consultar(id, getDependencies);
        }

        public InformacoesCEP BuscarCEP(string cep)
        {
            return _pesquisasExternasAppService.BuscarInformacoesCEP(cep);
        }

        public List<Endereco> Listar(bool getDependencies)
        {
            return _enderecoRepository.Listar(getDependencies).ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_enderecoRepository.Remover(id))
            {
                _enderecoRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { _textoSettings.Removido });
            }
            else
                return new RetornoGenerico(false, new List<string> { _textoSettings.ErroRemover });
        }

        public RetornoGenerico ValidarCampos(Endereco dados)
        {
            List<string> mensagens = new List<string>();

            if (String.IsNullOrEmpty(dados.NomeEndereco))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Endereco));

            if (String.IsNullOrEmpty(dados.Numero))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Numero));

            if (String.IsNullOrEmpty(dados.Complemento))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Complemento));

            if (String.IsNullOrEmpty(dados.Cep))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", "CEP"));

            if (String.IsNullOrEmpty(dados.Cidade))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Cidade));

            if (String.IsNullOrEmpty(dados.Bairro))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Bairro));

            if (String.IsNullOrEmpty(dados.Estado))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Estado));

            if (String.IsNullOrEmpty(dados.Referencia))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Referencia));

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}