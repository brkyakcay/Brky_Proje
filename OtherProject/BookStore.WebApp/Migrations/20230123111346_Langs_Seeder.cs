using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class LangsSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Langs",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "TR", "Türkçe" },
                    { 2, "EN", "English" },
                    { 3, "DU", "Dutch" },
                    { 4, "FR", "Fransızca" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
