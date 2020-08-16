using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class ArreglarITEMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ITEM",
                table: "ITEMS");

            migrationBuilder.AddColumn<string>(
                name: "nombreITEMS",
                table: "ITEMS",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nombreITEMS",
                table: "ITEMS");

            migrationBuilder.AddColumn<string>(
                name: "ITEM",
                table: "ITEMS",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
