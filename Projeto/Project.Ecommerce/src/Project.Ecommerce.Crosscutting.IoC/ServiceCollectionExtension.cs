using Microsoft.Extensions.DependencyInjection;
using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.Application.Services;
using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Data.Repository;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Crosscutting.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEcommerceSetup(this IServiceCollection services)
        {
            AddApplicationSetup(services);
            AddDomainSetup(services);
            AddInfraSetup(services);

            return services;
        }

        public static void AddApplicationSetup(this IServiceCollection services)
        {
            services
                 .AddScoped<IBancoAppService, BancoAppService>()
                 .AddScoped<ICaracteristicaAppService, CaracteristicaAppService>()
                 .AddScoped<ICarrinhoAppService, CarrinhoAppService>()
                 .AddScoped<ICategoriaAppService, CategoriaAppService>()
                 .AddScoped<IComentarioAppService, ComentarioAppService>()
                 .AddScoped<IEnderecoAppService, EnderecoAppService>()
                 .AddScoped<IFotoAppService, FotoAppService>()
                 .AddScoped<IProdutoAppService, ProdutoAppService>()
                 .AddScoped<IStatusAppService, StatusAppService>()
                 .AddScoped<IUsuarioAppService, UsuarioAppService>()
                 .AddScoped<IVariacaoAppService, VariacaoAppService>();
        }

        public static void AddDomainSetup(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>))
                .AddScoped<IBancoRepository, BancoRepository>()
                .AddScoped<ICaracteristicaRepository, CaracteristicaRepository>()
                .AddScoped<ICarrinhoRepository, CarrinhoRepository>()
                .AddScoped<ICategoriaRepository, CategoriaRepository>()
                .AddScoped<IComentarioRepository, ComentarioRepository>()
                .AddScoped<IEnderecoRepository, EnderecoRepository>()
                .AddScoped<IFotoRepository, FotoRepository>()
                .AddScoped<IProdutoRepository, ProdutoRepository>()
                .AddScoped<IStatusRepository, StatusRepository>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddScoped<IVariacaoRepository, VariacaoRepository>();
        }

        public static void AddInfraSetup(this IServiceCollection services)
        {
            services.AddScoped<EcommerceContext>();
        }
    }
}