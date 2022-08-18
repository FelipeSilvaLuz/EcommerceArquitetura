namespace Project.Ecommerce.Domain.Entities
{
    public class Foto : BaseEntity
    {
        public int IdProduto { get; set; }

        public int IdCategoria { get; set; }

        public string Nome { get; set; }

        public string Base64 { get; set; }


        public Produto Produto { get; set; }

        public Categoria Categoria { get; set; }
    }
}