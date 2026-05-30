using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankCashFlowManagement.Migrations
{
    /// <inheritdoc />
    public partial class FixDecimalType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Transactions",
                newName: "TransactionType");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Transactions",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    TransferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromAccountId = table.Column<int>(type: "int", nullable: false),
                    ToAccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.TransferId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "TransactionType",
                table: "Transactions",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Transactions",
                newName: "Note");
        }
    }
}
