using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopStrumentiMusicali.Migrations
{
    /// <inheritdoc />
    public partial class QuantityAndLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Instruments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserLikes",
                table: "Instruments",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "UserLikes",
                table: "Instruments");
        }
    }
}
