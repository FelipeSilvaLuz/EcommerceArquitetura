using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class TipoPagamentoMap : IEntityTypeConfiguration<TipoPagamento>
    {
        public void Configure(EntityTypeBuilder<TipoPagamento> builder)
        {
            builder.ToTable("tb_tipo_pagamento");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnName("id_tipo_pagamento").ValueGeneratedOnAdd();
            builder.Property(user => user.IdBanco).HasColumnName("id_banco");

            builder.Property(user => user.Nome).HasColumnName("nm_tipo_pagamento").IsRequired();

            builder.HasOne(arquivo => arquivo.Banco)
              .WithMany().HasForeignKey(arquivo => arquivo.IdBanco);

            builder.Property(user => user.AlteradoPor).HasColumnName("id_usuario_alteracao");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("id_usuario_criacao");
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao");
            builder.Property(user => user.EhAtivo).HasColumnName("id_status");
        }
    }
}