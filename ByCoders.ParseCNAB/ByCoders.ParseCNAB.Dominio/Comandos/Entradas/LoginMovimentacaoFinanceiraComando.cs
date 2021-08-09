using ByCoders.ParseCNAB.Dominio.Compartilhado.Comandos;

namespace ByCoders.ParseCNAB.Dominio.Comandos.Entradas
{
    public class LoginMovimentacaoFinanceiraComando : IComando
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
