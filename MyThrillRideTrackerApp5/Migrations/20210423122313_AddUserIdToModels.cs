using Microsoft.EntityFrameworkCore.Migrations;

namespace MyThrillRideTrackerApp5.Migrations
{
    public partial class AddUserIdToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Visits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "VisitRides",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "VisitRides");
        }
    }
}
