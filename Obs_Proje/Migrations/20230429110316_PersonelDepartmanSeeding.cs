using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obs_Proje.Migrations
{
    /// <inheritdoc />
    public partial class PersonelDepartmanSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departman",
                columns: new[] { "Id", "Adi" },
                values: new object[] { 1, "İdari İşler" });

            migrationBuilder.InsertData(
                table: "Personel",
                columns: new[] { "Id", "Adi", "DepartmanId", "SicilNo", "Soyadi" },
                values: new object[] { 1, "Mustafa", 1, 1, "Nair" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departman",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
