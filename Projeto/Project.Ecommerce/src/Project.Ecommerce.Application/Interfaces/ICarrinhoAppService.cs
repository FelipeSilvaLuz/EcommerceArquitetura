using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface ICarrinhoAppService
    {
        RetornoGenerico Incluir(Carrinho dados);

        Carrinho Consultar(int id, bool getDependencies);

        List<Carrinho> Listar(bool getDependencies);

        RetornoGenerico Alterar(Carrinho dados);

        RetornoGenerico Remover(int id);
    }
}