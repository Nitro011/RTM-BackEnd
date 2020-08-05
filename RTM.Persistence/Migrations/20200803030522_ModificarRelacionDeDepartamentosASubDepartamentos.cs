using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class ModificarRelacionDeDepartamentosASubDepartamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_SubDepartamentos_SubDepartamentoID",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_SubDepartamentoID",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "SubDepartamentoID",
                table: "Departamentos");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "SubDepartamentos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubDepartamentos_DepartamentoID",
                table: "SubDepartamentos",
                column: "DepartamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubDepartamentos_Departamentos_DepartamentoID",
                table: "SubDepartamentos",
                column: "DepartamentoID",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubDepartamentos_Departamentos_DepartamentoID",
                table: "SubDepartamentos");

            migrationBuilder.DropIndex(
                name: "IX_SubDepartamentos_DepartamentoID",
                table: "SubDepartamentos");

            migrationBuilder.DropColumn(
                name: "DepartamentoID",
                table: "SubDepartamentos");

            migrationBuilder.AddColumn<int>(
                name: "SubDepartamentoID",
                table: "Departamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_SubDepartamentoID",
                table: "Departamentos",
                column: "SubDepartamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_SubDepartamentos_SubDepartamentoID",
                table: "Departamentos",
                column: "SubDepartamentoID",
                principalTable: "SubDepartamentos",
                principalColumn: "SubDepartamentoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
