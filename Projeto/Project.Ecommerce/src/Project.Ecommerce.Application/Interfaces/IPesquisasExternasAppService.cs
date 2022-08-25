using Project.Ecommerce.CrossCutting.ViewModels;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface IPesquisasExternasAppService
    {
        InformacoesCEP BuscarInformacoesCEP(string cep);
    }
}