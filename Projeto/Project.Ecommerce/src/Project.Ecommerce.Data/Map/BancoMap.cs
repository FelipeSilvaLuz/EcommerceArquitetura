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
            builder.Property(user => user.Id).ValueGeneratedOnAdd();

            builder.HasOne(arquivo => arquivo.Status)
                .WithMany().HasForeignKey(arquivo => arquivo.IdStatus);

            builder.Property(user => user.Nome).IsRequired();

            builder.Property(user => user.AlteradoPor);
            builder.Property(user => user.AlteradoEm);
            builder.Property(user => user.CriadoPor).IsRequired();
            builder.Property(user => user.CriadoEm).IsRequired();
            builder.Property(user => user.Ativo).HasDefaultValue(true);
        }
    }
}