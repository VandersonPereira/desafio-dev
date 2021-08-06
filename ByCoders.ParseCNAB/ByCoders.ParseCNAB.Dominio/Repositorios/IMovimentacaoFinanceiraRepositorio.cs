using ByCoders.ParseCNAB.Dominio.Entidades;
using System.Collections.Generic;

namespace ByCoders.ParseCNAB.Dominio.Repositorios
{
    public interface IMovimentacaoFinanceiraRepositorio
    {
        void Salvar(MovimentacaoFinanaceira movimentacaoFinanaceira);
        IList<MovimentacaoFinanaceira> Listar();
    }
}
