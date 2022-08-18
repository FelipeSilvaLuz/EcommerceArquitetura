using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface IFotoAppService
    {
        RetornoGenerico Incluir(Foto dados);

        Foto Consultar(int id, bool getDependencies);

        List<Foto> Listar(bool getDependencies);

        RetornoGenerico Alterar(Foto dados);

        RetornoGenerico Remover(int id);
    }
}