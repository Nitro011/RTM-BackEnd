using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class addSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Dimensiones_DimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropTable(
                name: "Dimensiones");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Dimensiones_DimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropColumn(
                name: "DimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.AddColumn<int>(
                name: "SizeID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categoriaSizes",
                columns: table => new
                {
                    CategoriaSizeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clasificaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaSizes", x => x.CategoriaSizeID);
                });

            migrationBuilder.CreateTable(
                name: "OperacionesCalzados",
                columns: table => new
                {
                    OperacionesCalzadosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNo = table.Column<string>(nullable: true),
                    CantidadOperaciones = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    CostoOperacional = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacionesCalzados", x => x.OperacionesCalzadosID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USA = table.Column<string>(nullable: true),
                    UK = table.Column<string>(nullable: true),
                    EURO = table.Column<string>(nullable: true),
                    CM = table.Column<string>(nullable: true),
                    CategoriaSizeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeID);
                    table.ForeignKey(
                        name: "FK_Sizes_categoriaSizes_CategoriaSizeID",
                        column: x => x.CategoriaSizeID,
                        principalTable: "categoriaSizes",
                        principalColumn: "CategoriaSizeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BOMs",
                columns: table => new
                {
                    BOMID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    PatternName = table.Column<string>(nullable: true),
                    Stock = table.Column<string>(nullable: true),
                    Pattn = table.Column<int>(nullable: false),
                    Construction = table.Column<string>(nullable: true),
                    ColorID = table.Column<int>(nullable: true),
                    Last = table.Column<string>(nullable: true),
                    SizeID = table.Column<int>(nullable: true),
                    Customer = table.Column<string>(nullable: true),
                    PartNo = table.Column<string>(nullable: true),
                    DIE = table.Column<int>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Usage = table.Column<decimal>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOMs", x => x.BOMID);
                    table.ForeignKey(
                        name: "FK_BOMs_Colores_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Colores",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BOMs_Sizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Sizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Dimensiones_SizeID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_BOMs_ColorID",
                table: "BOMs",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_BOMs_SizeID",
                table: "BOMs",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_CategoriaSizeID",
                table: "Sizes",
                column: "CategoriaSizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Sizes_SizeID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "SizeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Sizes_SizeID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropTable(
                name: "BOMs");

            migrationBuilder.DropTable(
                name: "OperacionesCalzados");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "categoriaSizes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Dimensiones_SizeID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropColumn(
                name: "SizeID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.AddColumn<int>(
                name: "DimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dimensiones",
                columns: table => new
                {
                    DimensionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Altura = table.Column<int>(type: "int", nullable: true),
                    Anchura = table.Column<int>(type: "int", nullable: true),
                    Longitud = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensiones", x => x.DimensionID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Dimensiones_DimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                column: "DimensionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Dimensiones_DimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                column: "DimensionID",
                principalTable: "Dimensiones",
                principalColumn: "DimensionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
