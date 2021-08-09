using ByCoders.ParseCNAB.Dominio.Entidades;
using ByCoders.ParseCNAB.Dominio.ObjetosDeValor;
using System;
using Xunit;

namespace ByCoders.ParseCNAB.Testes.Dominio
{
    public class TestesMovimentacaoFinanceira
    {
        private readonly DataOcorrencia _dataOcorrenciaCorreta;
        private readonly DataOcorrencia _dataOcorrenciaIncorreta;
        private readonly CPF _CPFCorreto;
        private readonly CPF _CPFIncorreto;
        private readonly string _nomeDonoLojaCorreto;
        private readonly string _nomeDonoLojaIncorreto;
        private readonly string _nomeLojaCorreto;
        private readonly string _nomeLojaIncorreto;

        public TestesMovimentacaoFinanceira()
        {
            _dataOcorrenciaCorreta = new DataOcorrencia(25, 10, 5, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            _dataOcorrenciaIncorreta = new DataOcorrencia(25, 10, 5, 14, DateTime.Now.Month + 1, DateTime.Now.Year);
            _CPFCorreto = new CPF("99056171089");
            _CPFIncorreto = new CPF("99056171080");
            _nomeDonoLojaCorreto = "Alberto Pereira";
            _nomeDonoLojaIncorreto = "Alberto Pereira da Silva Gonsalvez Ferreira Lima da Costa";
            _nomeLojaCorreto = "Alberto Variedades";
            _nomeLojaIncorreto = "Alberto Pereira da Silva Gonsalvez Ferreira Lima da Costa Variedades";
        }

        [Fact]
        [Trait("Movimentação Financeira", "Teste CPF Errado")]
        public void DadoUmCPFErradoDeveRetornarUmaNotificacao()
        {
            var movimentacaoFinanceira = new MovimentacaoFinanaceira(0, 2, _dataOcorrenciaCorreta, 25, _CPFIncorreto, "256541225", _nomeDonoLojaCorreto, _nomeLojaCorreto);
            Assert.Equal(1, movimentacaoFinanceira.Notifications.Count);
        }

        [Fact]
        [Trait("Movimentação Financeira", "Teste Data Superior a atual")]
        public void DadoUmaDataSuperiorAAtualDeveRetornarUmaNotificacao()
        {
            var movimentacaoFinanceira = new MovimentacaoFinanaceira(0, 2, _dataOcorrenciaIncorreta, 25, _CPFCorreto, "256541225", _nomeDonoLojaCorreto, _nomeLojaCorreto);
            Assert.Equal(1, movimentacaoFinanceira.Notifications.Count);
        }

        [Fact]
        [Trait("Movimentação Financeira", "Teste Nome Dono Loja Errado")]
        public void DadoUmNomeDonoLojaErradoDeveRetornarUmaNotificacao()
        {
            var movimentacaoFinanceira = new MovimentacaoFinanaceira(0, 2, _dataOcorrenciaCorreta, 25, _CPFCorreto, "256541225", _nomeDonoLojaIncorreto, _nomeLojaCorreto);
            Assert.Equal(1, movimentacaoFinanceira.Notifications.Count);
        }

        [Fact]
        [Trait("Movimentação Financeira", "Teste Nome Loja Errado")]
        public void DadoUmNomeLojaErradoDeveRetornarUmaNotificacao()
        {
            var movimentacaoFinanceira = new MovimentacaoFinanaceira(0, 2, _dataOcorrenciaCorreta, 25, _CPFCorreto, "256541225", _nomeDonoLojaCorreto, _nomeLojaIncorreto);
            Assert.Equal(1, movimentacaoFinanceira.Notifications.Count);
        }

        [Fact]
        [Trait("Movimentação Financeira", "Teste Entidade Correta")]
        public void DadoUmaMovimentacaoCorretaNaoDeveRetornarNotificacao()
        {
            var movimentacaoFinanceira = new MovimentacaoFinanaceira(0, 2, _dataOcorrenciaCorreta, 25, _CPFCorreto, "256541225", _nomeDonoLojaCorreto, _nomeLojaCorreto);
            Assert.True(movimentacaoFinanceira.IsValid);
        }
    }
}
