using ByCoders.ParseCNAB.Dados.Contextos;

namespace ByCoders.ParseCNAB.Dados.Transacoes
{
    public class Uow : IUow
    {
        private readonly MovimentacaoFinanceiraContexto _context;

        public Uow(MovimentacaoFinanceiraContexto context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
            // Não é necessário fazer nada por aqui! See you! =)
        }
    }
}
