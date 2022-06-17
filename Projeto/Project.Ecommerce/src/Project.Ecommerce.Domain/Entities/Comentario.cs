namespace Project.Ecommerce.Domain.Entities
{
    public class Comentario : BaseEntity
    {
        public int IdProduto { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public int Nota { get; set; }
    }
}