using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Ecommerce.Application.Services
{
    public class FotoAppService : IFotoAppService
    {
        private readonly IFotoRepository _fotoRepository;

        public FotoAppService(IFotoRepository fotoRepository)
        {
            _fotoRepository = fotoRepository;
        }

        public RetornoGenerico Incluir(Foto dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _fotoRepository.Incluir(dados);
            _fotoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { "Registro incluido com sucesso." });
        }

        public RetornoGenerico Alterar(Foto dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            var retorno = _fotoRepository.Consultar(dados.Id);
            retorno.Nome = dados.Nome;
            retorno.Base64 = dados.Base64;

            _fotoRepository.Alterar(retorno);
            _fotoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { "Registro alterado com sucesso." });
        } 

        public Foto Consultar(int id, bool getDependencies)
        {
            return _fotoRepository.Consultar(id, getDependencies);
        }

        public List<Foto> Listar(bool getDependencies)
        {
            return _fotoRepository.Listar(getDependencies).ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_fotoRepository.Remover(id))
            {
                _fotoRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { "Removido com sucesso" });
            }
            else
                return new RetornoGenerico(false, new List<string> { "Erro ao remover" });
        }

        public RetornoGenerico ValidarCampos(Foto dados)
        {
            List<string> mensagens = new List<string>();

            if (dados.IdCategoria is 0)
                mensagens.Add("Informe um e-mail para continuar.");

            if (dados.IdProduto is 0)
                mensagens.Add("Informe um nome para continuar.");

            if (String.IsNullOrEmpty(dados.Base64))
                mensagens.Add("Informe um arquivo para continuar.");

            if (String.IsNullOrEmpty(dados.Nome))
                mensagens.Add("Informe um nome para continuar.");

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}