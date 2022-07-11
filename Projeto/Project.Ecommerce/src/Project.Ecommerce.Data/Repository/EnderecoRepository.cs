using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Data.Repository
{
    public class EnderecoRepository : CrudRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(EcommerceContext context) : base(context)
        {
        }
    }
}