using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Data.Repository
{
    public class FotoRepository : CrudRepository<Foto>, IFotoRepository
    {
        public FotoRepository(EcommerceContext context) : base(context)
        {
        }
    }
}