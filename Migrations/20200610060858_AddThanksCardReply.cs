using Microsoft.EntityFrameworkCore.Migrations;

namespace ThanksCardAPI.Migrations
{
    public partial class AddThanksCardReply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reply",
                table: "ThanksCards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reply",
                table: "ThanksCards");
        }
    }
}
