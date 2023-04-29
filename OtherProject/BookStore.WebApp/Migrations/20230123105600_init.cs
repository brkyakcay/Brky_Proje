using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityCode = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "EMail", "MiddleName", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "nfk@email.com", "Fazıl", "Necip", "Kısakürek" },
                    { 2, "nhr@email.com", "Hikmet", "Nazım", "Ran" },
                    { 3, "op@email.com", "", "Orhan", "Pamuk" },
                    { 4, "sa@email.com", "", "Sabahattin", "Ali" },
                    { 5, "hea@email.com", "Edip", "Halide", "Adıvar" },
                    { 6, "aht@email.com", "Hamdi", "Ahmet", "Tanpınar" },
                    { 7, "ya@email.com", "", "Yusuf", "Atılgan" },
                    { 8, "oa@email.com", "", "Oğuz", "Atay" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CityCode", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADANAAAAAAA" },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ADIYAMAN" },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AFYONKARAHİSAR" },
                    { 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AĞRI" },
                    { 5, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMASYA" },
                    { 6, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANKARA" },
                    { 7, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ANTALYA" },
                    { 8, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARTVİN" },
                    { 9, 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AYDIN" },
                    { 10, 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BALIKESİR" },
                    { 11, 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BİLECİK" },
                    { 12, 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BİNGÖL" },
                    { 13, 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BİTLİS" },
                    { 14, 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BOLU" },
                    { 15, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BURDUR" },
                    { 16, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BURSA" },
                    { 17, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ÇANAKKALE" },
                    { 18, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ÇANKIRI" },
                    { 19, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ÇORUM" },
                    { 20, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DENİZLİ" },
                    { 21, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DİYARBAKIR" },
                    { 22, 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EDİRNE" },
                    { 23, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ELAZIĞ" },
                    { 24, 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ERZİNCAN" },
                    { 25, 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ERZURUM" },
                    { 26, 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ESKİŞEHİR" },
                    { 27, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GAZİANTEP" },
                    { 28, 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GİRESUN" },
                    { 29, 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GÜMÜŞHANE" },
                    { 30, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HAKKARİ" },
                    { 31, 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HATAY" },
                    { 32, 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISPARTA" },
                    { 33, 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MERSİN" },
                    { 34, 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İSTANBUL" },
                    { 35, 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İZMİR" },
                    { 36, 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KARS" },
                    { 37, 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KASTAMONU" },
                    { 38, 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KAYSERİ" },
                    { 39, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KIRKLARELİ" },
                    { 40, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KIRŞEHİR" },
                    { 41, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KOCAELİ" },
                    { 42, 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KONYA" },
                    { 43, 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KÜTAHYA" },
                    { 44, 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MALATYA" },
                    { 45, 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MANİSA" },
                    { 46, 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KAHRAMANMARAŞ" },
                    { 47, 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MARDİN" },
                    { 48, 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MUĞLA" },
                    { 49, 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MUŞ" },
                    { 50, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEVŞEHİR" },
                    { 51, 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NİĞDE" },
                    { 52, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORDU" },
                    { 53, 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RİZE" },
                    { 54, 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAKARYA" },
                    { 55, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAMSUN" },
                    { 56, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SİİRT" },
                    { 57, 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SİNOP" },
                    { 58, 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SİVAS" },
                    { 59, 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TEKİRDAĞ" },
                    { 60, 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TOKAT" },
                    { 61, 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TRABZON" },
                    { 62, 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TUNCELİ" },
                    { 63, 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ŞANLIURFA" },
                    { 64, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UŞAK" },
                    { 65, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VAN" },
                    { 66, 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YOZGAT" },
                    { 67, 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZONGULDAK" },
                    { 68, 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AKSARAY" },
                    { 69, 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BAYBURT" },
                    { 70, 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KARAMAN" },
                    { 71, 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KIRIKKALE" },
                    { 72, 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BATMAN" },
                    { 73, 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ŞIRNAK" },
                    { 74, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BARTIN" },
                    { 75, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARDAHAN" },
                    { 76, 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IĞDIR" },
                    { 77, 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YALOVA" },
                    { 78, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KARABÜK" },
                    { 79, 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KİLİS" },
                    { 80, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OSMANİYE" },
                    { 81, 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DÜZCE" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "", "Türkiye İş Bankası Yayınları" },
                    { 2, "", "Yapıkredi Bankası Yayınları" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PublisherId",
                table: "Addresses",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CampaignId",
                table: "Books",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
