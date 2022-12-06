using Microsoft.EntityFrameworkCore.Migrations;

namespace omscase.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_customerid",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.AlterColumn<double>(
                name: "mobileno",
                table: "Customer",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "custid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customer_customerid",
                table: "Orders",
                column: "customerid",
                principalTable: "Customer",
                principalColumn: "custid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customer_customerid",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "mobileno",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "custid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_customerid",
                table: "Orders",
                column: "customerid",
                principalTable: "Customers",
                principalColumn: "custid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
