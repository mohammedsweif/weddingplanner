using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_project.Migrations
{
    public partial class Sattttar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatId",
                table: "articles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "articles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_articles_CatId",
                table: "articles",
                column: "CatId");

            migrationBuilder.AddForeignKey(
                name: "FK_articles_catagories_CatId",
                table: "articles",
                column: "CatId",
                principalTable: "catagories",
                principalColumn: "cat_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articles_catagories_CatId",
                table: "articles");

            migrationBuilder.DropIndex(
                name: "IX_articles_CatId",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "CatId",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "articles");
        }
    }
}
