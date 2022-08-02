using Microsoft.EntityFrameworkCore;
using Project.Ecommerce.Data.Extensions;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Project.Ecommerce.Data.Repository
{
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbset;

        public CrudRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = dbContext.Set<TEntity>();
        }

        public bool Incluir(TEntity entity)
        {
            _dbset.Add(entity);
            return true;
        }

        public bool Remover(int id)
        {
            var entity = Consultar(id);
            _dbset.Remove(entity);
            return true;
        }

        public virtual IEnumerable<TEntity> Listar(bool getDependencies = false)
        {
            var obj = _dbset.AsNoTracking();

            if (getDependencies)
            {
                obj = obj.Include(_dbContext.GetIncludePaths(typeof(TEntity)));
            }

            return obj;
        }

        public TEntity Consultar(int id, bool getDependencies = true)
        {
            if (getDependencies)
                return _dbset.AsNoTracking()
                    .Include(_dbContext.GetIncludePaths(typeof(TEntity)))
                    .FirstOrDefault(x => x.Id == id);

            else
                return _dbset.Find(id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public bool Alterar(TEntity entity)
        {
            _dbset.Update(entity);
            return true;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}