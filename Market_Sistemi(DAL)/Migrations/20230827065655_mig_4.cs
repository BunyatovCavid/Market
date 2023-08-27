using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market_Sistemi_DAL_.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleVisuals");

            migrationBuilder.DropTable(
                name: "CheckVisuals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckVisuals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Add_Amount = table.Column<float>(type: "real", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Bonus_Amount = table.Column<int>(type: "int", nullable: true),
                    Bonus_CardId = table.Column<int>(type: "int", nullable: true),
                    CashId = table.Column<int>(type: "int", nullable: false),
                    CheckNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount_CardId = table.Column<int>(type: "int", nullable: true),
                    Final_Amount = table.Column<float>(type: "real", nullable: true),
                    Out_Amount = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckVisuals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleVisuals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleVisuals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleVisuals_CheckVisuals_CheckId",
                        column: x => x.CheckId,
                        principalTable: "CheckVisuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleVisuals_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleVisuals_CheckId",
                table: "SaleVisuals",
                column: "CheckId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleVisuals_ItemId",
                table: "SaleVisuals",
                column: "ItemId",
                unique: true);
        }
    }
}
