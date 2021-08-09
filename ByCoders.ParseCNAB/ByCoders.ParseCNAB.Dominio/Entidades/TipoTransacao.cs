using ByCoders.ParseCNAB.Dominio.Compartilhado.Entidades;
using ByCoders.ParseCNAB.Dominio.Compartilhado.Enumeradores;

namespace ByCoders.ParseCNAB.Dominio.Entidades
{
    public class TipoTransacao : EntidadeGenerica
    {
        protected TipoTransacao(int id) : base(id) { }
        public TipoTransacao(int id, string descricao, ENatureza natureza) : base(id)
        {
            Descricao = descricao;
            Natureza = natureza;
        }

        public string Descricao { get; private set; }
        public ENatureza Natureza { get; private set; }
    }
}
