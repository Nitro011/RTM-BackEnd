using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class UpdateTableEmpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RoleRolID",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RoleRolID",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "RoleRolID",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolID",
                table: "Usuarios",
                column: "RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolID",
                table: "Usuarios",
                column: "RolID",
                principalTable: "Roles",
                principalColumn: "RolID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolID",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolID",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "RoleRolID",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RoleRolID",
                table: "Usuarios",
                column: "RoleRolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RoleRolID",
                table: "Usuarios",
                column: "RoleRolID",
                principalTable: "Roles",
                principalColumn: "RolID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
