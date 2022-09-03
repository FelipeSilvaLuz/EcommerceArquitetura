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
    public class ComentarioAppService : IComentarioAppService
    {
        private readonly IComentarioRepository _comentarioRepository;
        private readonly TextoSettings _textoSettings;

        public ComentarioAppService(
            IComentarioRepository comentarioRepository,
            IOptions<TextoSettings> options)
        {
            _comentarioRepository = comentarioRepository;
            _textoSettings = options.Value;
        }

        public RetornoGenerico Incluir(Comentario dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _comentarioRepository.Incluir(dados);
            _comentarioRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroIncluido });
        }

        public RetornoGenerico Alterar(Comentario dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            var retorno = _comentarioRepository.Consultar(dados.Id);

            retorno.Texto = dados.Texto;
            retorno.Titulo = dados.Titulo;
            retorno.Nota = dados.Nota;

            _comentarioRepository.Alterar(retorno);
            _comentarioRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroAlterado });
        }

        public Comentario Consultar(int id, bool getDependencies)
        {
            return _comentarioRepository.Consultar(id, getDependencies);
        }

        public List<Comentario> Listar(bool getDependencies)
        {
            return _comentarioRepository.Listar(getDependencies).ToList();
        }

        public List<Comentario> ListarPorIdProduto(int idProduto, bool getDependencies)
        {
            return _comentarioRepository.Listar(getDependencies)
                .Where(x => x.IdProduto.Equals(idProduto)).ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_comentarioRepository.Remover(id))
            {
                _comentarioRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { _textoSettings.Removido });
            }
            else
                return new RetornoGenerico(false, new List<string> { _textoSettings.ErroRemover });
        }

        public RetornoGenerico ValidarCampos(Comentario dados)
        {
            List<string> mensagens = new List<string>();

            if (dados.IdProduto is 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Produto));

            if (String.IsNullOrEmpty(dados.Texto))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Texto));

            if (String.IsNullOrEmpty(dados.Titulo))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Titulo));

            if (dados.Nota is 0)
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Nota));

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}