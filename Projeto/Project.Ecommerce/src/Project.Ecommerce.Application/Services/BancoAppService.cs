using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Application.Services
{
    public class BancoAppService : IBancoAppService
    {
        private readonly IBancoRepository _bancoRepository;

        public BancoAppService(IBancoRepository bancoRepository)
        {
            _bancoRepository = bancoRepository;
        }
    }
}