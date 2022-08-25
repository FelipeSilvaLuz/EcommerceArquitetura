using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.CrossCutting.ViewModels;

namespace Project.Ecommerce.Application.Services
{
    public class PesquisasExternasAppService : IPesquisasExternasAppService
    {
        public PesquisasExternasAppService()
        {

        }

        public InformacoesCEP BuscarInformacoesCEP(string cep)
        {
            // Conectar na API do VIA CEP
            return null;
        }
    }
}