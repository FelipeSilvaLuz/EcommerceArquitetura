namespace Project.Ecommerce.Domain.Entities
{
    public class Fotos : BaseEntity
    {
        public int IdProduto { get; set; }

        public int IdCategoria { get; set; }

        public int IdStatus { get; set; }

        public int Nome { get; set; }

        public int Base64 { get; set; }


        public Produto Produto { get; set; }

        public Categoria Categoria { get; set; }

        public Status Status { get; set; }
    }
}