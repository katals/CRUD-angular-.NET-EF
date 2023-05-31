using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class petsinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pet",
                columns: new[] { "Id", "Age", "Color", "Name", "Race", "Weight" },
                values: new object[] { 1, 2, "gris", "Michaelo", "Pinscher", 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
