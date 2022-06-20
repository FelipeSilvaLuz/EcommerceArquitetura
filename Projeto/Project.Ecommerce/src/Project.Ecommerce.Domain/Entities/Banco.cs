
namespace Project.Ecommerce.Domain.Entities
{
    public class Banco : BaseEntity
    {
        public string Nome { get; set; }

        public string IdStatus { get; set; }


        public Status Status { get; set; }
    }
}