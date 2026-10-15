
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballTrainingManagement.Migrations
{
    public partial class FixCoachName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Zain"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Zaina"
            );
        }
    }
}
