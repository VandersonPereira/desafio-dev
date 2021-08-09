using ByCoders.ParseCNAB.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByCoders.ParseCNAB.Dados.Mapeamentos
{
    public class TipoTransacaoMapeamento : IEntityTypeConfiguration<TipoTransacao>
    {
        // TODO: 1- IGNORAR NOTIFICAÇÕES (validações no construtor);
        public void Configure(EntityTypeBuilder<TipoTransacao> builder)
        {
            builder.ToTable("TiposTransacao")
                .HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.Natureza)
                .IsRequired()
                .HasColumnType("INT");
        }
    }
}
