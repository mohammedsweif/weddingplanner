using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_project.Migrations
{
    public partial class n2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "liked",
                table: "reviews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "liked",
                table: "review_Replays",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "liked",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "liked",
                table: "review_Replays");
        }
    }
}
