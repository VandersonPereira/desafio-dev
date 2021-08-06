using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ByCoders.ParseCNAB.Dados.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposTransacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Natureza = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTransacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacoesFinanceiras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOcorrencia = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    TipoTransacaoId = table.Column<int>(type: "INT", nullable: false),
                    Valor = table.Column<decimal>(type: "MONEY", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Cartao = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    DonoLoja = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    NomeLoja = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacoesFinanceiras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentacoesFinanceiras_TiposTransacao_TipoTransacaoId",
                        column: x => x.TipoTransacaoId,
                        principalTable: "TiposTransacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposTransacao",
                columns: new[] { "Id", "Descricao", "Natureza" },
                values: new object[,]
                {
                    { 1, "Débito", "Entrada" },
                    { 2, "Boleto", "Saída" },
                    { 3, "Financiamento", "Saída" },
                    { 4, "Crédito", "Entrada" },
                    { 5, "Recebimento Empréstimo", "Entrada" },
                    { 6, "Vendas", "Entrada" },
                    { 7, "Recebimento TED", "Entrada" },
                    { 8, "Recebimento DOC", "Entrada" },
                    { 9, "Aluguel", "Saída" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacoesFinanceiras_TipoTransacaoId",
                table: "MovimentacoesFinanceiras",
                column: "TipoTransacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentacoesFinanceiras");

            migrationBuilder.DropTable(
                name: "TiposTransacao");
        }
    }
}
