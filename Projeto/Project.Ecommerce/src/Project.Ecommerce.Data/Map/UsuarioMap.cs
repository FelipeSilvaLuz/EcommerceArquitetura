using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb_usuarios");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnName("id_usuario").ValueGeneratedOnAdd();

            builder.Property(user => user.Nome).HasColumnName("nm_usuario").IsRequired();
            builder.Property(user => user.Email).HasColumnName("nm_email").IsRequired();
            builder.Property(user => user.Senha).HasColumnName("nm_senha").IsRequired();
            builder.Property(user => user.ReceberOfertas).HasColumnName("dv_recebeoferta");
            builder.Property(user => user.Perfil).HasColumnName("tp_perfil").IsRequired();

            builder.Ignore(x => x.AlteradoPor);
            builder.Ignore(x => x.AlteradoEm);
            builder.Ignore(x => x.CriadoPor);
            builder.Ignore(x => x.CriadoEm);
            builder.Ignore(x => x.EhAtivo);
        }
    }
}