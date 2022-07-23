using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Application.Services
{
    public class CaracteristicaAppService : ICaracteristicaAppService
    {
        private readonly ICaracteristicaRepository _caracteristicaRepository;
        public CaracteristicaAppService(ICaracteristicaRepository caracteristicaRepository)
        {
            _caracteristicaRepository = caracteristicaRepository;
        }
    }
}