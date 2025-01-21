using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContasApp.Migrations
{
    public partial class AddSaldoInicialToConta2222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaldoInicial",
                table: "Transacoes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SaldoInicial",
                table: "Transacoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
