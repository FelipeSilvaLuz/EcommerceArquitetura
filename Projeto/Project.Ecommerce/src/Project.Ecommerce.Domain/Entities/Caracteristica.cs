namespace Project.Ecommerce.Domain.Entities
{
    public class Caracteristica : BaseEntity
    {
        public int IdProduto { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int Ordem { get; set; }


        public Produto Produto { get; set; }
    }
}