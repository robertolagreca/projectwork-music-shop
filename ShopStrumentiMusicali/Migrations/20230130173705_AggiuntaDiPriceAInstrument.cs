using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopStrumentiMusicali.Migrations
{
    /// <inheritdoc />
    public partial class AggiuntaDiPriceAInstrument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Instruments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Instruments");
        }
    }
}
