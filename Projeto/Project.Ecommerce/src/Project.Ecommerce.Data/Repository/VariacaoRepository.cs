using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Data.Repository
{
    public class VariacaoRepository : CrudRepository<Variacao>, IVariacaoRepository
    {
        public VariacaoRepository(EcommerceContext context) : base(context)
        {
        }
    }
}