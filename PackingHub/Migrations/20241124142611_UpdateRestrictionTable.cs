using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackingHub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRestrictionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo1",
                table: "CargoRestrictions");

            migrationBuilder.DropColumn(
                name: "Cargo2",
                table: "CargoRestrictions");

            migrationBuilder.AddColumn<int>(
                name: "Cargo1Id",
                table: "CargoRestrictions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cargo2Id",
                table: "CargoRestrictions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo1Id",
                table: "CargoRestrictions");

            migrationBuilder.DropColumn(
                name: "Cargo2Id",
                table: "CargoRestrictions");

            migrationBuilder.AddColumn<string>(
                name: "Cargo1",
                table: "CargoRestrictions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cargo2",
                table: "CargoRestrictions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
