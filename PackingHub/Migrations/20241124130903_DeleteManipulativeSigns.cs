using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PackingHub.Migrations
{
    /// <inheritdoc />
    public partial class DeleteManipulativeSigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER TABLE ""Cargos"" 
          ALTER COLUMN ""Fragility"" TYPE boolean 
          USING CASE 
                   WHEN ""Fragility"" = 'true' THEN TRUE
                   WHEN ""Fragility"" = 'false' THEN FALSE
                   ELSE NULL
               END;");

            migrationBuilder.AddColumn<bool>(
                name: "ChemicallyActive",
                table: "Cargos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Flammable",
                table: "Cargos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.DropTable(
                name: "ManipulativeSigns");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChemicallyActive",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "Flammable",
                table: "Cargos");

            migrationBuilder.AlterColumn<string>(
                name: "Fragility",
                table: "Cargos",
                type: "text",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.CreateTable(
                name: "ManipulativeSigns",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChemicallyActive = table.Column<bool>(type: "boolean", nullable: false),
                    Flammable = table.Column<bool>(type: "boolean", nullable: false),
                    Fragility = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManipulativeSigns", x => x.CargoId);
                });
        }
    }
}
