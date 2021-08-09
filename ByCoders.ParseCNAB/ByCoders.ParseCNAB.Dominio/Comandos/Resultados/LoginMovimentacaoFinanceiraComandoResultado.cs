using ByCoders.ParseCNAB.Dominio.Compartilhado.Comandos;

namespace ByCoders.ParseCNAB.Dominio.Comandos.Resultados
{
    public class LoginMovimentacaoFinanceiraComandoResultado : IComandoResultado
    {
        public LoginMovimentacaoFinanceiraComandoResultado(string nome, string token, string mensagem)
        {
            Nome = nome;
            Token = token;
            Mensagem = mensagem;
        }

        public string Nome { get; set; }
        public string Token { get; set; }
        public string Mensagem { get; set; }
    }
}
