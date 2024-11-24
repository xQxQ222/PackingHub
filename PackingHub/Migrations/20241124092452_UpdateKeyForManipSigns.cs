using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PackingHub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKeyForManipSigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Очистка данных: удаление или обнуление несовместимых значений
            migrationBuilder.Sql("UPDATE \"ManipulativeSigns\" SET \"CargoId\" = NULL WHERE \"CargoId\" !~ '^\\d+$';");

            // Изменение типа столбца с использованием SQL
            migrationBuilder.Sql("ALTER TABLE \"ManipulativeSigns\" ALTER COLUMN \"CargoId\" TYPE integer USING \"CargoId\"::integer;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Возврат типа обратно на string
            migrationBuilder.Sql("ALTER TABLE \"ManipulativeSigns\" ALTER COLUMN \"CargoId\" TYPE text USING \"CargoId\"::text;");
        }
    }
}
