﻿using ByCoders.ParseCNAB.Dominio.Compartilhado.Enumeradores;
using ByCoders.ParseCNAB.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ByCoders.ParseCNAB.Dados.Extensoes
{
    public static class ModelBuilderExtensao
    {
        public static ModelBuilder SeeData(this ModelBuilder builder)
        {
            // Adiciona os tipos de transações
            builder.Entity<TipoTransacao>()
                .HasData(
                    new TipoTransacao(1, "Débito", ENatureza.Entrada),
                    new TipoTransacao(2, "Boleto", ENatureza.Saida),
                    new TipoTransacao(3, "Financiamento", ENatureza.Saida),
                    new TipoTransacao(4, "Crédito", ENatureza.Entrada ),
                    new TipoTransacao(5, "Recebimento Empréstimo", ENatureza.Entrada),
                    new TipoTransacao(6, "Vendas", ENatureza.Entrada),
                    new TipoTransacao(7, "Recebimento TED", ENatureza.Entrada),
                    new TipoTransacao(8, "Recebimento DOC", ENatureza.Entrada),
                    new TipoTransacao(9, "Aluguel", ENatureza.Saida)
                );

            // Adiciona os usuários principais
            builder.Entity<Usuario>()
                .HasData(
                    new Usuario(1, "Administrador", "administrador@email.com", "b99696fd2d4027e4e5bafc56f183237e")
                );
            return builder;
        }
    }
}
