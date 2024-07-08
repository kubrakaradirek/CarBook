using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_Renacarprocessesandcustomertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcess_Cars_CarId",
                table: "RentACarProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcess_Customer_CustomerId",
                table: "RentACarProcess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentACarProcess",
                table: "RentACarProcess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "RentACarProcess",
                newName: "RentACarProcesses");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_RentACarProcess_CustomerId",
                table: "RentACarProcesses",
                newName: "IX_RentACarProcesses_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_RentACarProcess_CarId",
                table: "RentACarProcesses",
                newName: "IX_RentACarProcesses_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentACarProcesses",
                table: "RentACarProcesses",
                column: "RentACarProcessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcesses_Cars_CarId",
                table: "RentACarProcesses",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcesses_Customers_CustomerId",
                table: "RentACarProcesses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcesses_Cars_CarId",
                table: "RentACarProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcesses_Customers_CustomerId",
                table: "RentACarProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentACarProcesses",
                table: "RentACarProcesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "RentACarProcesses",
                newName: "RentACarProcess");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_RentACarProcesses_CustomerId",
                table: "RentACarProcess",
                newName: "IX_RentACarProcess_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_RentACarProcesses_CarId",
                table: "RentACarProcess",
                newName: "IX_RentACarProcess_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentACarProcess",
                table: "RentACarProcess",
                column: "RentACarProcessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcess_Cars_CarId",
                table: "RentACarProcess",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcess_Customer_CustomerId",
                table: "RentACarProcess",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
