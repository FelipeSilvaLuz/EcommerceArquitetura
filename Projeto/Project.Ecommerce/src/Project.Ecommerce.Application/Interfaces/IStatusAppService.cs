using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface IStatusAppService
    {
        RetornoGenerico Incluir(Status dados);

        Status Consultar(int id, bool getDependencies);

        List<Status> Listar(bool getDependencies);

        RetornoGenerico Alterar(Status dados);

        RetornoGenerico Remover(int id);
    }
}