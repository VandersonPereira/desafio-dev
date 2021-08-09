using ByCoders.ParseCNAB.Dominio.Compartilhado.Comandos;
using System;
using System.Collections.Generic;

namespace ByCoders.ParseCNAB.Dominio.Comandos.Resultados
{
    public class ListarRegistroMovimentacaoFinanceiraComandoResultado : IComandoResultado
    {
        public ListarRegistroMovimentacaoFinanceiraComandoResultado()
        {
            Movimentacoes = new List<MovimentacaoFinanceiraResultado>();
        }

        public string Mensagem { get; set; }
        public IList<MovimentacaoFinanceiraResultado> Movimentacoes { get; set; }
    }

    public class MovimentacaoFinanceiraResultado
    {
        public string TipoTransacao { get; set; }
        public int Natureza { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public decimal Valor { get; set; }
        public string CPF { get; set; }
        public string Cartao { get; set; }
        public string DonoLoja { get; set; }
        public string NomeLoja { get; set; }
    }
}
