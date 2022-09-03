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
    public class VendaAppService : IVendaAppService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly TextoSettings _textoSettings;

        public VendaAppService(
            IVendaRepository vendaRepository,
            IOptions<TextoSettings> options)
        {
            _vendaRepository = vendaRepository;
            _textoSettings = options.Value;
        }

        public RetornoGenerico Incluir(Venda dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _vendaRepository.Incluir(dados);
            _vendaRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroIncluido });
        }

        public RetornoGenerico Alterar(Venda dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            var retorno = _vendaRepository.Consultar(dados.Id);

            retorno.IdEndereco = dados.IdEndereco;
            retorno.TipoPagamento = dados.TipoPagamento;
            retorno.Valor = dados.Valor;
            retorno.Quantidade = dados.Quantidade;

            _vendaRepository.Alterar(retorno);
            _vendaRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroAlterado });
        }

        public Venda Consultar(int id, bool getDependencies)
        {
            return _vendaRepository.Consultar(id, getDependencies);
        }

        public List<Venda> Listar(bool getDependencies)
        {
            return _vendaRepository.Listar(getDependencies).ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_vendaRepository.Remover(id))
            {
                _vendaRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { _textoSettings.Removido });
            }
            else
                return new RetornoGenerico(false, new List<string> { _textoSettings.ErroRemover });
        }

        public RetornoGenerico ValidarCampos(Venda dados)
        {
            List<string> mensagens = new List<string>();

            if (dados.IdEndereco == 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Endereco));

            if (String.IsNullOrEmpty(dados.TipoPagamento))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.TipoPagamento));

            if (dados.Valor == 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Valor));

            if (dados.Quantidade == 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Quantidade));


            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}