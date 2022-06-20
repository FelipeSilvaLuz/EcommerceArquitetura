using Project.Ecommerce.Domain.Entities;
using System.Collections.Generic;

namespace Project.Ecommerce.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        List<Usuario> Listar();
    }
}