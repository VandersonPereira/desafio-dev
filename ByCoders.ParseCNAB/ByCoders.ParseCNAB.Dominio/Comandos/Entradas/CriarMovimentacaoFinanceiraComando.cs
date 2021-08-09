using ByCoders.ParseCNAB.Dominio.Compartilhado.Comandos;

namespace ByCoders.ParseCNAB.Dominio.Comandos.Entradas
{
    public class CriarMovimentacaoFinanceiraComando : IComando
    {
        public int TipoTransacaoId { get; set; }
        public decimal Valor { get; set; }
        public string CPF { get; set; }
        public string Cartao { get; set; }
        public string DonoLoja { get; set; }
        public string NomeLoja { get; set; }
    }
}
