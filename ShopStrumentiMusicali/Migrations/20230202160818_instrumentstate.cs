using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopStrumentiMusicali.Migrations
{
    /// <inheritdoc />
    public partial class instrumentstate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Instruments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Instruments");
        }
    }
}
