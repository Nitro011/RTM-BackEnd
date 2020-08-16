using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class AgregarDivisionesMateriasPrimas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre_Materia_Prima",
                table: "Materias_Primas");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Materias_Primas",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DivisionMateriaPrimaID",
                table: "Materias_Primas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Materias_Primas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DivisionesMateriasPrimas",
                columns: table => new
                {
                    DivisionMateriaPrimaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Division = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionesMateriasPrimas", x => x.DivisionMateriaPrimaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materias_Primas_DivisionMateriaPrimaID",
                table: "Materias_Primas",
                column: "DivisionMateriaPrimaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Primas_DivisionesMateriasPrimas_DivisionMateriaPrimaID",
                table: "Materias_Primas",
                column: "DivisionMateriaPrimaID",
                principalTable: "DivisionesMateriasPrimas",
                principalColumn: "DivisionMateriaPrimaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Primas_DivisionesMateriasPrimas_DivisionMateriaPrimaID",
                table: "Materias_Primas");

            migrationBuilder.DropTable(
                name: "DivisionesMateriasPrimas");

            migrationBuilder.DropIndex(
                name: "IX_Materias_Primas_DivisionMateriaPrimaID",
                table: "Materias_Primas");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Materias_Primas");

            migrationBuilder.DropColumn(
                name: "DivisionMateriaPrimaID",
                table: "Materias_Primas");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Materias_Primas");

            migrationBuilder.AddColumn<string>(
                name: "Nombre_Materia_Prima",
                table: "Materias_Primas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
