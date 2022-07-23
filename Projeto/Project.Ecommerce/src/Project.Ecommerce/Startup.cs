using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Ecommerce.Application.Interfaces;
using Project.Ecommerce.Application.Services;
using Project.Ecommerce.CrossCutting.Settings;
using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Data.Repository;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<WebSettings>(options => Configuration.Bind(options));
            WebSettings apiSettings = Configuration.Get<WebSettings>();

            services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<ICaracteristicaRepository, CaracteristicaRepository>();
            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IComentarioRepository, ComentarioRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IFotoRepository, FotoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ITipoPagamentoRepository, TipoPagamentoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVariacaoRepository, VariacaoRepository>();
            services.AddScoped<EcommerceContext>();

            services.AddScoped<IBancoAppService, BancoAppService>();
            services.AddScoped<ICaracteristicaAppService, CaracteristicaAppService>();
            services.AddScoped<ICarrinhoAppService, CarrinhoAppService>();
            services.AddScoped<ICategoriaAppService, CategoriaAppService>();
            services.AddScoped<IComentarioAppService, ComentarioAppService>();
            services.AddScoped<IEnderecoAppService, EnderecoAppService>();
            services.AddScoped<IFotoAppService, FotoAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IStatusAppService, StatusAppService>();
            services.AddScoped<ITipoPagamentoAppService, TipoPagamentoAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IVariacaoAppService, VariacaoAppService>();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}