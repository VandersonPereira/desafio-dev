using ByCoders.ParseCNAB.Dominio.Compartilhado.Entidades;
using ByCoders.ParseCNAB.Dominio.ObjetosDeValor;
using Flunt.Validations;

namespace ByCoders.ParseCNAB.Dominio.Entidades
{
    public class MovimentacaoFinanaceira : EntidadeGenerica
    {
        // TODO: 1- ADICIONAR FLUNT PARA NOTIFICAÇÕES (validações no construtor); 2 - LIMPAR USINGS 
        protected MovimentacaoFinanaceira(int id) : base (id) { }

        public MovimentacaoFinanaceira(int id, int tipoTransacaoId, DataOcorrencia dataOcorrencia, decimal valor, string cpf, string cartao, string donoLoja, string nomeLoja)
            : base (id)
        {
            TipoTransacaoId = tipoTransacaoId;
            DataOcorrencia = dataOcorrencia;
            Valor = valor;
            CPF = cpf;
            Cartao = cartao;
            DonoLoja = donoLoja;
            NomeLoja = nomeLoja;

            AddNotifications(new Contract<MovimentacaoFinanaceira>()
                .Requires());
        }

        public TipoTransacao TipoTransacao { get; private set; }
        public DataOcorrencia DataOcorrencia { get; private set; }
        public int TipoTransacaoId { get; private set; }
        public decimal  Valor { get; private set; }
        public string CPF { get; private set; }
        public string Cartao { get; private set; }
        public string DonoLoja { get; private set; }
        public string NomeLoja { get; private set; }
    }
}
