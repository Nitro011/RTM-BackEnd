using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class BorrasRelacionesDeEstilos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estilos_CategoriasEstilos");

            migrationBuilder.DropTable(
                name: "Estilos_Colores");

            migrationBuilder.DropTable(
                name: "Estilos_Modelos");

            migrationBuilder.DropTable(
                name: "Estilos_TiposEstilos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estilos_CategoriasEstilos",
                columns: table => new
                {
                    Estilo_CategoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaEstiloID = table.Column<int>(type: "int", nullable: true),
                    EstiloID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estilos_CategoriasEstilos", x => x.Estilo_CategoriaID);
                    table.ForeignKey(
                        name: "FK_Estilos_CategoriasEstilos_CategoriasEstilos_CategoriaEstiloID",
                        column: x => x.CategoriaEstiloID,
                        principalTable: "CategoriasEstilos",
                        principalColumn: "CategoriaEstiloID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estilos_CategoriasEstilos_Estilos_EstiloID",
                        column: x => x.EstiloID,
                        principalTable: "Estilos",
                        principalColumn: "EstiloID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estilos_Colores",
                columns: table => new
                {
                    Estilo_ColorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorID = table.Column<int>(type: "int", nullable: false),
                    EstiloID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estilos_Colores", x => x.Estilo_ColorID);
                    table.ForeignKey(
                        name: "FK_Estilos_Colores_Colores_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Colores",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estilos_Colores_Estilos_EstiloID",
                        column: x => x.EstiloID,
                        principalTable: "Estilos",
                        principalColumn: "EstiloID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estilos_Modelos",
                columns: table => new
                {
                    Estilo_ModeloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstiloID = table.Column<int>(type: "int", nullable: true),
                    ModeloID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estilos_Modelos", x => x.Estilo_ModeloID);
                    table.ForeignKey(
                        name: "FK_Estilos_Modelos_Estilos_EstiloID",
                        column: x => x.EstiloID,
                        principalTable: "Estilos",
                        principalColumn: "EstiloID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estilos_Modelos_Modelos_ModeloID",
                        column: x => x.ModeloID,
                        principalTable: "Modelos",
                        principalColumn: "ModeloID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estilos_TiposEstilos",
                columns: table => new
                {
                    Estilo_TiposEstiloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstiloID = table.Column<int>(type: "int", nullable: true),
                    Tipo_CalzadoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estilos_TiposEstilos", x => x.Estilo_TiposEstiloID);
                    table.ForeignKey(
                        name: "FK_Estilos_TiposEstilos_Estilos_EstiloID",
                        column: x => x.EstiloID,
                        principalTable: "Estilos",
                        principalColumn: "EstiloID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estilos_TiposEstilos_Tipo_Calzados_Tipo_CalzadoID",
                        column: x => x.Tipo_CalzadoID,
                        principalTable: "Tipo_Calzados",
                        principalColumn: "Tipo_CalzadoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_CategoriasEstilos_CategoriaEstiloID",
                table: "Estilos_CategoriasEstilos",
                column: "CategoriaEstiloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_CategoriasEstilos_EstiloID",
                table: "Estilos_CategoriasEstilos",
                column: "EstiloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_Colores_ColorID",
                table: "Estilos_Colores",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_Colores_EstiloID",
                table: "Estilos_Colores",
                column: "EstiloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_Modelos_EstiloID",
                table: "Estilos_Modelos",
                column: "EstiloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_Modelos_ModeloID",
                table: "Estilos_Modelos",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_TiposEstilos_EstiloID",
                table: "Estilos_TiposEstilos",
                column: "EstiloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_TiposEstilos_Tipo_CalzadoID",
                table: "Estilos_TiposEstilos",
                column: "Tipo_CalzadoID");
        }
    }
}
