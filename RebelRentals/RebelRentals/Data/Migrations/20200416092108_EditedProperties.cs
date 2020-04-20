using Microsoft.EntityFrameworkCore.Migrations;

namespace RebelRentals.Data.Migrations
{
    public partial class EditedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPassengers",
                table: "Ship");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Ship",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Class",
                table: "Ship",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPopulation",
                table: "Ship",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPopulation",
                table: "Ship");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Ship",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Class",
                table: "Ship",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPassengers",
                table: "Ship",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
