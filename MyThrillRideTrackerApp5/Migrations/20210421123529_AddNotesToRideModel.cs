using Microsoft.EntityFrameworkCore.Migrations;

namespace MyThrillRideTrackerApp5.Migrations
{
    public partial class AddNotesToRideModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Rides",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Rides");
        }
    }
}
