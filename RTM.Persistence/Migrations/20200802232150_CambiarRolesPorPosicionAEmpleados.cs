using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class CambiarRolesPorPosicionAEmpleados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Roles_RolID",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_RolID",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "RolID",
                table: "Empleados");

            migrationBuilder.AddColumn<int>(
                name: "PosicionID",
                table: "Empleados",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PosicionID",
                table: "Empleados",
                column: "PosicionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Posiciones_PosicionID",
                table: "Empleados",
                column: "PosicionID",
                principalTable: "Posiciones",
                principalColumn: "PosicionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Posiciones_PosicionID",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_PosicionID",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "PosicionID",
                table: "Empleados");

            migrationBuilder.AddColumn<int>(
                name: "RolID",
                table: "Empleados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_RolID",
                table: "Empleados",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Roles_RolID",
                table: "Empleados",
                column: "RolID",
                principalTable: "Roles",
                principalColumn: "RolID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
