using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContasApp.Migrations
{
    public partial class AddSaldoInicialToConta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContaId1",
                table: "Transacoes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEntrada",
                table: "Transacoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "SaldoInicial",
                table: "Transacoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SaldoInicial",
                table: "Contas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Ganhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ganhos_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ContaId1",
                table: "Transacoes",
                column: "ContaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ganhos_ContaId",
                table: "Ganhos",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_ContaId1",
                table: "Transacoes",
                column: "ContaId1",
                principalTable: "Contas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_ContaId1",
                table: "Transacoes");

            migrationBuilder.DropTable(
                name: "Ganhos");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ContaId1",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "ContaId1",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "IsEntrada",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "SaldoInicial",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "SaldoInicial",
                table: "Contas");
        }
    }
}
