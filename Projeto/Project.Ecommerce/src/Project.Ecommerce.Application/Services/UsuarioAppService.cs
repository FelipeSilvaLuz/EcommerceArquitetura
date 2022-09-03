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
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly TextoSettings _textoSettings;

        public UsuarioAppService(
            IUsuarioRepository usuarioRepository,
            IOptions<TextoSettings> options)
        {
            _usuarioRepository = usuarioRepository;
            _textoSettings = options.Value;
        }

        public RetornoGenerico Incluir(Usuario dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            _usuarioRepository.Incluir(dados);
            _usuarioRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroIncluido });
        }

        public RetornoGenerico Alterar(Usuario dados)
        {
            var validar = ValidarCampos(dados);
            if (!validar.Sucesso)
                return validar;

            var retorno = _usuarioRepository.Consultar(dados.Id);
            retorno.Nome = dados.Nome;
            retorno.Perfil = dados.Perfil;
            retorno.Email = dados.Email;
            retorno.Senha = dados.Senha;
            retorno.ReceberOfertas = dados.ReceberOfertas;

            _usuarioRepository.Alterar(retorno);
            _usuarioRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroAlterado });
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
            {
                _usuarioRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { _textoSettings.Removido });
            }
            else
                return new RetornoGenerico(false, new List<string> { _textoSettings.ErroRemover });
        }

        public RetornoGenerico ValidarCampos(Usuario dados)
        {
            List<string> mensagens = new List<string>();

            if (String.IsNullOrEmpty(dados.Email))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Email));

            if (String.IsNullOrEmpty(dados.Nome))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Nome));

            if (String.IsNullOrEmpty(dados.Perfil))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Perfil));

            if (String.IsNullOrEmpty(dados.Senha))
                mensagens.Add(_textoSettings.PreenchaCampo.Replace("{nome}", _textoSettings.Senha));

            return new RetornoGenerico(!mensagens.Any(), mensagens);
        }
    }
}