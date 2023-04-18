using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obs_Proje.Migrations
{
    /// <inheritdoc />
    public partial class OgrenciSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ogrenciler",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Ogrenciler",
                columns: new[] { "Id", "Adi", "AdresId", "BolumId", "OkulNo", "Soyadi" },
                values: new object[] { 3, "Yusuf", null, 1, 210219034, "Ekinci" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ogrenciler",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Ogrenciler",
                columns: new[] { "Id", "Adi", "AdresId", "BolumId", "OkulNo", "Soyadi" },
                values: new object[] { 2, "Yusuf", null, 1, 210219034, "Ekinci" });
        }
    }
}
