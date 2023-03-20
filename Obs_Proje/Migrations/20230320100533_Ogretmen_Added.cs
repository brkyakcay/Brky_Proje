using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obs_Proje.Migrations
{
    /// <inheritdoc />
    public partial class Ogretmen_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OgretmenId",
                table: "Dersler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SicilNo = table.Column<int>(type: "int", nullable: false),
                    BolumId = table.Column<int>(type: "int", nullable: true),
                    AdresId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ogretmenler_Adresler_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adresler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ogretmenler_Bolumler_BolumId",
                        column: x => x.BolumId,
                        principalTable: "Bolumler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dersler_OgretmenId",
                table: "Dersler",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmenler_AdresId",
                table: "Ogretmenler",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogretmenler_BolumId",
                table: "Ogretmenler",
                column: "BolumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dersler_Ogretmenler_OgretmenId",
                table: "Dersler",
                column: "OgretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dersler_Ogretmenler_OgretmenId",
                table: "Dersler");

            migrationBuilder.DropTable(
                name: "Ogretmenler");

            migrationBuilder.DropIndex(
                name: "IX_Dersler_OgretmenId",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "OgretmenId",
                table: "Dersler");
        }
    }
}
