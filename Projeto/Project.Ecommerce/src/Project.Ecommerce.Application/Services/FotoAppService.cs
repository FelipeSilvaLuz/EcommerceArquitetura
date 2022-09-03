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
    public class FotoAppService : IFotoAppService
    {
        private readonly IFotoRepository _fotoRepository;
        private readonly TextoSettings _textoSettings;

        public FotoAppService(
            IFotoRepository fotoRepository,
            IOptions<TextoSettings> options)
        {
            _fotoRepository = fotoRepository;
            _textoSettings = options.Value;
        }

        public RetornoGenerico Incluir(Foto dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _fotoRepository.Incluir(dados);
            _fotoRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroIncluido });
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
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroAlterado });
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
                return new RetornoGenerico(true, new List<string> { _textoSettings.Removido });
            }
            else
                return new RetornoGenerico(false, new List<string> { _textoSettings.ErroRemover });
        }

        public RetornoGenerico ValidarCampos(Foto dados)
        {
            List<string> mensagens = new List<string>();

            if (dados.IdCategoria is 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Categoria));

            if (dados.IdProduto is 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Produto));

            if (String.IsNullOrEmpty(dados.Base64))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Foto));

            if (String.IsNullOrEmpty(dados.Nome))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Nome));

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}