using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Data.Repository
{
    public class CaracteristicaRepository : CrudRepository<Caracteristica>, ICaracteristicaRepository
    {
        public CaracteristicaRepository(EcommerceContext context) : base(context)
        {

        }
    }
}