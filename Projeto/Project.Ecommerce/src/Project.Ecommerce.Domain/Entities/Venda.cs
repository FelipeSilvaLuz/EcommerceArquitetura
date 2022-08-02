namespace Project.Ecommerce.Domain.Entities
{
    public class Venda : BaseEntity
    {
        public int IdUsuario { get; set; }

        public int IdProduto { get; set; }

        public int IdEndereco { get; set; }

        public string TipoPagamento { get; set; }

        public int Valor { get; set; }

        public int Quantidade { get; set; }


        public Usuario Usuario { get; set; }

        public Produto Produto { get; set; }

        public Endereco Endereco { get; set; }
    }
}