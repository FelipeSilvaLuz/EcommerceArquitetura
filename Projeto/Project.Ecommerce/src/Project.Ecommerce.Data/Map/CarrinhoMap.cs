using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class CarrinhoMap : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.ToTable("tb_carrinhos");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnName("id_carrinho").ValueGeneratedOnAdd();
            builder.Property(user => user.IdProduto).HasColumnName("id_produto");
            builder.Property(user => user.IdUsuario).HasColumnName("id_usuario");

            builder.HasOne(arquivo => arquivo.Produto)
                .WithMany().HasForeignKey(arquivo => arquivo.IdProduto);

            builder.HasOne(arquivo => arquivo.Usuario)
                .WithMany().HasForeignKey(arquivo => arquivo.IdUsuario);

            builder.Property(user => user.Quantidade).HasColumnName("nr_quantidade").IsRequired();

            builder.Property(user => user.AlteradoPor).HasColumnName("alterado_por");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("criado_por").IsRequired();
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao").IsRequired();

            builder.Ignore(x => x.EhAtivo);
        }
    }
}