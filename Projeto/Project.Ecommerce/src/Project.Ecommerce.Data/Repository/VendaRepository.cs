using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Data.Repository
{
    public class VendaRepository : CrudRepository<Venda>, IVendaRepository
    {
        public VendaRepository(EcommerceContext context) : base(context)
        {
        }
    }
}