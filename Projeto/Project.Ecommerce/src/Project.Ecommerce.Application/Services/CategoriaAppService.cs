using Microsoft.Extensions.Options;
using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.CrossCutting.Settings;
using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Project.Ecommerce.Application.Services
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly TextoSettings _textoSettings;


        public CategoriaAppService(
            ICategoriaRepository categoriaRepository,
            IOptions<TextoSettings> options)
        {
            _categoriaRepository = categoriaRepository;
            _textoSettings = options.Value;
        }

        public RetornoGenerico Incluir(Categoria dados)
        {
            if (string.IsNullOrEmpty(dados.Nome))
                return new RetornoGenerico(false, new List<string> { _textoSettings.PreenchaCampos });

            _categoriaRepository.Incluir(dados);
            _categoriaRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroIncluido });
        }

        public RetornoGenerico Alterar(Categoria dados)
        {
            if (string.IsNullOrEmpty(dados.Nome))
                return new RetornoGenerico(false, new List<string> { _textoSettings.PreenchaCampos });

            var retorno = _categoriaRepository.Consultar(dados.Id);
            retorno.Nome = dados.Nome;

            _categoriaRepository.Alterar(retorno);
            _categoriaRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { _textoSettings.RegistroAlterado });
        }

        public Categoria Consultar(int id, bool getDependencies)
        {
            return _categoriaRepository.Consultar(id, getDependencies);
        }

        public List<Categoria> Listar(bool getDependencies)
        {
            return _categoriaRepository.Listar(getDependencies).ToList();
        }

        public RetornoGenerico Remover(int id)
        {
            if (_categoriaRepository.Remover(id))
            {
                _categoriaRepository.SaveChanges();
                return new RetornoGenerico(true, new List<string> { _textoSettings.Removido });
            }
            else
                return new RetornoGenerico(false, new List<string> { _textoSettings.ErroRemover });
        }
    }
}