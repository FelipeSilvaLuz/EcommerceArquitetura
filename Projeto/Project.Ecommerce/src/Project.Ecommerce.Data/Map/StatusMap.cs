using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class StatusMap : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("tb_status");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnName("id_status").ValueGeneratedOnAdd();

            builder.Property(user => user.Nome).HasColumnName("nm_nome").IsRequired();
            builder.Property(user => user.Descricao).HasColumnName("nm_descricao");

            builder.Property(user => user.AlteradoPor).HasColumnName("id_usuario_alteracao");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("id_usuario_criacao");
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao");
            builder.Property(user => user.Ativo).HasColumnName("id_status");
        }
    }
}