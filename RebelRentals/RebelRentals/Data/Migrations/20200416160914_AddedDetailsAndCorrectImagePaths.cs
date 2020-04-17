using Microsoft.EntityFrameworkCore.Migrations;

namespace RebelRentals.Data.Migrations
{
    public partial class AddedDetailsAndCorrectImagePaths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Ship",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Ship");
        }
    }
}
