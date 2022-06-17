using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class FotoMap : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            builder.ToTable("Foto");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd();

            builder.HasOne(arquivo => arquivo.Categoria)
                .WithMany().HasForeignKey(arquivo => arquivo.IdCategoria);

            builder.HasOne(arquivo => arquivo.Produto)
              .WithMany().HasForeignKey(arquivo => arquivo.IdProduto);

            builder.HasOne(arquivo => arquivo.Status)
             .WithMany().HasForeignKey(arquivo => arquivo.IdStatus);

            builder.Property(user => user.Nome).IsRequired();
            builder.Property(user => user.Base64).IsRequired();

            builder.Property(user => user.AlteradoPor);
            builder.Property(user => user.AlteradoEm);
            builder.Property(user => user.CriadoPor).IsRequired();
            builder.Property(user => user.CriadoEm).IsRequired();
            builder.Property(user => user.Ativo).HasDefaultValue(true);
        }
    }
}