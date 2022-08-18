using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface IComentarioAppService
    {
        RetornoGenerico Incluir(Comentario dados);

        Comentario Consultar(int id, bool getDependencies);

        List<Comentario> Listar(bool getDependencies);

        RetornoGenerico Alterar(Comentario dados);

        RetornoGenerico Remover(int id);
    }
}