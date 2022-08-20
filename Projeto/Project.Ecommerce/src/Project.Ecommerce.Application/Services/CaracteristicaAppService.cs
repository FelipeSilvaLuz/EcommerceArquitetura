using Project.Ecommerce.Application.Interfaces;
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
        public CaracteristicaAppService(ICaracteristicaRepository caracteristicaRepository)
        {
            _caracteristicaRepository = caracteristicaRepository;
        }

        public RetornoGenerico Incluir(Caracteristica dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _caracteristicaRepository.Incluir(dados);
            _caracteristicaRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { "Registro incluido com sucesso." });
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
            return new RetornoGenerico(true, new List<string> { "Registro alterado com sucesso." });
        }

        public Caracteristica Consultar(int id, bool getDependencies)
        {
            return _caracteristicaRepository.Consultar(id, getDependencies);
        }

        public List<Caracteristica> Listar(bool getDependencies)
        {
            return _caracteristicaRepository.Listar(getDependencies).ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_caracteristicaRepository.Remover(id))
            {
                _caracteristicaRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { "Removido com sucesso" });
            }
            else
                return new RetornoGenerico(false, new List<string> { "Erro ao remover" });
        }

        public RetornoGenerico ValidarCampos(Caracteristica dados)
        {
            List<string> mensagens = new List<string>();

            if (dados.IdProduto == 0)
                mensagens.Add("Informe um Produto para continuar.");

            if (String.IsNullOrEmpty(dados.Nome))
                mensagens.Add("Informe um Nome para continuar.");

            if (String.IsNullOrEmpty(dados.Descricao))
                mensagens.Add("Informe uma Descrição para continuar.");

            if (dados.Ordem == 0)
                mensagens.Add("Informe uma Ordem para continuar.");

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}