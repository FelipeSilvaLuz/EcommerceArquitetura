using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class ComentarioMap : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("tb_comentarios");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnName("id_comentario").ValueGeneratedOnAdd();

            builder.HasOne(arquivo => arquivo.Produto)
                .WithMany().HasForeignKey(arquivo => arquivo.IdProduto);

            builder.Property(user => user.Titulo).HasColumnName("nm_titulo").IsRequired();
            builder.Property(user => user.Texto).HasColumnName("nm_comentario").IsRequired();
            builder.Property(user => user.Nota).HasColumnName("nr_nota").HasDefaultValue(5);

            builder.Property(user => user.AlteradoPor).HasColumnName("id_usuario_alteracao");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("id_usuario_criacao");
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao");
            builder.Property(user => user.EhAtivo).HasColumnName("id_status");
        }
    }
}