using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Ecommerce.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public RetornoGenerico Incluir(Usuario dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _usuarioRepository.Incluir(dados);
            return new RetornoGenerico(true, new List<string> { "Registro incluido com sucesso." });
        }

        public RetornoGenerico Alterar(Usuario dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            var retorno = _usuarioRepository.Consultar(dados.Id);
            retorno.Nome = dados.Nome;

            _usuarioRepository.Alterar(retorno);
            return new RetornoGenerico(true, new List<string> { "Registro alterado com sucesso." });
        }

        public Usuario Consultar(int id, bool getDependencies)
        {
            return _usuarioRepository.Consultar(id, getDependencies);
        }

        public List<Usuario> Listar(bool getDependencies)
        {
            return _usuarioRepository.Listar(getDependencies).ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_usuarioRepository.Remover(id))
                return new RetornoGenerico(true, new List<string> { "Removido com sucesso" });
            else
                return new RetornoGenerico(false, new List<string> { "Erro ao remover" });
        }

        public RetornoGenerico ValidarCampos(Usuario dados)
        {
            List<string> mensagens = new List<string>();

            if (String.IsNullOrEmpty(dados.Email))
                mensagens.Add("Informe um e-mail para continuar.");

            if(String.IsNullOrEmpty(dados.Nome))
                mensagens.Add("Informe um nome para continuar.");

            if (String.IsNullOrEmpty(dados.Perfil))
                mensagens.Add("Informe um perfil para continuar.");

            if (String.IsNullOrEmpty(dados.Senha))
                mensagens.Add("Informe uma senha para continuar.");

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}