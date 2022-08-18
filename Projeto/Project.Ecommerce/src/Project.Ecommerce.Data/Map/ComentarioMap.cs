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
            builder.Property(user => user.IdProduto).HasColumnName("id_produto");

            builder.HasOne(arquivo => arquivo.Produto)
                .WithMany().HasForeignKey(arquivo => arquivo.IdProduto);

            builder.Property(user => user.Titulo).HasColumnName("nm_titulo").IsRequired();
            builder.Property(user => user.Texto).HasColumnName("nm_comentario").IsRequired();
            builder.Property(user => user.Nota).HasColumnName("nr_nota").HasDefaultValue(5);

            builder.Property(user => user.AlteradoPor).HasColumnName("alterado_por");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("criado_por");
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao");

            builder.Ignore(x => x.EhAtivo);
        }
    }
}