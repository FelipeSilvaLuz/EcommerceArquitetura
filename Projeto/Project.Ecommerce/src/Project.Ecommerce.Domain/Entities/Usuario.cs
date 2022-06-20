namespace Project.Ecommerce.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }

        public string Perfil { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public bool? ReceberOfertas { get; set; }
    }
}