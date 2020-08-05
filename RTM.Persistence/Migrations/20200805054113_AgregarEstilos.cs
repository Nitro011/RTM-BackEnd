using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class AgregarEstilos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasEstilos",
                columns: table => new
                {
                    CategoriaEstiloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaEstilo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasEstilos", x => x.CategoriaEstiloID);
                });

            migrationBuilder.CreateTable(
                name: "Divisiones",
                columns: table => new
                {
                    DivisionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Division = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisiones", x => x.DivisionID);
                });

            migrationBuilder.CreateTable(
                name: "PesosEstilos",
                columns: table => new
                {
                    PesoEstiloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PesoEstilo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesosEstilos", x => x.PesoEstiloID);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesMedidasEstilos",
                columns: table => new
                {
                    UnidadMedidaEstiloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadMedidaEstilo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedidasEstilos", x => x.UnidadMedidaEstiloID);
                });

            migrationBuilder.CreateTable(
                name: "Estilos",
                columns: table => new
                {
                    EstiloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaID = table.Column<int>(nullable: true),
                    Estilo_No = table.Column<int>(nullable: false),
                    DivisionID = table.Column<int>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    CostoSTD = table.Column<decimal>(nullable: false),
                    Ganancia = table.Column<decimal>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    PattenNo = table.Column<string>(nullable: true),
                    EstadoID = table.Column<int>(nullable: true),
                    Last = table.Column<string>(nullable: true),
                    UnidadMedidaEstiloID = table.Column<int>(nullable: true),
                    Comentarios = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estilos", x => x.EstiloID);
                    table.ForeignKey(
                        name: "FK_Estilos_Divisiones_DivisionID",
                        column: x => x.DivisionID,
                        principalTable: "Divisiones",
                        principalColumn: "DivisionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estilos_Estados_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "Estados",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estilos_Marcas_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "Marcas",
                        principalColumn: "MarcaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estilos_UnidadesMedidasEstilos_UnidadMedidaEstiloID",
                        column: x => x.UnidadMedidaEstiloID,
                        principalTable: "UnidadesMedidasEstilos",
                        principalColumn: "UnidadMedidaEstiloID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estilos_CategoriasEstilos",
                columns: table => new
                {
                    Estilo_CategoriaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstiloID = table.Column<int>(nullable: true),
                    CategoriaEstiloID = table.Column<int>(nullable: true)
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
                    Estilo_ColorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstiloID = table.Column<int>(nullable: false),
                    ColorID = table.Column<int>(nullable: false)
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
                name: "Estilos_MateriasPrimas",
                columns: table => new
                {
                    Estilo_MateriaPrimaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstiloID = table.Column<int>(nullable: true),
                    Materia_PrimaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estilos_MateriasPrimas", x => x.Estilo_MateriaPrimaID);
                    table.ForeignKey(
                        name: "FK_Estilos_MateriasPrimas_Estilos_EstiloID",
                        column: x => x.EstiloID,
                        principalTable: "Estilos",
                        principalColumn: "EstiloID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estilos_MateriasPrimas_Materias_Primas_Materia_PrimaID",
                        column: x => x.Materia_PrimaID,
                        principalTable: "Materias_Primas",
                        principalColumn: "Materia_PrimaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estilos_Modelos",
                columns: table => new
                {
                    Estilo_ModeloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstiloID = table.Column<int>(nullable: true),
                    ModeloID = table.Column<int>(nullable: true)
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
                name: "Estilos_PesosEstilos",
                columns: table => new
                {
                    Estilo_PesoEstiloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstiloID = table.Column<int>(nullable: true),
                    PesoEstiloID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estilos_PesosEstilos", x => x.Estilo_PesoEstiloID);
                    table.ForeignKey(
                        name: "FK_Estilos_PesosEstilos_Estilos_EstiloID",
                        column: x => x.EstiloID,
                        principalTable: "Estilos",
                        principalColumn: "EstiloID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estilos_PesosEstilos_PesosEstilos_PesoEstiloID",
                        column: x => x.PesoEstiloID,
                        principalTable: "PesosEstilos",
                        principalColumn: "PesoEstiloID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estilos_TiposEstilos",
                columns: table => new
                {
                    Estilo_TiposEstiloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstiloID = table.Column<int>(nullable: true),
                    Tipo_CalzadoID = table.Column<int>(nullable: true)
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
                name: "IX_Estilos_DivisionID",
                table: "Estilos",
                column: "DivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_EstadoID",
                table: "Estilos",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_MarcaID",
                table: "Estilos",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_UnidadMedidaEstiloID",
                table: "Estilos",
                column: "UnidadMedidaEstiloID");

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
                name: "IX_Estilos_MateriasPrimas_EstiloID",
                table: "Estilos_MateriasPrimas",
                column: "EstiloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_MateriasPrimas_Materia_PrimaID",
                table: "Estilos_MateriasPrimas",
                column: "Materia_PrimaID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_Modelos_EstiloID",
                table: "Estilos_Modelos",
                column: "EstiloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_Modelos_ModeloID",
                table: "Estilos_Modelos",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_PesosEstilos_EstiloID",
                table: "Estilos_PesosEstilos",
                column: "EstiloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_PesosEstilos_PesoEstiloID",
                table: "Estilos_PesosEstilos",
                column: "PesoEstiloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_TiposEstilos_EstiloID",
                table: "Estilos_TiposEstilos",
                column: "EstiloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_TiposEstilos_Tipo_CalzadoID",
                table: "Estilos_TiposEstilos",
                column: "Tipo_CalzadoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estilos_CategoriasEstilos");

            migrationBuilder.DropTable(
                name: "Estilos_Colores");

            migrationBuilder.DropTable(
                name: "Estilos_MateriasPrimas");

            migrationBuilder.DropTable(
                name: "Estilos_Modelos");

            migrationBuilder.DropTable(
                name: "Estilos_PesosEstilos");

            migrationBuilder.DropTable(
                name: "Estilos_TiposEstilos");

            migrationBuilder.DropTable(
                name: "CategoriasEstilos");

            migrationBuilder.DropTable(
                name: "PesosEstilos");

            migrationBuilder.DropTable(
                name: "Estilos");

            migrationBuilder.DropTable(
                name: "Divisiones");

            migrationBuilder.DropTable(
                name: "UnidadesMedidasEstilos");
        }
    }
}
