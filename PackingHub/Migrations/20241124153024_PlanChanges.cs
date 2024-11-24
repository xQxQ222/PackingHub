using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackingHub.Migrations
{
    /// <inheritdoc />
    public partial class PlanChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Преобразование столбца ContainerNumber
            migrationBuilder.Sql(
                @"ALTER TABLE ""Plans"" 
                  ALTER COLUMN ""ContainerNumber"" 
                  TYPE integer 
                  USING ""ContainerNumber""::integer;"
            );

            // Преобразование столбца CargoNumbers
            migrationBuilder.Sql(
                @"ALTER TABLE ""Plans"" 
                  ALTER COLUMN ""CargoNumbers"" 
                  TYPE integer[] 
                  USING string_to_array(""CargoNumbers"", ',')::integer[];"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Откат преобразования столбца ContainerNumber
            migrationBuilder.Sql(
                @"ALTER TABLE ""Plans"" 
                  ALTER COLUMN ""ContainerNumber"" 
                  TYPE text 
                  USING ""ContainerNumber""::text;"
            );

            // Откат преобразования столбца CargoNumbers
            migrationBuilder.Sql(
                @"ALTER TABLE ""Plans"" 
                  ALTER COLUMN ""CargoNumbers"" 
                  TYPE text 
                  USING array_to_string(""CargoNumbers"", ',');"
            );
        }
    }
}
