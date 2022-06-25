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
            builder.Property(user => user.ReceberOfertas).HasColumnName("dv_recebeoferta").HasDefaultValue(false);
            builder.Property(user => user.Perfil).HasColumnName("tp_perfil").IsRequired();

            builder.HasOne(arquivo => arquivo.UsuarioCriado)
                .WithMany().HasForeignKey(arquivo => arquivo.CriadoPor);

            builder.HasOne(arquivo => arquivo.UsuarioAlterado)
                .WithMany().HasForeignKey(arquivo => arquivo.AlteradoPor);

            builder.Property(user => user.AlteradoPor).HasColumnName("id_usuario_alteracao");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("id_usuario_criacao");
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao");
            builder.Property(user => user.Ativo).HasColumnName("id_status");

            builder.Ignore(x => x.Status);
        }
    }
}