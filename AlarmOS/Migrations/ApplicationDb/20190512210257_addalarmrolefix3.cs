using Microsoft.EntityFrameworkCore.Migrations;

namespace AlarmOS.Migrations.ApplicationDb
{
    public partial class addalarmrolefix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YourEmailSender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "YourSmsSender",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YourEmailSender",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YourSmsSender",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
