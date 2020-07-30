using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class updateEmpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaProduccionID",
                table: "Empleados",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoEmpleado",
                table: "Empleados",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIngreso",
                table: "Empleados",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolID",
                table: "Empleados",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_AreaProduccionID",
                table: "Empleados",
                column: "AreaProduccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_RolID",
                table: "Empleados",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_AreaProduccion_AreaProduccionID",
                table: "Empleados",
                column: "AreaProduccionID",
                principalTable: "AreaProduccion",
                principalColumn: "AreaProduccionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Roles_RolID",
                table: "Empleados",
                column: "RolID",
                principalTable: "Roles",
                principalColumn: "RolID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_AreaProduccion_AreaProduccionID",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Roles_RolID",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_AreaProduccionID",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_RolID",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "AreaProduccionID",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "CodigoEmpleado",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "FechaIngreso",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "RolID",
                table: "Empleados");
        }
    }
}
