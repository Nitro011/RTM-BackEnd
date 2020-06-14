using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class Usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_Produccion_Control_Piezas_Area_Produccion_Area_ProduccionID",
                table: "Area_Produccion_Control_Piezas");

            migrationBuilder.DropForeignKey(
                name: "FK_Area_Produccion_Materias_Primas_Area_Produccion_Area_ProduccionID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropForeignKey(
                name: "FK_Control_Ubicacion_Piezas_Area_Produccion_Area_ProduccionID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropTable(
                name: "Area_Produccion");

            migrationBuilder.DropIndex(
                name: "IX_Control_Ubicacion_Piezas_Area_ProduccionID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropIndex(
                name: "IX_Area_Produccion_Materias_Primas_Area_ProduccionID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropIndex(
                name: "IX_Area_Produccion_Control_Piezas_Area_ProduccionID",
                table: "Area_Produccion_Control_Piezas");

            migrationBuilder.DropColumn(
                name: "Area_ProduccionID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropColumn(
                name: "Area_ProduccionID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.AddColumn<int>(
                name: "AreaProduccionID",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contrasena",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorreoElectronico",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreDeUsuario",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaProduccionID",
                table: "Control_Ubicacion_Piezas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaProduccionID",
                table: "Area_Produccion_Materias_Primas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaProduccionID",
                table: "Area_Produccion_Control_Piezas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AreaProduccion",
                columns: table => new
                {
                    AreaProduccionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAreaProduccion = table.Column<string>(nullable: true)
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
                name: "FK_Usuarios_AreaProduccion_AreaProduccionID",
                table: "Usuarios",
                column: "AreaProduccionID",
                principalTable: "AreaProduccion",
                principalColumn: "AreaProduccionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_Usuarios_AreaProduccion_AreaProduccionID",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "AreaProduccion");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_AreaProduccionID",
                table: "Usuarios");

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
                name: "Contrasena",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CorreoElectronico",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NombreDeUsuario",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AreaProduccionID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropColumn(
                name: "AreaProduccionID",
                table: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropColumn(
                name: "AreaProduccionID",
                table: "Area_Produccion_Control_Piezas");

            migrationBuilder.AddColumn<int>(
                name: "Area_ProduccionID",
                table: "Control_Ubicacion_Piezas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Area_ProduccionID",
                table: "Area_Produccion_Materias_Primas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Area_Produccion",
                columns: table => new
                {
                    Area_ProduccionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Area_Produccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area_Produccion", x => x.Area_ProduccionID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Control_Ubicacion_Piezas_Area_ProduccionID",
                table: "Control_Ubicacion_Piezas",
                column: "Area_ProduccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Area_Produccion_Materias_Primas_Area_ProduccionID",
                table: "Area_Produccion_Materias_Primas",
                column: "Area_ProduccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Area_Produccion_Control_Piezas_Area_ProduccionID",
                table: "Area_Produccion_Control_Piezas",
                column: "Area_ProduccionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_Produccion_Control_Piezas_Area_Produccion_Area_ProduccionID",
                table: "Area_Produccion_Control_Piezas",
                column: "Area_ProduccionID",
                principalTable: "Area_Produccion",
                principalColumn: "Area_ProduccionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Area_Produccion_Materias_Primas_Area_Produccion_Area_ProduccionID",
                table: "Area_Produccion_Materias_Primas",
                column: "Area_ProduccionID",
                principalTable: "Area_Produccion",
                principalColumn: "Area_ProduccionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Control_Ubicacion_Piezas_Area_Produccion_Area_ProduccionID",
                table: "Control_Ubicacion_Piezas",
                column: "Area_ProduccionID",
                principalTable: "Area_Produccion",
                principalColumn: "Area_ProduccionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
