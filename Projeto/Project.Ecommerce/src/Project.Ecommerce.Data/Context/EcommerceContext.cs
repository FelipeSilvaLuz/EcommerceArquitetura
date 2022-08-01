using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project.Ecommerce.CrossCutting.Settings;
using Project.Ecommerce.Data.Map;

namespace Project.Ecommerce.Data.Context
{
    public class EcommerceContext : DbContext
    {
        private readonly WebSettings _webSettings;

        public EcommerceContext(IOptions<WebSettings> options)
        {
            _webSettings = options.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_webSettings.Database.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new CaracteristicaMap());
            modelBuilder.ApplyConfiguration(new CarrinhoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ComentarioMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new FotoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new StatusMap());
            modelBuilder.ApplyConfiguration(new VariacaoMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new BancoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}