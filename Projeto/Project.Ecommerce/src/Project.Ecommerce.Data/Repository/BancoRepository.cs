using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Data.Repository
{
    public class BancoRepository : CrudRepository<Banco>, IBancoRepository
    {
        public BancoRepository(EcommerceContext context) : base(context)
        {

        }
    }
}