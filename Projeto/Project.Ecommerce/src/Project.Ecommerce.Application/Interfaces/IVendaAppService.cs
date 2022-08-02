using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface IVendaAppService
    {
        RetornoGenerico Incluir(Venda dados);

        Venda Consultar(int id, bool getDependencies);

        List<Venda> Listar(bool getDependencies);

        RetornoGenerico Alterar(Venda dados);

        RetornoGenerico Remover(int id);
    }
}