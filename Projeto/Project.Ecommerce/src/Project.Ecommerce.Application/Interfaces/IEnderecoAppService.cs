using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface IEnderecoAppService
    {
        RetornoGenerico Incluir(Endereco dados);

        Endereco Consultar(int id, bool getDependencies);

        List<Domain.Entities.Endereco> Listar(bool getDependencies);

        RetornoGenerico Alterar(Endereco dados);

        RetornoGenerico Remover(int id);
    }
}