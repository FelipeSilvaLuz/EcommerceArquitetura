using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("tb_enderecos");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnName("id_endereco").ValueGeneratedOnAdd();
            builder.Property(user => user.IdUsuario).HasColumnName("id_usuario");

            builder.HasOne(arquivo => arquivo.Usuario)
                .WithMany().HasForeignKey(arquivo => arquivo.IdUsuario);

            builder.Property(user => user.NomeEndereco).HasColumnName("nm_endereco").IsRequired();
            builder.Property(user => user.Numero).HasColumnName("nr_numero").IsRequired();
            builder.Property(user => user.Referencia).HasColumnName("nm_referencia");
            builder.Property(user => user.Estado).HasColumnName("nm_estado");
            builder.Property(user => user.Cidade).HasColumnName("nm_cidade");
            builder.Property(user => user.Complemento).HasColumnName("nr_complemento");
            builder.Property(user => user.Bairro).HasColumnName("nm_bairro");
            builder.Property(user => user.Cep).HasColumnName("nm_cep").IsRequired();

            builder.Property(user => user.AlteradoPor).HasColumnName("alterado_por");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("criado_por").IsRequired();
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao").IsRequired();
            builder.Property(user => user.EhAtivo).HasColumnName("eh_ativo");
        }
    }
}