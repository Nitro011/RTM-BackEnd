using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class AgregarSubDepartamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubDepartamentoID",
                table: "Empleados",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubDepartamentoID",
                table: "Departamentos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubDepartamentoID",
                table: "Control_Ubicacion_Piezas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubDepartamentos",
                columns: table => new
                {
                    SubDepartamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubDepartamento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDepartamentos", x => x.SubDepartamentoID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_SubDepartamentoID",
                table: "Empleados",
                column: "SubDepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_SubDepartamentoID",
                table: "Departamentos",
                column: "SubDepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Control_Ubicacion_Piezas_SubDepartamentoID",
                table: "Control_Ubicacion_Piezas",
                column: "SubDepartamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Control_Ubicacion_Piezas_SubDepartamentos_SubDepartamentoID",
                table: "Control_Ubicacion_Piezas",
                column: "SubDepartamentoID",
                principalTable: "SubDepartamentos",
                principalColumn: "SubDepartamentoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_SubDepartamentos_SubDepartamentoID",
                table: "Departamentos",
                column: "SubDepartamentoID",
                principalTable: "SubDepartamentos",
                principalColumn: "SubDepartamentoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_SubDepartamentos_SubDepartamentoID",
                table: "Empleados",
                column: "SubDepartamentoID",
                principalTable: "SubDepartamentos",
                principalColumn: "SubDepartamentoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Control_Ubicacion_Piezas_SubDepartamentos_SubDepartamentoID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_SubDepartamentos_SubDepartamentoID",
                table: "Departamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_SubDepartamentos_SubDepartamentoID",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "SubDepartamentos");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_SubDepartamentoID",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_SubDepartamentoID",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Control_Ubicacion_Piezas_SubDepartamentoID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropColumn(
                name: "SubDepartamentoID",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "SubDepartamentoID",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "SubDepartamentoID",
                table: "Control_Ubicacion_Piezas");
        }
    }
}
