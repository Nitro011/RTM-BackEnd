using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class AgregarNuevaRelacionAEstilos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaEstiloID",
                table: "Estilos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorID",
                table: "Estilos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModeloID",
                table: "Estilos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipo_CalzadoID",
                table: "Estilos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_CategoriaEstiloID",
                table: "Estilos",
                column: "CategoriaEstiloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_ColorID",
                table: "Estilos",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_ModeloID",
                table: "Estilos",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_Tipo_CalzadoID",
                table: "Estilos",
                column: "Tipo_CalzadoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Estilos_CategoriasEstilos_CategoriaEstiloID",
                table: "Estilos",
                column: "CategoriaEstiloID",
                principalTable: "CategoriasEstilos",
                principalColumn: "CategoriaEstiloID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estilos_Colores_ColorID",
                table: "Estilos",
                column: "ColorID",
                principalTable: "Colores",
                principalColumn: "ColorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estilos_Modelos_ModeloID",
                table: "Estilos",
                column: "ModeloID",
                principalTable: "Modelos",
                principalColumn: "ModeloID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estilos_Tipo_Calzados_Tipo_CalzadoID",
                table: "Estilos",
                column: "Tipo_CalzadoID",
                principalTable: "Tipo_Calzados",
                principalColumn: "Tipo_CalzadoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estilos_CategoriasEstilos_CategoriaEstiloID",
                table: "Estilos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estilos_Colores_ColorID",
                table: "Estilos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estilos_Modelos_ModeloID",
                table: "Estilos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estilos_Tipo_Calzados_Tipo_CalzadoID",
                table: "Estilos");

            migrationBuilder.DropIndex(
                name: "IX_Estilos_CategoriaEstiloID",
                table: "Estilos");

            migrationBuilder.DropIndex(
                name: "IX_Estilos_ColorID",
                table: "Estilos");

            migrationBuilder.DropIndex(
                name: "IX_Estilos_ModeloID",
                table: "Estilos");

            migrationBuilder.DropIndex(
                name: "IX_Estilos_Tipo_CalzadoID",
                table: "Estilos");

            migrationBuilder.DropColumn(
                name: "CategoriaEstiloID",
                table: "Estilos");

            migrationBuilder.DropColumn(
                name: "ColorID",
                table: "Estilos");

            migrationBuilder.DropColumn(
                name: "ModeloID",
                table: "Estilos");

            migrationBuilder.DropColumn(
                name: "Tipo_CalzadoID",
                table: "Estilos");
        }
    }
}
