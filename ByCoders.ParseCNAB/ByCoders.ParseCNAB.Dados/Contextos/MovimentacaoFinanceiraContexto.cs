using ByCoders.ParseCNAB.Dados.Extensoes;
using ByCoders.ParseCNAB.Dados.Mapeamentos;
using ByCoders.ParseCNAB.Dominio.Entidades;
using ByCoders.ParseCNAB.Dominio.ObjetosDeValor;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace ByCoders.ParseCNAB.Dados.Contextos
{
    public class MovimentacaoFinanceiraContexto : DbContext
    {
        public MovimentacaoFinanceiraContexto(DbContextOptions<MovimentacaoFinanceiraContexto> opcoes)
            : base(opcoes) { }

        public DbSet<MovimentacaoFinanaceira> MovimentacoesFinanceiras { get; set; }
        public DbSet<TipoTransacao> TiposTransacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<DataOcorrencia>();
            modelBuilder.Ignore<CPF>();
            modelBuilder.ApplyConfiguration(new MovimentacaoFinanceiraMapeamento());
            modelBuilder.ApplyConfiguration(new TipoTransacaoMapeamento());

            modelBuilder.SeeData();
        }
    }
}
