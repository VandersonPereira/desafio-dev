﻿using ByCoders.ParseCNAB.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByCoders.ParseCNAB.Dados.Mapeamentos
{
    public class MovimentacaoFinanceiraMapeamento : IEntityTypeConfiguration<MovimentacaoFinanaceira>
    {
        // TODO: 1- IGNORAR NOTIFICAÇÕES (validações no construtor) 2- DESCOBRIR COMO COLOCAR O TIPOTRANSACAO E O DATAOCORRENCIA COMO NOTNULL NO BANCO;
        public void Configure(EntityTypeBuilder<MovimentacaoFinanaceira> builder)
        {
            builder.ToTable("MovimentacoesFinanceiras")
                .HasKey(x => x.Id);

            builder.Ignore(x => x.Notifications);

            builder.Property(x => x.TipoTransacaoId)
            .IsRequired()
            .HasColumnType("INT");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("MONEY");

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasColumnType("VARCHAR(11)");

            builder.Property(x => x.Cartao)
                .IsRequired()
                .HasColumnType("VARCHAR(20)");

            builder.Property(x => x.DonoLoja)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.NomeLoja)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.OwnsOne(p => p.DataOcorrencia)
                .Property(x => x.Data)
                .IsRequired()
                .HasColumnName("DataOcorrencia")
                .HasColumnType("DATETIME");

            builder.HasOne(p => p.TipoTransacao);
        }
    }
}
