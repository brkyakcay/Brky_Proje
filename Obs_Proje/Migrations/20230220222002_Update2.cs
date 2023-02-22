using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obs_Proje.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ilceler_SehirId",
                table: "Ilceler");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Ilceler",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_Id",
                table: "Ogrenciler",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ilceler_SehirId_Adi",
                table: "Ilceler",
                columns: new[] { "SehirId", "Adi" },
                unique: true,
                filter: "[Adi] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ogrenciler_Id",
                table: "Ogrenciler");

            migrationBuilder.DropIndex(
                name: "IX_Ilceler_SehirId_Adi",
                table: "Ilceler");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Ilceler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ilceler_SehirId",
                table: "Ilceler",
                column: "SehirId");
        }
    }
}
