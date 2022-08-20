using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class CaracteristicaMap : IEntityTypeConfiguration<Caracteristica>
    {
        public void Configure(EntityTypeBuilder<Caracteristica> builder)
        {
            builder.ToTable("tb_caracteristicas");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnName("id_caracteristica").ValueGeneratedOnAdd();
            builder.Property(user => user.IdProduto).HasColumnName("id_produto");

            builder.HasOne(arquivo => arquivo.Produto)
                .WithMany().HasForeignKey(arquivo => arquivo.IdProduto);

            builder.Property(user => user.Nome).HasColumnName("nm_caracteristica").IsRequired();
            builder.Property(user => user.Ordem).HasColumnName("nr_ordem").HasDefaultValue(false);
            builder.Property(user => user.Descricao).HasColumnName("nm_descricao").IsRequired();

            builder.Property(user => user.AlteradoPor).HasColumnName("alterado_por");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("criado_por").IsRequired();
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao").IsRequired();

            builder.Ignore(x => x.EhAtivo);
        }
    }
}