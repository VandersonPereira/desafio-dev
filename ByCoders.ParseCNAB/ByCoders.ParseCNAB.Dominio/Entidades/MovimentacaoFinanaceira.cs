using ByCoders.ParseCNAB.Dominio.Compartilhado.Entidades;
using ByCoders.ParseCNAB.Dominio.ObjetosDeValor;
using Flunt.Validations;

namespace ByCoders.ParseCNAB.Dominio.Entidades
{
    public class MovimentacaoFinanaceira : EntidadeGenerica
    {
        protected MovimentacaoFinanaceira() { }

        public MovimentacaoFinanaceira(int tipoTransacaoId, DataOcorrencia dataOcorrencia, decimal valor, CPF cpf, string cartao, string donoLoja, string nomeLoja)
        {
            TipoTransacaoId = tipoTransacaoId;
            DataOcorrencia = dataOcorrencia;
            Valor = valor;
            CPF = cpf;
            Cartao = cartao;
            DonoLoja = donoLoja;
            NomeLoja = nomeLoja;

            AddNotifications(new Contract<MovimentacaoFinanaceira>()
                .Requires()
                .IsGreaterThan(20, Cartao.Length, "Cartão", "O número do cartão não pode ter mais do que 20 caracteres!")
                .IsGreaterThan(50, DonoLoja.Length, "Dono Loja", "O nome do dono da loja não pode ter mais do que 50 caracteres!")
                .IsGreaterThan(50, NomeLoja.Length, "Nome Loja", "O nome da loja não pode ter mais do que 50 caracteres!"));

            AddNotifications(DataOcorrencia.Notifications);
            AddNotifications(CPF.Notifications);
        }

        public TipoTransacao TipoTransacao { get; private set; }
        public DataOcorrencia DataOcorrencia { get; private set; }
        public int TipoTransacaoId { get; private set; }
        public decimal  Valor { get; private set; }
        public CPF CPF { get; private set; }
        public string Cartao { get; private set; }
        public string DonoLoja { get; private set; }
        public string NomeLoja { get; private set; }
    }
}
