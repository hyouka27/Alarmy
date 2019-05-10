using Microsoft.EntityFrameworkCore.Migrations;

namespace AlarmOS.Migrations
{
    public partial class databasescal3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UseId",
                table: "Alarmy",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseId",
                table: "Alarmy");
        }
    }
}
