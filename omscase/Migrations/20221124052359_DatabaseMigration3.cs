using Microsoft.EntityFrameworkCore.Migrations;

namespace omscase.Migrations
{
    public partial class DatabaseMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "username",
                table: "Customers");
        }
    }
}
