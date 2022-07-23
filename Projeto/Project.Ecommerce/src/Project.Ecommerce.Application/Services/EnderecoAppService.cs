using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Application.Services
{
    public class EnderecoAppService : IEnderecoAppService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoAppService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
    }
}