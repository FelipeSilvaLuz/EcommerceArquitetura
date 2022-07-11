using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Data.Repository
{
    public class TipoPagamentoRepository : CrudRepository<TipoPagamento>, ITipoPagamentoRepository
    {
        public TipoPagamentoRepository(EcommerceContext context) : base(context)
        {
        }
    }
}