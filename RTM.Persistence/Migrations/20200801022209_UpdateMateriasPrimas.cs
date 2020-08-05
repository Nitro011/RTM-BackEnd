using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class UpdateMateriasPrimas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Materias_Primas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartNo",
                table: "Materias_Primas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Materias_Primas");

            migrationBuilder.DropColumn(
                name: "PartNo",
                table: "Materias_Primas");
        }
    }
}
