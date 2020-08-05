using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class AgregarTiposDepartamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_Produccion_Control_Piezas_AreaProduccion_AreaProduccionID",
                table: "Area_Produccion_Control_Piezas");

            migrationBuilder.DropForeignKey(
                name: "FK_Area_Produccion_Materias_Primas_AreaProduccion_AreaProduccionID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropForeignKey(
                name: "FK_Control_Ubicacion_Piezas_AreaProduccion_AreaProduccionID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_AreaProduccion_AreaProduccionID",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_AreaProduccion_AreaProduccionID",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "AreaProduccion");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_AreaProduccionID",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_AreaProduccionID",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Control_Ubicacion_Piezas_AreaProduccionID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropIndex(
                name: "IX_Area_Produccion_Materias_Primas_AreaProduccionID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropIndex(
                name: "IX_Area_Produccion_Control_Piezas_AreaProduccionID",
                table: "Area_Produccion_Control_Piezas");

            migrationBuilder.DropColumn(
                name: "AreaProduccionID",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AreaProduccionID",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "AreaProduccionID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropColumn(
                name: "AreaProduccionID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropColumn(
                name: "AreaProduccionID",
                table: "Area_Produccion_Control_Piezas");

            migrationBuilder.DropColumn(
                name: "Area_ProduccionID",
                table: "Area_Produccion_Control_Piezas");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "Empleados",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "Control_Ubicacion_Piezas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "Area_Produccion_Materias_Primas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "Area_Produccion_Control_Piezas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TiposDepartamentos",
                columns: table => new
                {
                    TipoDepartamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDepartamento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDepartamentos", x => x.TipoDepartamentoID);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDepartamentoID = table.Column<int>(nullable: true),
                    Departamento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoID);
                    table.ForeignKey(
                        name: "FK_Departamentos_TiposDepartamentos_TipoDepartamentoID",
                        column: x => x.TipoDepartamentoID,
                        principalTable: "TiposDepartamentos",
                        principalColumn: "TipoDepartamentoID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Area_Produccion_Control_Piezas_DepartamentoID",
                table: "Area_Produccion_Control_Piezas",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_TipoDepartamentoID",
                table: "Departamentos",
                column: "TipoDepartamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_Produccion_Control_Piezas_Departamentos_DepartamentoID",
                table: "Area_Produccion_Control_Piezas",
                column: "DepartamentoID",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_Produccion_Control_Piezas_Departamentos_DepartamentoID",
                table: "Area_Produccion_Control_Piezas");

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

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "TiposDepartamentos");

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

            migrationBuilder.DropIndex(
                name: "IX_Area_Produccion_Control_Piezas_DepartamentoID",
                table: "Area_Produccion_Control_Piezas");

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

            migrationBuilder.DropColumn(
                name: "DepartamentoID",
                table: "Area_Produccion_Control_Piezas");

            migrationBuilder.AddColumn<int>(
                name: "AreaProduccionID",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaProduccionID",
                table: "Empleados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaProduccionID",
                table: "Control_Ubicacion_Piezas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaProduccionID",
                table: "Area_Produccion_Materias_Primas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaProduccionID",
                table: "Area_Produccion_Control_Piezas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Area_ProduccionID",
                table: "Area_Produccion_Control_Piezas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AreaProduccion",
                columns: table => new
                {
                    AreaProduccionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAreaProduccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaProduccion", x => x.AreaProduccionID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_AreaProduccionID",
                table: "Usuarios",
                column: "AreaProduccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_AreaProduccionID",
                table: "Empleados",
                column: "AreaProduccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Control_Ubicacion_Piezas_AreaProduccionID",
                table: "Control_Ubicacion_Piezas",
                column: "AreaProduccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Area_Produccion_Materias_Primas_AreaProduccionID",
                table: "Area_Produccion_Materias_Primas",
                column: "AreaProduccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Area_Produccion_Control_Piezas_AreaProduccionID",
                table: "Area_Produccion_Control_Piezas",
                column: "AreaProduccionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_Produccion_Control_Piezas_AreaProduccion_AreaProduccionID",
                table: "Area_Produccion_Control_Piezas",
                column: "AreaProduccionID",
                principalTable: "AreaProduccion",
                principalColumn: "AreaProduccionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Area_Produccion_Materias_Primas_AreaProduccion_AreaProduccionID",
                table: "Area_Produccion_Materias_Primas",
                column: "AreaProduccionID",
                principalTable: "AreaProduccion",
                principalColumn: "AreaProduccionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Control_Ubicacion_Piezas_AreaProduccion_AreaProduccionID",
                table: "Control_Ubicacion_Piezas",
                column: "AreaProduccionID",
                principalTable: "AreaProduccion",
                principalColumn: "AreaProduccionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_AreaProduccion_AreaProduccionID",
                table: "Empleados",
                column: "AreaProduccionID",
                principalTable: "AreaProduccion",
                principalColumn: "AreaProduccionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_AreaProduccion_AreaProduccionID",
                table: "Usuarios",
                column: "AreaProduccionID",
                principalTable: "AreaProduccion",
                principalColumn: "AreaProduccionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
