using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Translatoradded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TranslatorId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Translators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translators", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_TranslatorId",
                table: "Books",
                column: "TranslatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Translators_TranslatorId",
                table: "Books",
                column: "TranslatorId",
                principalTable: "Translators",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Translators_TranslatorId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Translators");

            migrationBuilder.DropIndex(
                name: "IX_Books_TranslatorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "TranslatorId",
                table: "Books");
        }
    }
}
