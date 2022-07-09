
namespace Project.Ecommerce.Domain.Entities
{
    public class TipoPagamento : BaseEntity
    {
        public string Nome { get; set; }
        public string IdBanco { get; set; }


        public Banco Banco { get; set; }
    }
}