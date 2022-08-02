using System;

namespace Project.Ecommerce.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public string CriadoPor { get; set; }

        public DateTime? CriadoEm { get; set; }

        public string AlteradoPor { get; set; }

        public DateTime? AlteradoEm { get; set; }

        public bool? EhAtivo { get; set; }
    }
}