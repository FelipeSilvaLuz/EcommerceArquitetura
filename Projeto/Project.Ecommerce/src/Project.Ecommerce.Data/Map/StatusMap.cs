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

            builder.Ignore(x => x.AlteradoPor);
            builder.Ignore(x => x.AlteradoEm);
            builder.Ignore(x => x.CriadoPor);
            builder.Ignore(x => x.CriadoEm);
            builder.Ignore(x => x.EhAtivo);
        }
    }
}