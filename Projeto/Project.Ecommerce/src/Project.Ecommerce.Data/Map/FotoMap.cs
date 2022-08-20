using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class FotoMap : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            builder.ToTable("tb_fotos");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnName("id_foto").ValueGeneratedOnAdd();
            builder.Property(user => user.IdProduto).HasColumnName("id_produto");
            builder.Property(user => user.IdCategoria).HasColumnName("id_categoria");

            builder.HasOne(arquivo => arquivo.Categoria)
                .WithMany().HasForeignKey(arquivo => arquivo.IdCategoria);

            builder.HasOne(arquivo => arquivo.Produto)
                .WithMany().HasForeignKey(arquivo => arquivo.IdProduto);

            builder.Property(user => user.Nome).HasColumnName("nm_nome").IsRequired();
            builder.Property(user => user.Base64).HasColumnName("nm_base64").IsRequired();

            builder.Property(user => user.AlteradoPor).HasColumnName("alterado_por");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("criado_por").IsRequired();
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao").IsRequired();
        }
    }
}