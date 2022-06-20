using System;
using System.Collections.Generic;

namespace Project.Ecommerce.Domain.Interfaces
{
    public interface ICrudRepository<TEntity> : IDisposable
    {
        bool Alterar(TEntity obj);

        TEntity Consultar(int id, bool getDependencies = true);

        bool Incluir(TEntity obj);

        IEnumerable<TEntity> Listar(bool getDependencies = false);

        bool Remover(int id);
    }
}