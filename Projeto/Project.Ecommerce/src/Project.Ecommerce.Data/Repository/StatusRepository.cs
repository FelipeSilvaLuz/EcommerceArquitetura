using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Data.Repository
{
    public class StatusRepository : CrudRepository<Status>, IStatusRepository
    {
        public StatusRepository(EcommerceContext context) : base(context)
        {
        }
    }
}
