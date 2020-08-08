using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class AgregarBOMYBOMDetalles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOMs_Colores_ColorID",
                table: "BOMs");

            migrationBuilder.DropForeignKey(
                name: "FK_BOMs_Sizes_SizeID",
                table: "BOMs");

            migrationBuilder.DropIndex(
                name: "IX_BOMs_ColorID",
                table: "BOMs");

            migrationBuilder.DropIndex(
                name: "IX_BOMs_SizeID",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "ColorID",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "Construction",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "Customer",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "DIE",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "Item",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "Last",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "PartNo",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "PatternName",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "Pattn",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "SizeID",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "Usage",
                table: "BOMs");

            migrationBuilder.AddColumn<int>(
                name: "ClienteID",
                table: "BOMs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConstructionID",
                table: "BOMs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "BOMs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PatterN",
                table: "BOMs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BOMDetalles",
                columns: table => new
                {
                    BOMDetalleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(nullable: true),
                    DIE = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Usage = table.Column<decimal>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    Ext = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMDetalles", x => x.BOMDetalleID);
                });

            migrationBuilder.CreateTable(
                name: "Constructions",
                columns: table => new
                {
                    ConstructionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Construction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constructions", x => x.ConstructionID);
                });

            migrationBuilder.CreateTable(
                name: "BOM_BOMDetalles",
                columns: table => new
                {
                    BOM_BOMDetalleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOMID = table.Column<int>(nullable: false),
                    BOMDetalleID = table.Column<int>(nullable: false)
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
                name: "IX_BOMs_ClienteID",
                table: "BOMs",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_BOMs_ConstructionID",
                table: "BOMs",
                column: "ConstructionID");

            migrationBuilder.CreateIndex(
                name: "IX_BOM_BOMDetalles_BOMDetalleID",
                table: "BOM_BOMDetalles",
                column: "BOMDetalleID");

            migrationBuilder.CreateIndex(
                name: "IX_BOM_BOMDetalles_BOMID",
                table: "BOM_BOMDetalles",
                column: "BOMID");

            migrationBuilder.AddForeignKey(
                name: "FK_BOMs_Clientes_ClienteID",
                table: "BOMs",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BOMs_Constructions_ConstructionID",
                table: "BOMs",
                column: "ConstructionID",
                principalTable: "Constructions",
                principalColumn: "ConstructionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOMs_Clientes_ClienteID",
                table: "BOMs");

            migrationBuilder.DropForeignKey(
                name: "FK_BOMs_Constructions_ConstructionID",
                table: "BOMs");

            migrationBuilder.DropTable(
                name: "BOM_BOMDetalles");

            migrationBuilder.DropTable(
                name: "Constructions");

            migrationBuilder.DropTable(
                name: "BOMDetalles");

            migrationBuilder.DropIndex(
                name: "IX_BOMs_ClienteID",
                table: "BOMs");

            migrationBuilder.DropIndex(
                name: "IX_BOMs_ConstructionID",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "ClienteID",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "ConstructionID",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "BOMs");

            migrationBuilder.DropColumn(
                name: "PatterN",
                table: "BOMs");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "BOMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorID",
                table: "BOMs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Construction",
                table: "BOMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "BOMs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "BOMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DIE",
                table: "BOMs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BOMs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BOMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "BOMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Last",
                table: "BOMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartNo",
                table: "BOMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatternName",
                table: "BOMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pattn",
                table: "BOMs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeID",
                table: "BOMs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Stock",
                table: "BOMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "BOMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Usage",
                table: "BOMs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_BOMs_ColorID",
                table: "BOMs",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_BOMs_SizeID",
                table: "BOMs",
                column: "SizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_BOMs_Colores_ColorID",
                table: "BOMs",
                column: "ColorID",
                principalTable: "Colores",
                principalColumn: "ColorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BOMs_Sizes_SizeID",
                table: "BOMs",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "SizeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
