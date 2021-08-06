using ByCoders.ParseCNAB.Dominio.Compartilhado.Comandos;

namespace ByCoders.ParseCNAB.Dominio.Comandos.Resultados
{
    public class CriarRegistroMovimentacaoFinanceiraComandoResultado : IComandoResultado
    {
        public CriarRegistroMovimentacaoFinanceiraComandoResultado(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; set; }
    }
}
