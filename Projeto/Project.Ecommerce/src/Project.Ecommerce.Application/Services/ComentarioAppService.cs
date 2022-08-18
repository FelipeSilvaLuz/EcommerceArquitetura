using Project.Ecommerce.Application.Interfaces;
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

        public ComentarioAppService(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        public RetornoGenerico Incluir(Comentario dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _comentarioRepository.Incluir(dados);
            _comentarioRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { "Registro incluido com sucesso." });
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
            return new RetornoGenerico(true, new List<string> { "Registro alterado com sucesso." });
        }

        public Comentario Consultar(int id, bool getDependencies)
        {
            return _comentarioRepository.Consultar(id, getDependencies);
        }

        public List<Comentario> Listar(bool getDependencies)
        {
            return _comentarioRepository.Listar(getDependencies).ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_comentarioRepository.Remover(id))
            {
                _comentarioRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { "Removido com sucesso" });
            }
            else
                return new RetornoGenerico(false, new List<string> { "Erro ao remover" });
        }

        public RetornoGenerico ValidarCampos(Comentario dados)
        {
            List<string> mensagens = new List<string>();

            if (dados.IdProduto is 0)
                mensagens.Add("Informe um Produto para continuar.");

            if (String.IsNullOrEmpty(dados.Texto))
                mensagens.Add("Informe um Nome para continuar.");

            if (String.IsNullOrEmpty(dados.Titulo))
                mensagens.Add("Informe um Titulo para continuar.");

            if (dados.Nota is 0)
                mensagens.Add("Informe uma Nota para continuar.");

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}