namespace ByCoders.ParseCNAB.Dados.Transacoes
{
    public interface IUow
    {
        void Commit();
        void RollBack();
    }
}
