using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class ModificarBOM2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOMs_Constructions_ConstructionID",
                table: "BOMs");

            migrationBuilder.DropIndex(
                name: "IX_BOMs_ConstructionID",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "ConstructionID",
                table: "BOMs");

            migrationBuilder.AddColumn<int>(
                name: "ModeloID",
                table: "BOMs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BOMs_ModeloID",
                table: "BOMs",
                column: "ModeloID");

            migrationBuilder.AddForeignKey(
                name: "FK_BOMs_Modelos_ModeloID",
                table: "BOMs",
                column: "ModeloID",
                principalTable: "Modelos",
                principalColumn: "ModeloID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOMs_Modelos_ModeloID",
                table: "BOMs");

            migrationBuilder.DropIndex(
                name: "IX_BOMs_ModeloID",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "ModeloID",
                table: "BOMs");

            migrationBuilder.AddColumn<int>(
                name: "ConstructionID",
                table: "BOMs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BOMs_ConstructionID",
                table: "BOMs",
                column: "ConstructionID");

            migrationBuilder.AddForeignKey(
                name: "FK_BOMs_Constructions_ConstructionID",
                table: "BOMs",
                column: "ConstructionID",
                principalTable: "Constructions",
                principalColumn: "ConstructionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
