﻿namespace Project.Ecommerce.Domain.Entities
{
    public class Carrinho : BaseEntity
    {
        public int IdUsuario { get; set; }

        public int IdProduto { get; set; }

        public int Quantidade { get; set; }


        public Usuario Usuario { get; set; }

        public Produto Produto { get; set; }
    }
}