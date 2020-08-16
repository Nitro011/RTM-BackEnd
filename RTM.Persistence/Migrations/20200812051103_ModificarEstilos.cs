using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class ModificarEstilos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estilos_PesosEstilos");

            migrationBuilder.DropTable(
                name: "PesosEstilos");

            migrationBuilder.AddColumn<string>(
                name: "PesoEstilos",
                table: "Estilos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PesoEstilos",
                table: "Estilos");

            migrationBuilder.CreateTable(
                name: "PesosEstilos",
                columns: table => new
                {
                    PesoEstiloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PesoEstilo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesosEstilos", x => x.PesoEstiloID);
                });

            migrationBuilder.CreateTable(
                name: "Estilos_PesosEstilos",
                columns: table => new
                {
                    Estilo_PesoEstiloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstiloID = table.Column<int>(type: "int", nullable: true),
                    PesoEstiloID = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_PesosEstilos_EstiloID",
                table: "Estilos_PesosEstilos",
                column: "EstiloID");

            migrationBuilder.CreateIndex(
                name: "IX_Estilos_PesosEstilos_PesoEstiloID",
                table: "Estilos_PesosEstilos",
                column: "PesoEstiloID");
        }
    }
}
