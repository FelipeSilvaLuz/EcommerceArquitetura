using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tb_produtos");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnName("id_produto").ValueGeneratedOnAdd();
            builder.Property(user => user.IdCategoria).HasColumnName("id_categoria");
            builder.Property(user => user.IdVariacao).HasColumnName("id_variacao");

            builder.HasOne(arquivo => arquivo.Categoria)
                .WithMany().HasForeignKey(arquivo => arquivo.IdCategoria);

            builder.HasOne(arquivo => arquivo.Variacao)
              .WithMany().HasForeignKey(arquivo => arquivo.IdVariacao);

            builder.HasOne(arquivo => arquivo.Status)
                .WithMany().HasForeignKey(arquivo => arquivo.Ativo);

            builder.Property(user => user.Nome).HasColumnName("nm_produto").IsRequired();
            builder.Property(user => user.Descricao).HasColumnName("nm_descricao");
            builder.Property(user => user.Quantidade).HasColumnName("nr_quantidade").IsRequired();
            builder.Property(user => user.Valor).HasColumnName("nr_valor").IsRequired();

            builder.Property(user => user.AlteradoPor).HasColumnName("id_usuario_alteracao");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("id_usuario_criacao");
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao");
            builder.Property(user => user.Ativo).HasColumnName("id_status");
        }
    }
}