using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Data.Repository
{
    public class CarrinhoRepository : CrudRepository<Carrinho>, ICarrinhoRepository
    {
        public CarrinhoRepository(EcommerceContext context) : base(context)
        {
        }
    }
}