using Project.Ecommerce.Data.Context;
using Project.Ecommerce.Domain.Entities;
using Project.Ecommerce.Domain.Interfaces;

namespace Project.Ecommerce.Data.Repository
{
    public class ComentarioRepository : CrudRepository<Comentario>, IComentarioRepository
    {
        public ComentarioRepository(EcommerceContext context) : base(context)
        {

        }
    }
}