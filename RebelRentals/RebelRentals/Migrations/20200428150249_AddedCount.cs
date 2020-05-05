using Microsoft.EntityFrameworkCore.Migrations;

namespace RebelRentals.Migrations
{
    public partial class AddedCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "ShipOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ForeignId",
                table: "Ship",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "ShipOrder");

            migrationBuilder.DropColumn(
                name: "ForeignId",
                table: "Ship");
        }
    }
}
