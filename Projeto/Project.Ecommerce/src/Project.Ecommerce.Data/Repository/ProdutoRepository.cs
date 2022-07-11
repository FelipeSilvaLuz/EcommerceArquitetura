using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Data.Repository
{
    public class ProdutoRepository : CrudRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(EcommerceContext context) : base(context)
        {
        }
    }
}