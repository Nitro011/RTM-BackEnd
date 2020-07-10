using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class ModificacionClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoCliente",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RNC",
                table: "Clientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoCliente",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "RNC",
                table: "Clientes");
        }
    }
}
