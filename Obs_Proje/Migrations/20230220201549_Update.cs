using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obs_Proje.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdresId",
                table: "Ogrenciler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BolumId",
                table: "Ogrenciler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BolumDers",
                columns: table => new
                {
                    BolumlerId = table.Column<int>(type: "int", nullable: false),
                    DerslerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolumDers", x => new { x.BolumlerId, x.DerslerId });
                    table.ForeignKey(
                        name: "FK_BolumDers_Bolumler_BolumlerId",
                        column: x => x.BolumlerId,
                        principalTable: "Bolumler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BolumDers_Dersler_DerslerId",
                        column: x => x.DerslerId,
                        principalTable: "Dersler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DersOgrenci",
                columns: table => new
                {
                    DerslerId = table.Column<int>(type: "int", nullable: false),
                    OgrencilerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersOgrenci", x => new { x.DerslerId, x.OgrencilerId });
                    table.ForeignKey(
                        name: "FK_DersOgrenci_Dersler_DerslerId",
                        column: x => x.DerslerId,
                        principalTable: "Dersler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersOgrenci_Ogrenciler_OgrencilerId",
                        column: x => x.OgrencilerId,
                        principalTable: "Ogrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_AdresId",
                table: "Ogrenciler",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_BolumId",
                table: "Ogrenciler",
                column: "BolumId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilceler_SehirId",
                table: "Ilceler",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresler_IlceId",
                table: "Adresler",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_BolumDers_DerslerId",
                table: "BolumDers",
                column: "DerslerId");

            migrationBuilder.CreateIndex(
                name: "IX_DersOgrenci_OgrencilerId",
                table: "DersOgrenci",
                column: "OgrencilerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresler_Ilceler_IlceId",
                table: "Adresler",
                column: "IlceId",
                principalTable: "Ilceler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ilceler_Sehirler_SehirId",
                table: "Ilceler",
                column: "SehirId",
                principalTable: "Sehirler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrenciler_Adresler_AdresId",
                table: "Ogrenciler",
                column: "AdresId",
                principalTable: "Adresler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ogrenciler_Bolumler_BolumId",
                table: "Ogrenciler",
                column: "BolumId",
                principalTable: "Bolumler",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresler_Ilceler_IlceId",
                table: "Adresler");

            migrationBuilder.DropForeignKey(
                name: "FK_Ilceler_Sehirler_SehirId",
                table: "Ilceler");

            migrationBuilder.DropForeignKey(
                name: "FK_Ogrenciler_Adresler_AdresId",
                table: "Ogrenciler");

            migrationBuilder.DropForeignKey(
                name: "FK_Ogrenciler_Bolumler_BolumId",
                table: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "BolumDers");

            migrationBuilder.DropTable(
                name: "DersOgrenci");

            migrationBuilder.DropIndex(
                name: "IX_Ogrenciler_AdresId",
                table: "Ogrenciler");

            migrationBuilder.DropIndex(
                name: "IX_Ogrenciler_BolumId",
                table: "Ogrenciler");

            migrationBuilder.DropIndex(
                name: "IX_Ilceler_SehirId",
                table: "Ilceler");

            migrationBuilder.DropIndex(
                name: "IX_Adresler_IlceId",
                table: "Adresler");

            migrationBuilder.DropColumn(
                name: "AdresId",
                table: "Ogrenciler");

            migrationBuilder.DropColumn(
                name: "BolumId",
                table: "Ogrenciler");
        }
    }
}
