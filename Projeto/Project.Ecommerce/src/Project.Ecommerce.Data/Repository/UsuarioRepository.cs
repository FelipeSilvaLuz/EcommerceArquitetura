using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Data.Repository
{
    public class UsuarioRepository : CrudRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(EcommerceContext context) : base(context)
        {
        }
    }
}