using ByCoders.ParseCNAB.Dominio.Compartilhado.Entidades;

namespace ByCoders.ParseCNAB.Dominio.Entidades
{
    public class TipoTransacao : EntidadeGenerica
    {
        // TODO: 1- ADICIONAR FLUNT PARA NOTIFICAÇÕES (validações no construtor); 2 - LIMPAR USINGS 

        protected TipoTransacao(int id) : base(id) { }
        public TipoTransacao(int id, string descricao, string natureza) : base(id)
        {
            Descricao = descricao;
            Natureza = natureza;
        }

        public string Descricao { get; private set; }
        public string Natureza { get; private set; }
    }
}
