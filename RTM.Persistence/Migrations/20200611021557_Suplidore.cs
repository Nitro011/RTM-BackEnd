using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class Suplidore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Suplidores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "Suplidores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Suplidores",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Suplidores");

            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "Suplidores");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Suplidores");
        }
    }
}
