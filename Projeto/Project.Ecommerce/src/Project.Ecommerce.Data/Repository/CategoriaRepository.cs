using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Data.Repository
{
    public class CategoriaRepository : CrudRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(EcommerceContext context) : base(context)
        {

        }
    }
}