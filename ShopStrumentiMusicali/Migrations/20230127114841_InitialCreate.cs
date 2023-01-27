using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopStrumentiMusicali.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageURL = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instruments_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: true),
                    TransactionQuantity = table.Column<short>(type: "smallint", nullable: false),
                    TransactionFee = table.Column<int>(type: "int", nullable: false),
                    InstrumentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopTransactions_Instruments_InstrumentID",
                        column: x => x.InstrumentID,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTransactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: true),
                    TransactionQuantity = table.Column<short>(type: "smallint", nullable: false),
                    InstrumentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTransactions_Instruments_InstrumentID",
                        column: x => x.InstrumentID,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_CategoryID",
                table: "Instruments",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopTransactions_InstrumentID",
                table: "ShopTransactions",
                column: "InstrumentID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTransactions_InstrumentID",
                table: "UserTransactions",
                column: "InstrumentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopTransactions");

            migrationBuilder.DropTable(
                name: "UserTransactions");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
