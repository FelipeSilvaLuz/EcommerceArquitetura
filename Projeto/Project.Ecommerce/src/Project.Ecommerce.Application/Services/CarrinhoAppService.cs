using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Application.Services
{
    public class CarrinhoAppService : ICarrinhoAppService
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        public CarrinhoAppService(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }
    }
}