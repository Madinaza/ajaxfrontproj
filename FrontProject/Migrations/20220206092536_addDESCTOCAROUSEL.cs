using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontProject.Migrations
{
    public partial class addDESCTOCAROUSEL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Carousels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Carousels");
        }
    }
}
