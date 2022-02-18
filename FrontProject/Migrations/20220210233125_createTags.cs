using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontProject.Migrations
{
    public partial class createTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Flowers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlowerTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowerId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowerTags_Flowers_FlowerId",
                        column: x => x.FlowerId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowerTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_TagId",
                table: "Flowers",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerTags_FlowerId",
                table: "FlowerTags",
                column: "FlowerId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerTags_TagId",
                table: "FlowerTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flowers_Tags_TagId",
                table: "Flowers",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flowers_Tags_TagId",
                table: "Flowers");

            migrationBuilder.DropTable(
                name: "FlowerTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Flowers_TagId",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Flowers");
        }
    }
}
