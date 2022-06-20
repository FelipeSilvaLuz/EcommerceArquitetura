using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("tb_vendas");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd();

            builder.HasOne(arquivo => arquivo.Usuario)
              .WithMany().HasForeignKey(arquivo => arquivo.IdUsuario);

            builder.HasOne(arquivo => arquivo.Produto)
              .WithMany().HasForeignKey(arquivo => arquivo.IdProduto);

            builder.HasOne(arquivo => arquivo.Endereco)
              .WithMany().HasForeignKey(arquivo => arquivo.IdEndereco);

            builder.HasOne(arquivo => arquivo.Status)
              .WithMany().HasForeignKey(arquivo => arquivo.IdStatus);

            builder.Property(user => user.TipoPagamento).IsRequired();
            builder.Property(user => user.Valor).IsRequired();
            builder.Property(user => user.Quantidade).IsRequired();

            builder.Property(user => user.AlteradoPor);
            builder.Property(user => user.AlteradoEm);
            builder.Property(user => user.CriadoPor).IsRequired();
            builder.Property(user => user.CriadoEm).IsRequired();
            builder.Property(user => user.Ativo).HasDefaultValue(true);
        }
    }
}