using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Application.Services
{
    public class ComentarioAppService : IComentarioAppService
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioAppService(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }
    }
}