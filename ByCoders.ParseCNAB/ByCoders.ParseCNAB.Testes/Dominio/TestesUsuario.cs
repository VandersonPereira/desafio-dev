using ByCoders.ParseCNAB.Dominio.Entidades;
using Xunit;

namespace ByCoders.ParseCNAB.Testes.Dominio
{
    public class TestesUsuario
    {
        private readonly string _nomeCorreto;
        private readonly string _nomeIncorreto;
        private readonly string _emailCorreto;
        private readonly string _emailIncorreto;
        private readonly string _emailIncorretoPadrao;
        private readonly string _senhaCorreta;
        private readonly string _senhaIncorreta;

        public TestesUsuario()
        {
            _nomeCorreto = "Alberto Dias";
            _nomeIncorreto = "Alberto Dias Lucas Serafim Alfredo Xaviar Gonsalvez Matias da Silva Neto Junior";
            _emailCorreto = "email@email.com";
            _emailIncorreto = "email@emailAlberto_Dias_Lucas_Serafim_Alfredo_Xaviar_Gonsalvez_Matias_da_Silva_Neto_Junior.com";
            _emailIncorretoPadrao = "email.email.com";
            _senhaCorreta = "123456";
            _senhaIncorreta = "55555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555";

        }

        [Fact]
        [Trait("Usuário", "Teste Nome Errado")]
        public void DadoUmNomeErradoDeveRetornarUmaNotificacao()
        {
            var usuario = new Usuario(_nomeIncorreto, _emailCorreto, _senhaCorreta);
            Assert.Equal(1, usuario.Notifications.Count);
        }

        [Fact]
        [Trait("Usuário", "Teste E-mail Errado Pdrão")]
        public void DadoUmEmailErradoPadraoDeveRetornarUmaNotificacao()
        {
            var usuario = new Usuario(_nomeCorreto, _emailIncorretoPadrao, _senhaCorreta);
            Assert.Equal(1, usuario.Notifications.Count);
        }

        [Fact]
        [Trait("Usuário", "Teste E-mail Errado")]
        public void DadoUmEmailErradoDeveRetornarUmaNotificacao()
        {
            var usuario = new Usuario(_nomeCorreto, _emailIncorreto, _senhaCorreta);
            Assert.Equal(1, usuario.Notifications.Count);
        }

        [Fact]
        [Trait("Usuário", "Teste Senha Errada")]
        public void DadoUmaSenhaErradaDeveRetornarUmaNotificacao()
        {
            var usuario = new Usuario(_nomeCorreto, _emailCorreto, _senhaIncorreta);
            Assert.Equal(1, usuario.Notifications.Count);
        }

        [Fact]
        [Trait("Usuário", "Teste Entidade Correta")]
        public void DadoUmaMovimentacaoCorretaNaoDeveRetornarNotificacao()
        {
            var usuario = new Usuario(_nomeCorreto, _emailCorreto, _senhaCorreta);
            Assert.True(usuario.IsValid);
        }
    }
}
