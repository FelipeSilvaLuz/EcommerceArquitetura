namespace Project.Ecommerce.Domain.Entities
{
    public class Caracteristica : BaseEntity
    {
        public int IdCategoria { get; set; }

        public int IdStatus { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int Ordem { get; set; }


        public Categoria Categoria { get; set; }

        public Status Status { get; set; }
    }
}