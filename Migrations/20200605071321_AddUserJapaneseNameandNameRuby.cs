using Microsoft.EntityFrameworkCore.Migrations;

namespace ThanksCardAPI.Migrations
{
    public partial class AddUserJapaneseNameandNameRuby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JapaneseName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameRuby",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JapaneseName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NameRuby",
                table: "Users");
        }
    }
}
