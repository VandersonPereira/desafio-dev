using ByCoders.ParseCNAB.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByCoders.ParseCNAB.Dados.Mapeamentos
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios")
                .HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");
        }
    }
}
