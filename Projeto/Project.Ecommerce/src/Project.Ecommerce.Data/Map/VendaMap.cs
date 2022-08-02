﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Ecommerce.Domain.Entities;

namespace Project.Ecommerce.Data.Map
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("tb_vendas");

            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnName("id_venda").ValueGeneratedOnAdd();
            builder.Property(user => user.IdUsuario).HasColumnName("id_usuario");
            builder.Property(user => user.IdProduto).HasColumnName("id_produto");
            builder.Property(user => user.IdEndereco).HasColumnName("id_endereco");

            builder.HasOne(arquivo => arquivo.Usuario)
              .WithMany().HasForeignKey(arquivo => arquivo.IdUsuario);

            builder.HasOne(arquivo => arquivo.Produto)
              .WithMany().HasForeignKey(arquivo => arquivo.IdProduto);

            builder.HasOne(arquivo => arquivo.Endereco)
              .WithMany().HasForeignKey(arquivo => arquivo.IdEndereco);

            builder.Property(user => user.TipoPagamento).HasColumnName("tp_pagamento").IsRequired();
            builder.Property(user => user.Valor).HasColumnName("nr_valor").IsRequired();
            builder.Property(user => user.Quantidade).HasColumnName("nr_quantidade").IsRequired();

            builder.Property(user => user.AlteradoPor).HasColumnName("alterado_por");
            builder.Property(user => user.AlteradoEm).HasColumnName("dt_alteracao");
            builder.Property(user => user.CriadoPor).HasColumnName("criado_por");
            builder.Property(user => user.CriadoEm).HasColumnName("dt_criacao");
            builder.Property(user => user.EhAtivo).HasColumnName("eh_ativo");
        }
    }
}