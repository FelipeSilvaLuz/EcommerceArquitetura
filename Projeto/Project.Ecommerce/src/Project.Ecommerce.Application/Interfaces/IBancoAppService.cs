using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface IBancoAppService
    {
        RetornoGenerico Incluir(Banco dados);

        Banco Consultar(int id, bool getDependencies);

        List<Banco> Listar(bool getDependencies);

        RetornoGenerico Alterar(Banco dados);

        RetornoGenerico Remover(int id);
    }
}