using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class ModificarBOM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOM_BOMDetalles");

            migrationBuilder.AddColumn<int>(
                name: "BOMID",
                table: "BOMDetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BOMDetalles_BOMID",
                table: "BOMDetalles",
                column: "BOMID");

            migrationBuilder.AddForeignKey(
                name: "FK_BOMDetalles_BOMs_BOMID",
                table: "BOMDetalles",
                column: "BOMID",
                principalTable: "BOMs",
                principalColumn: "BOMID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOMDetalles_BOMs_BOMID",
                table: "BOMDetalles");

            migrationBuilder.DropIndex(
                name: "IX_BOMDetalles_BOMID",
                table: "BOMDetalles");

            migrationBuilder.DropColumn(
                name: "BOMID",
                table: "BOMDetalles");

            migrationBuilder.CreateTable(
                name: "BOM_BOMDetalles",
                columns: table => new
                {
                    BOM_BOMDetalleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOMDetalleID = table.Column<int>(type: "int", nullable: false),
                    BOMID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOM_BOMDetalles", x => x.BOM_BOMDetalleID);
                    table.ForeignKey(
                        name: "FK_BOM_BOMDetalles_BOMDetalles_BOMDetalleID",
                        column: x => x.BOMDetalleID,
                        principalTable: "BOMDetalles",
                        principalColumn: "BOMDetalleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOM_BOMDetalles_BOMs_BOMID",
                        column: x => x.BOMID,
                        principalTable: "BOMs",
                        principalColumn: "BOMID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOM_BOMDetalles_BOMDetalleID",
                table: "BOM_BOMDetalles",
                column: "BOMDetalleID");

            migrationBuilder.CreateIndex(
                name: "IX_BOM_BOMDetalles_BOMID",
                table: "BOM_BOMDetalles",
                column: "BOMID");
        }
    }
}
