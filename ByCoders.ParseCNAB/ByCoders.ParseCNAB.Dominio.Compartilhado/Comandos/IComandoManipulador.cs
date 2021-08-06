namespace ByCoders.ParseCNAB.Dominio.Compartilhado.Comandos
{
    public interface IComandoManipulador<T> where T : IComando
    {
        IComandoResultado Manipular(T comando);
    }
}
