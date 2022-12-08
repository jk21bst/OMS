using Microsoft.EntityFrameworkCore.Migrations;

namespace omscase.Migrations
{
    public partial class DatabaseMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "prodid",
                table: "Orderitems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orderitems_prodid",
                table: "Orderitems",
                column: "prodid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderitems_Products_prodid",
                table: "Orderitems",
                column: "prodid",
                principalTable: "Products",
                principalColumn: "productid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderitems_Products_prodid",
                table: "Orderitems");

            migrationBuilder.DropIndex(
                name: "IX_Orderitems_prodid",
                table: "Orderitems");

            migrationBuilder.DropColumn(
                name: "prodid",
                table: "Orderitems");
        }
    }
}
