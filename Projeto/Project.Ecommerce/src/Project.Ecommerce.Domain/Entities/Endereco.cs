namespace Project.Ecommerce.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public int IdUsuario { get; set; }

        public string NomeEndereco { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Estado { get; set; }

        public string Referencia { get; set; }


        public Usuario Usuario { get; set; }
    }
}