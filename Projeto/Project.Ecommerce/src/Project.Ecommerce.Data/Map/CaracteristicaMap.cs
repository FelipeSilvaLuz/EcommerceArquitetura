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
            builder.Property(user => user.Id).HasColumnName("id_carasteristica").ValueGeneratedOnAdd();
            builder.Property(user => user.IdCategoria).HasColumnName("id_categoria");

            builder.HasOne(arquivo => arquivo.Categoria)
                .WithMany().HasForeignKey(arquivo => arquivo.IdCategoria);

            builder.Property(user => user.Nome).HasColumnName("nm_caracteristica").IsRequired();
            builder.Property(user => user.Ordem).HasColumnName("nr_ordem").HasDefaultValue(false);
            builder.Property(user => user.Descricao).HasColumnName("nm_descricao").IsRequired();

            builder.Property(user => user.AlteradoPor).HasColumnName("id_usuario_alteracao");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("id_usuario_criacao");
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao");
            builder.Property(user => user.EhAtivo).HasColumnName("id_status");
        }
    }
}