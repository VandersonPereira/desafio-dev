using ByCoders.ParseCNAB.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ByCoders.ParseCNAB.Dados.Extensoes
{
    public static class ModelBuilderExtensao
    {
        public static ModelBuilder SeeData(this ModelBuilder builder)
        {
            builder.Entity<TipoTransacao>()
                .HasData(
                    new TipoTransacao(1, "Débito", "Entrada"),
                    new TipoTransacao(2,"Boleto", "Saída"),
                    new TipoTransacao(3,"Financiamento", "Saída"),
                    new TipoTransacao(4,"Crédito", "Entrada"),
                    new TipoTransacao(5,"Recebimento Empréstimo", "Entrada"),
                    new TipoTransacao(6,"Vendas", "Entrada"),
                    new TipoTransacao(7,"Recebimento TED", "Entrada"),
                    new TipoTransacao(8,"Recebimento DOC", "Entrada"),
                    new TipoTransacao(9,"Aluguel", "Saída")
                );
            return builder;
        }
    }
}
