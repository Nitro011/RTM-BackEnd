using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class AgregarOrdenesClientesEstilosYOrdenesClientesSizes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdenesClientes_Estilos",
                columns: table => new
                {
                    OrdenesCliente_EstiloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orden_ClienteID = table.Column<int>(nullable: false),
                    EstiloID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesClientes_Estilos", x => x.OrdenesCliente_EstiloID);
                    table.ForeignKey(
                        name: "FK_OrdenesClientes_Estilos_Estilos_EstiloID",
                        column: x => x.EstiloID,
                        principalTable: "Estilos",
                        principalColumn: "EstiloID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenesClientes_Estilos_Ordenes_Clientes_Orden_ClienteID",
                        column: x => x.Orden_ClienteID,
                        principalTable: "Ordenes_Clientes",
                        principalColumn: "Orden_ClienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesClientes_Sizes",
                columns: table => new
                {
                    OrdenesCliente_SizeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orden_ClienteID = table.Column<int>(nullable: false),
                    SizeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesClientes_Sizes", x => x.OrdenesCliente_SizeID);
                    table.ForeignKey(
                        name: "FK_OrdenesClientes_Sizes_Ordenes_Clientes_Orden_ClienteID",
                        column: x => x.Orden_ClienteID,
                        principalTable: "Ordenes_Clientes",
                        principalColumn: "Orden_ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenesClientes_Sizes_Sizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Sizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesClientes_Estilos_EstiloID",
                table: "OrdenesClientes_Estilos",
                column: "EstiloID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesClientes_Estilos_Orden_ClienteID",
                table: "OrdenesClientes_Estilos",
                column: "Orden_ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesClientes_Sizes_Orden_ClienteID",
                table: "OrdenesClientes_Sizes",
                column: "Orden_ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesClientes_Sizes_SizeID",
                table: "OrdenesClientes_Sizes",
                column: "SizeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesClientes_Estilos");

            migrationBuilder.DropTable(
                name: "OrdenesClientes_Sizes");
        }
    }
}
