using ByCoders.ParseCNAB.Dados.Contextos;
using ByCoders.ParseCNAB.Dominio.Entidades;
using ByCoders.ParseCNAB.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ByCoders.ParseCNAB.Dados.Repositorios
{
    public class MovimentacaoFinanceiraRepositorio : IMovimentacaoFinanceiraRepositorio
    {
        private readonly MovimentacaoFinanceiraContexto _contexto;

        public MovimentacaoFinanceiraRepositorio(MovimentacaoFinanceiraContexto contexto)
        {
            _contexto = contexto;
        }

        public void Salvar(MovimentacaoFinanaceira movimentacaoFinanaceira)
        {
            _contexto.MovimentacoesFinanceiras.Add(movimentacaoFinanaceira);
        }

        public IList<MovimentacaoFinanaceira> Listar()
        {
            return _contexto.MovimentacoesFinanceiras
                .AsNoTracking()
                .Include(x => x.TipoTransacao)
                .ToList();
        }
    }
}
