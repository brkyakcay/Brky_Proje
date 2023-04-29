using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class CampaignAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Campaigns",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Campaigns");
        }
    }
}
