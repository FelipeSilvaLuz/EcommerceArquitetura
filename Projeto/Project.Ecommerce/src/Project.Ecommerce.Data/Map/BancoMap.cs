using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class BancoMap : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.ToTable("tb_bancos");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnName("id_banco").ValueGeneratedOnAdd();

            builder.Property(user => user.Nome).HasColumnName("nm_banco").IsRequired();

            builder.Property(user => user.AlteradoPor).HasColumnName("id_usuario_alteracao");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("id_usuario_criacao");
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao");
            builder.Property(user => user.EhAtivo).HasColumnName("eh_ativo");
        }
    }
}