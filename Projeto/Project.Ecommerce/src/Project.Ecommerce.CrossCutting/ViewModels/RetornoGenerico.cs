using System.Collections.Generic;

namespace Project.Ecommerce.CrossCutting.ViewModels
{
    public class RetornoGenerico
    {
        public RetornoGenerico(bool sucesso, List<string> mensagens)
        {
            Sucesso = sucesso;
            Mensagens = mensagens;
        }

        public List<string> Mensagens { get; set; }

        public bool Sucesso { get; set; }
    }
}