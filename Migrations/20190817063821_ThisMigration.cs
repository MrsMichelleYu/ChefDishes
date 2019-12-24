using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefDishes.Migrations
{
    public partial class ThisMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dishes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Chefs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Chefs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dishes");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Chefs",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Chefs",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
