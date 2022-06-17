using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Ecommerce.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public int IdCategoria { get; set; }

        public int IdVariacao { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public double Valor { get; set; }


        public Categoria Categoria { get; set; }

        public Variacao Variacao { get; set; }
    }
}