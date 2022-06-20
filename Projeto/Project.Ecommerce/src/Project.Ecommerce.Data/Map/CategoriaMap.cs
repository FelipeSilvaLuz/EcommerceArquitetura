using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("tb_categorias");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd();

            builder.Property(user => user.Nome).IsRequired();

            builder.Property(user => user.AlteradoPor);
            builder.Property(user => user.AlteradoEm);
            builder.Property(user => user.CriadoPor).IsRequired();
            builder.Property(user => user.CriadoEm).IsRequired();
            builder.Property(user => user.Ativo).HasDefaultValue(true);
        }
    }
}
