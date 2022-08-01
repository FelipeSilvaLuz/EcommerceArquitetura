using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        RetornoGenerico Incluir(Usuario dados);

        Usuario Consultar(int id, bool getDependencies);

        List<Usuario> Listar(bool getDependencies);

        RetornoGenerico Alterar(Usuario dados);

        RetornoGenerico Remover(int id);
    }
}