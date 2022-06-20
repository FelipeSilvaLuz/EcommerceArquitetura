using System;

namespace Project.Ecommerce.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int? CriadoPor { get; set; }
        public DateTime? CriadoEm { get; set; }

        public int? AlteradoPor { get; set; }
        public DateTime? AlteradoEm { get; set; }

        public int? Ativo { get; set; }


        public Status Status { get; set; }

        public Usuario UsuarioCriado { get; set; }

        public Usuario UsuarioAlterado { get; set; }
    }
}