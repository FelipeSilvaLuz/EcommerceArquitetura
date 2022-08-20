using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface  ICategoriaAppService
    {
        RetornoGenerico Incluir(Categoria dados);

        Categoria Consultar(int id, bool getDependencies);

        List<Categoria> Listar(bool getDependencies);

        RetornoGenerico Alterar(Categoria dados);

        RetornoGenerico Remover(int id);
    }
}