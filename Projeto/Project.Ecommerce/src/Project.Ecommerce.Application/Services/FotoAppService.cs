using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Application.Services
{
    public class FotoAppService : IFotoAppService
    {
        private readonly IFotoRepository _fotoRepository;

        public FotoAppService(IFotoRepository fotoRepository)
        {
            _fotoRepository = fotoRepository;
        }
    }
}