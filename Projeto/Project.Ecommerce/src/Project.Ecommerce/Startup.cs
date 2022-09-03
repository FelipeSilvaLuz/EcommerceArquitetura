using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Ecommerce.Configuration;
using Project.Ecommerce.Crosscutting.IoC;
using Project.Ecommerce.CrossCutting.Settings;

namespace Project.Ecommerce
{
    public class Startup
    {
        public Startup(
            IConfiguration configuration,
            IConfiguration configurationResource,
            IWebHostEnvironment env)
        {
            Configuration = configuration;
            ConfigurationResource = configurationResource;

            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("wwwroot/Resource/Texto.json", optional: true, reloadOnChange: true);

            ConfigurationResource = builder.Build();
        }

        public IConfiguration Configuration { get; }
        public IConfiguration ConfigurationResource { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<WebSettings>(options => Configuration.Bind(options));
            WebSettings apiSettings = Configuration.Get<WebSettings>();

            services.Configure<TextoSettings>(options => ConfigurationResource.Bind(options));
            TextoSettings resourceSettings = ConfigurationResource.Get<TextoSettings>();

            services.AddSwaggerConfig();
            services.AddVersionConfig();

            services.AddSession();
            services.AddMemoryCache();

            services.AddCors();
            services.AddEcommerceSetup();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressMapClientErrors = true;
                })
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerUIConfig();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseDeveloperExceptionPage();
            app.UseAuthorization();

            app.UseEndpoints(x =>
            {
                x.MapControllers();
            });
        }
    }
}