using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class UpdateRelacionesSubDepartamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_Produccion_Materias_Primas_Departamentos_DepartamentoID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropForeignKey(
                name: "FK_Control_Ubicacion_Piezas_Departamentos_DepartamentoID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Departamentos_DepartamentoID",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Departamentos_DepartamentoID",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DepartamentoID",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_DepartamentoID",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Control_Ubicacion_Piezas_DepartamentoID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropIndex(
                name: "IX_Area_Produccion_Materias_Primas_DepartamentoID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropColumn(
                name: "DepartamentoID",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DepartamentoID",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "DepartamentoID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropColumn(
                name: "DepartamentoID",
                table: "Area_Produccion_Materias_Primas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "Empleados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "Control_Ubicacion_Piezas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "Area_Produccion_Materias_Primas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DepartamentoID",
                table: "Usuarios",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_DepartamentoID",
                table: "Empleados",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Control_Ubicacion_Piezas_DepartamentoID",
                table: "Control_Ubicacion_Piezas",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Area_Produccion_Materias_Primas_DepartamentoID",
                table: "Area_Produccion_Materias_Primas",
                column: "DepartamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_Produccion_Materias_Primas_Departamentos_DepartamentoID",
                table: "Area_Produccion_Materias_Primas",
                column: "DepartamentoID",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Control_Ubicacion_Piezas_Departamentos_DepartamentoID",
                table: "Control_Ubicacion_Piezas",
                column: "DepartamentoID",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Departamentos_DepartamentoID",
                table: "Empleados",
                column: "DepartamentoID",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Departamentos_DepartamentoID",
                table: "Usuarios",
                column: "DepartamentoID",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
