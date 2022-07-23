using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Application.Services
{
    public class TipoPagamentoAppService : ITipoPagamentoAppService
    {
        private readonly ITipoPagamentoRepository _tipoPagamentoRepository;

        public TipoPagamentoAppService(ITipoPagamentoRepository tipoPagamentoRepository)
        {
            _tipoPagamentoRepository = tipoPagamentoRepository;
        }
    }
}