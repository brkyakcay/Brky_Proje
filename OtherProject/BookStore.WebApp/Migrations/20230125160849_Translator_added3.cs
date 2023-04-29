using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Translatoradded3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TranslatorId",
                table: "Langs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TranslatorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "TranslatorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "TranslatorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 4,
                column: "TranslatorId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Langs_TranslatorId",
                table: "Langs",
                column: "TranslatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Langs_Translators_TranslatorId",
                table: "Langs",
                column: "TranslatorId",
                principalTable: "Translators",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Langs_Translators_TranslatorId",
                table: "Langs");

            migrationBuilder.DropIndex(
                name: "IX_Langs_TranslatorId",
                table: "Langs");

            migrationBuilder.DropColumn(
                name: "TranslatorId",
                table: "Langs");
        }
    }
}
