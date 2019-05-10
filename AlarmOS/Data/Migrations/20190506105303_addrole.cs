using Microsoft.EntityFrameworkCore.Migrations;

namespace AlarmOS.Data.Migrations
{
    public partial class addrole : Migration
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
