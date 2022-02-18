using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontProject.Migrations
{
    public partial class createCaruousel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Possitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carousels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    PossitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carousels_Possitions_PossitionId",
                        column: x => x.PossitionId,
                        principalTable: "Possitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carousels_PossitionId",
                table: "Carousels",
                column: "PossitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carousels");

            migrationBuilder.DropTable(
                name: "Possitions");
        }
    }
}
