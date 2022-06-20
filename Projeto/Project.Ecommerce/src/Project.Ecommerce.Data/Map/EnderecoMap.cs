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
            builder.Property(user => user.Id).ValueGeneratedOnAdd();

            builder.HasOne(arquivo => arquivo.Usuario)
                .WithMany().HasForeignKey(arquivo => arquivo.IdUsuario);

            builder.HasOne(arquivo => arquivo.Status)
             .WithMany().HasForeignKey(arquivo => arquivo.IdStatus);

            builder.Property(user => user.NomeEndereco).IsRequired();
            builder.Property(user => user.Numero).IsRequired();
            builder.Property(user => user.Referencia);
            builder.Property(user => user.Estado);
            builder.Property(user => user.Cidade);
            builder.Property(user => user.Complemento);
            builder.Property(user => user.Bairro);
            builder.Property(user => user.Cep).IsRequired();

            builder.Property(user => user.AlteradoPor);
            builder.Property(user => user.AlteradoEm);
            builder.Property(user => user.CriadoPor).IsRequired();
            builder.Property(user => user.CriadoEm).IsRequired();
            builder.Property(user => user.Ativo).HasDefaultValue(true);
        }
    }
}