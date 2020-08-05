using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class AgregarRelacionesDeSubDepartamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_Produccion_Materias_Primas_Materias_Primas_Materias_PrimasMateria_PrimaID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropIndex(
                name: "IX_Area_Produccion_Materias_Primas_Materias_PrimasMateria_PrimaID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropColumn(
                name: "Materias_PrimasMateria_PrimaID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.AddColumn<int>(
                name: "SubDepartamentoID",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubDepartamentoID",
                table: "Area_Produccion_Materias_Primas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SubDepartamentoID",
                table: "Usuarios",
                column: "SubDepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Area_Produccion_Materias_Primas_Materia_PrimaID",
                table: "Area_Produccion_Materias_Primas",
                column: "Materia_PrimaID");

            migrationBuilder.CreateIndex(
                name: "IX_Area_Produccion_Materias_Primas_SubDepartamentoID",
                table: "Area_Produccion_Materias_Primas",
                column: "SubDepartamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_Produccion_Materias_Primas_Materias_Primas_Materia_PrimaID",
                table: "Area_Produccion_Materias_Primas",
                column: "Materia_PrimaID",
                principalTable: "Materias_Primas",
                principalColumn: "Materia_PrimaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Area_Produccion_Materias_Primas_SubDepartamentos_SubDepartamentoID",
                table: "Area_Produccion_Materias_Primas",
                column: "SubDepartamentoID",
                principalTable: "SubDepartamentos",
                principalColumn: "SubDepartamentoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_SubDepartamentos_SubDepartamentoID",
                table: "Usuarios",
                column: "SubDepartamentoID",
                principalTable: "SubDepartamentos",
                principalColumn: "SubDepartamentoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_Produccion_Materias_Primas_Materias_Primas_Materia_PrimaID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropForeignKey(
                name: "FK_Area_Produccion_Materias_Primas_SubDepartamentos_SubDepartamentoID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_SubDepartamentos_SubDepartamentoID",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_SubDepartamentoID",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Area_Produccion_Materias_Primas_Materia_PrimaID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropIndex(
                name: "IX_Area_Produccion_Materias_Primas_SubDepartamentoID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropColumn(
                name: "SubDepartamentoID",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SubDepartamentoID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.AddColumn<int>(
                name: "Materias_PrimasMateria_PrimaID",
                table: "Area_Produccion_Materias_Primas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Area_Produccion_Materias_Primas_Materias_PrimasMateria_PrimaID",
                table: "Area_Produccion_Materias_Primas",
                column: "Materias_PrimasMateria_PrimaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_Produccion_Materias_Primas_Materias_Primas_Materias_PrimasMateria_PrimaID",
                table: "Area_Produccion_Materias_Primas",
                column: "Materias_PrimasMateria_PrimaID",
                principalTable: "Materias_Primas",
                principalColumn: "Materia_PrimaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
