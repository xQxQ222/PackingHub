using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackingHub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Addresses",
                table: "Routes",
                newName: "AddressesNumbers");

            migrationBuilder.AlterColumn<string>(
                name: "CargoNumbers",
                table: "Plans",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressesNumbers",
                table: "Routes",
                newName: "Addresses");

            migrationBuilder.AlterColumn<int>(
                name: "CargoNumbers",
                table: "Plans",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
