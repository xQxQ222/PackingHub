using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackingHub.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRouteAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE \"Routes\" " +
                "ALTER COLUMN \"AddressesNumbers\" TYPE integer[] " +
                "USING string_to_array(\"AddressesNumbers\", ',')::integer[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "ALTER TABLE \"Routes\" " +
                "ALTER COLUMN \"AddressesNumbers\" TYPE text " +
                "USING array_to_string(\"AddressesNumbers\", ',')");
        }
    }
}
