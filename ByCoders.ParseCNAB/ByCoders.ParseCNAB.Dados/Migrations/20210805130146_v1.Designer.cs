﻿// <auto-generated />
using System;
using ByCoders.ParseCNAB.Dados.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ByCoders.ParseCNAB.Dados.Migrations
{
    [DbContext(typeof(MovimentacaoFinanceiraContexto))]
    [Migration("20210805130146_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ByCoders.ParseCNAB.Dominio.Entidades.MovimentacaoFinanaceira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("Cartao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("DonoLoja")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("NomeLoja")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("TipoTransacaoId")
                        .HasColumnType("INT");

                    b.Property<decimal>("Valor")
                        .HasColumnType("MONEY");

                    b.HasKey("Id");

                    b.HasIndex("TipoTransacaoId");

                    b.ToTable("MovimentacoesFinanceiras");
                });

            modelBuilder.Entity("ByCoders.ParseCNAB.Dominio.Entidades.TipoTransacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Natureza")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("TiposTransacao");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Débito",
                            Natureza = "Entrada"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Boleto",
                            Natureza = "Saída"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Financiamento",
                            Natureza = "Saída"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Crédito",
                            Natureza = "Entrada"
                        },
                        new
                        {
                            Id = 5,
                            Descricao = "Recebimento Empréstimo",
                            Natureza = "Entrada"
                        },
                        new
                        {
                            Id = 6,
                            Descricao = "Vendas",
                            Natureza = "Entrada"
                        },
                        new
                        {
                            Id = 7,
                            Descricao = "Recebimento TED",
                            Natureza = "Entrada"
                        },
                        new
                        {
                            Id = 8,
                            Descricao = "Recebimento DOC",
                            Natureza = "Entrada"
                        },
                        new
                        {
                            Id = 9,
                            Descricao = "Aluguel",
                            Natureza = "Saída"
                        });
                });

            modelBuilder.Entity("ByCoders.ParseCNAB.Dominio.Entidades.MovimentacaoFinanaceira", b =>
                {
                    b.HasOne("ByCoders.ParseCNAB.Dominio.Entidades.TipoTransacao", "TipoTransacao")
                        .WithMany()
                        .HasForeignKey("TipoTransacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ByCoders.ParseCNAB.Dominio.ObjetosDeValor.DataOcorrencia", "DataOcorrencia", b1 =>
                        {
                            b1.Property<int>("MovimentacaoFinanaceiraId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("Data")
                                .HasColumnType("DATETIME")
                                .HasColumnName("DataOcorrencia");

                            b1.HasKey("MovimentacaoFinanaceiraId");

                            b1.ToTable("MovimentacoesFinanceiras");

                            b1.WithOwner()
                                .HasForeignKey("MovimentacaoFinanaceiraId");
                        });

                    b.Navigation("DataOcorrencia");

                    b.Navigation("TipoTransacao");
                });
#pragma warning restore 612, 618
        }
    }
}
