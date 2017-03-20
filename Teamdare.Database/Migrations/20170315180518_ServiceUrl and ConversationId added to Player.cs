using Microsoft.EntityFrameworkCore.Migrations;

namespace Teamdare.Database.Migrations
{
    public partial class ServiceUrlandConversationIdaddedtoPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConversationId",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceUrl",
                table: "Players",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ServiceUrl",
                table: "Players");
        }
    }
}
