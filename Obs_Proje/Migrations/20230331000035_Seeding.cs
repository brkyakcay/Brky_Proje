using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Obs_Proje.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bolumler",
                columns: new[] { "Id", "Adi" },
                values: new object[] { 1, "Bilgisayar Mühendisliği" });

            migrationBuilder.InsertData(
                table: "Ogrenciler",
                columns: new[] { "Id", "Adi", "AdresId", "BolumId", "OkulNo", "Soyadi" },
                values: new object[] { 1, "Berkay", null, 1, 210219056, "Akçay" });

            migrationBuilder.InsertData(
                table: "Ogretmenler",
                columns: new[] { "Id", "Adi", "AdresId", "BolumId", "SicilNo", "Soyadi" },
                values: new object[] { 1, "Can", null, 1, 1, "Demirel" });

            migrationBuilder.InsertData(
                table: "Dersler",
                columns: new[] { "Id", "Adi", "BolumId", "OgretmenId" },
                values: new object[,]
                {
                    { 1, "Front-End Development", 1, 1 },
                    { 2, "Asp.Net Web Development", 1, 1 },
                    { 3, "Database Management", 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dersler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dersler",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dersler",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ogrenciler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ogretmenler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bolumler",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
