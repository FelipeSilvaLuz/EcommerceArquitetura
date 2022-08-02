using Project.Ecommerce.CrossCutting.ViewModels;
using Project.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface IVariacaoAppService
    {
        RetornoGenerico Incluir(Variacao dados);

        Variacao Consultar(int id, bool getDependencies);

        List<Variacao> Listar(bool getDependencies);

        RetornoGenerico Alterar(Variacao dados);

        RetornoGenerico Remover(int id);
    }
}