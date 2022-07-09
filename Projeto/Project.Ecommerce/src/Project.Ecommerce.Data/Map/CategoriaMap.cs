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
            builder.Property(user => user.Id).HasColumnName("id_categoria").ValueGeneratedOnAdd();

            builder.Property(user => user.Nome).HasColumnName("nm_categoria").IsRequired();

            builder.HasOne(arquivo => arquivo.Status)
                .WithMany().HasForeignKey(arquivo => arquivo.Ativo);

            builder.Property(user => user.AlteradoPor).HasColumnName("id_usuario_alteracao");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("id_usuario_criacao");
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao");
            builder.Property(user => user.Ativo).HasColumnName("id_status");
        }
    }
}
