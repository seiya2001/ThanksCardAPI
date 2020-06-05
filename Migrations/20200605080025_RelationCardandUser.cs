using Microsoft.EntityFrameworkCore.Migrations;

namespace ThanksCardAPI.Migrations
{
    public partial class RelationCardandUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cards");

            migrationBuilder.AddColumn<long>(
                name: "FromId",
                table: "Cards",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ToId",
                table: "Cards",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_FromId",
                table: "Cards",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ToId",
                table: "Cards",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Users_FromId",
                table: "Cards",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Users_ToId",
                table: "Cards",
                column: "ToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Users_FromId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Users_ToId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_FromId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ToId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ToId",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cards",
                type: "text",
                nullable: true);
        }
    }
}
