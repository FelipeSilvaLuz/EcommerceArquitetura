using Project.Ecommerce.Application.Interfaces;
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
        public EnderecoAppService(
            IEnderecoRepository enderecoRepository,
            IPesquisasExternasAppService pesquisasExternasAppService)
        {
            _enderecoRepository = enderecoRepository;
            _pesquisasExternasAppService = pesquisasExternasAppService;
        }

        public RetornoGenerico Incluir(Endereco dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _enderecoRepository.Incluir(dados);
            _enderecoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { "Registro incluido com sucesso." });
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
            return new RetornoGenerico(true, new List<string> { "Registro alterado com sucesso." });
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
                return new RetornoGenerico(true, new List<string> { "Removido com sucesso" });
            }
            else
                return new RetornoGenerico(false, new List<string> { "Erro ao remover" });
        }

        public RetornoGenerico ValidarCampos(Endereco dados)
        {
            List<string> mensagens = new List<string>();

            if (String.IsNullOrEmpty(dados.NomeEndereco))
                mensagens.Add("Informe um Endereco para continuar.");

            if (String.IsNullOrEmpty(dados.Numero))
                mensagens.Add("Informe um Numero para continuar.");

            if (String.IsNullOrEmpty(dados.Complemento))
                mensagens.Add("Informe um Complemento para continuar.");

            if (String.IsNullOrEmpty(dados.Cep))
                mensagens.Add("Informe um Cep para continuar.");

            if (String.IsNullOrEmpty(dados.Cidade))
                mensagens.Add("Informe uma Cidade para continuar.");

            if (String.IsNullOrEmpty(dados.Bairro))
                mensagens.Add("Informe um Bairro para continuar.");

            if (String.IsNullOrEmpty(dados.Estado))
                mensagens.Add("Informe um Estado para continuar.");

            if (String.IsNullOrEmpty(dados.Referencia))
                mensagens.Add("Informe uma Referencia para continuar.");

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}