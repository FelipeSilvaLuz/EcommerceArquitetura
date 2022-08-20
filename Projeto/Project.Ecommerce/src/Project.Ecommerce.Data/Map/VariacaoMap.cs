using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class VariacaoMap : IEntityTypeConfiguration<Variacao>
    {
        public void Configure(EntityTypeBuilder<Variacao> builder)
        {
            builder.ToTable("tb_variacoes");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnName("id_variacao").ValueGeneratedOnAdd();

            builder.Property(user => user.Nome).HasColumnName("nm_variacao").IsRequired();
            builder.Property(user => user.Descricao).HasColumnName("nm_descricao");

            builder.Property(user => user.AlteradoPor).HasColumnName("alterado_por");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("criado_por").IsRequired();
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao").IsRequired();

            builder.Ignore(x => x.EhAtivo);
        }
    }
}