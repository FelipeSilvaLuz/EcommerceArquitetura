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
    public class CaracteristicaAppService : ICaracteristicaAppService
    {
        private readonly ICaracteristicaRepository _caracteristicaRepository;
        private readonly TextoSettings _textoSettings;

        public CaracteristicaAppService(
            ICaracteristicaRepository caracteristicaRepository,
            IOptions<TextoSettings> options)
        {
            _caracteristicaRepository = caracteristicaRepository;
            _textoSettings = options.Value;
        }

        public RetornoGenerico Incluir(Caracteristica dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _caracteristicaRepository.Incluir(dados);
            _caracteristicaRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroIncluido });
        }

        public RetornoGenerico Alterar(Caracteristica dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            var retorno = _caracteristicaRepository.Consultar(dados.Id);

            retorno.Nome = dados.Nome;
            retorno.Descricao = dados.Descricao;
            retorno.Ordem = dados.Ordem;

            _caracteristicaRepository.Alterar(retorno);
            _caracteristicaRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroAlterado });
        }

        public Caracteristica Consultar(int id, bool getDependencies)
        {
            return _caracteristicaRepository.Consultar(id, getDependencies);
        }

        public List<Caracteristica> Listar(bool getDependencies)
        {
            return _caracteristicaRepository.Listar(getDependencies).ToList();
        }

        public List<Caracteristica> ListarPorIdProduto(int idProduto, bool getDependencies)
        {
            return _caracteristicaRepository.Listar(getDependencies)
                .Where(x => x.IdProduto.Equals(idProduto)).ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_caracteristicaRepository.Remover(id))
            {
                _caracteristicaRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { _textoSettings.Removido });
            }
            else
                return new RetornoGenerico(false, new List<string> { _textoSettings.ErroRemover });
        }

        public RetornoGenerico ValidarCampos(Caracteristica dados)
        {
            List<string> mensagens = new List<string>();

            if (dados.IdProduto == 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Produto));

            if (String.IsNullOrEmpty(dados.Nome))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Nome));

            if (String.IsNullOrEmpty(dados.Descricao))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Descricao));

            if (dados.Ordem == 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Ordem));

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}