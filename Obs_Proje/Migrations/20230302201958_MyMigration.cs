using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obs_Proje.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OgrenciViewModelId",
                table: "Dersler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OgrenciViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TamAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OkulNo = table.Column<int>(type: "int", nullable: false),
                    BolumId = table.Column<int>(type: "int", nullable: true),
                    AdresId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OgrenciViewModel_Adresler_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adresler",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OgrenciViewModel_Bolumler_BolumId",
                        column: x => x.BolumId,
                        principalTable: "Bolumler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dersler_OgrenciViewModelId",
                table: "Dersler",
                column: "OgrenciViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciViewModel_AdresId",
                table: "OgrenciViewModel",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciViewModel_BolumId",
                table: "OgrenciViewModel",
                column: "BolumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dersler_OgrenciViewModel_OgrenciViewModelId",
                table: "Dersler",
                column: "OgrenciViewModelId",
                principalTable: "OgrenciViewModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dersler_OgrenciViewModel_OgrenciViewModelId",
                table: "Dersler");

            migrationBuilder.DropTable(
                name: "OgrenciViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Dersler_OgrenciViewModelId",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "OgrenciViewModelId",
                table: "Dersler");
        }
    }
}
