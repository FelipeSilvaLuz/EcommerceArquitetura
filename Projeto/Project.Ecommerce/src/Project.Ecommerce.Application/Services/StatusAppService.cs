using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Application.Services
{
    public class StatusAppService : IStatusAppService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusAppService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
    }
}