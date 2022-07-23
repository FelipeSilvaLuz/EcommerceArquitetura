using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Application.Services
{
    public class VariacaoAppService : IVariacaoAppService
    {
        private readonly IVariacaoRepository _variacaoRepository;

        public VariacaoAppService(IVariacaoRepository variacaoRepository)
        {
            _variacaoRepository = variacaoRepository;
        }
    }
}