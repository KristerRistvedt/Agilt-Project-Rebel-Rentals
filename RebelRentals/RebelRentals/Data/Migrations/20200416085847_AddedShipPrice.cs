using Microsoft.EntityFrameworkCore.Migrations;

namespace RebelRentals.Data.Migrations
{
    public partial class AddedShipPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Ship",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Ship");
        }
    }
}
