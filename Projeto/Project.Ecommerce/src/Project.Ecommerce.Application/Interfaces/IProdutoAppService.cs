using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface IProdutoAppService
    {
        RetornoGenerico Incluir(Produto dados);

        Produto Consultar(int id, bool getDependencies);

        List<Produto> Listar(bool getDependencies);

        RetornoGenerico Alterar(Produto dados);

        RetornoGenerico Remover(int id);
    }
}