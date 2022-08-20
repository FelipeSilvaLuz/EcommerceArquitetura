using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface ICaracteristicaAppService
    {
        RetornoGenerico Incluir(Caracteristica dados);

        Caracteristica Consultar(int id, bool getDependencies);

        List<Caracteristica> Listar(bool getDependencies);

        RetornoGenerico Alterar(Caracteristica dados);

        RetornoGenerico Remover(int id);
    }
}