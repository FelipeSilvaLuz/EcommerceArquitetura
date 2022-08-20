using Project.Ecommerce.Application.Interfaces;
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

        public CategoriaAppService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public RetornoGenerico Incluir(Categoria dados)
        {
            if (string.IsNullOrEmpty(dados.Nome))
                return new RetornoGenerico(false, new List<string> { "Preencha o campo para continuar." });

            _categoriaRepository.Incluir(dados);
            _categoriaRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { "Registro incluido com sucesso." });
        }

        public RetornoGenerico Alterar(Categoria dados)
        {
            if (string.IsNullOrEmpty(dados.Nome))
                return new RetornoGenerico(false, new List<string> { "Preencha o campo para continuar." });

            var retorno = _categoriaRepository.Consultar(dados.Id);
            retorno.Nome = dados.Nome;

            _categoriaRepository.Alterar(retorno);
            _categoriaRepository.SaveChanges();
            return new RetornoGenerico(true, new List<string> { "Registro alterado com sucesso." });
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
                return new RetornoGenerico(true, new List<string> { "Removido com sucesso" });
            }
            else
                return new RetornoGenerico(false, new List<string> { "Erro ao remover" });
        }
    }
}