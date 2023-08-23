using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Includeds_Papers_PaperId",
                table: "Includeds");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CheckVisuals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Bonus_Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SaleVisuals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    CheckVisualId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleVisuals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleVisuals_CheckVisuals_CheckVisualId",
                        column: x => x.CheckVisualId,
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
                name: "IX_SaleVisuals_CheckVisualId",
                table: "SaleVisuals",
                column: "CheckVisualId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleVisuals_ItemId",
                table: "SaleVisuals",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Includeds_Papers_PaperId",
                table: "Includeds",
                column: "PaperId",
                principalTable: "Papers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Includeds_Papers_PaperId",
                table: "Includeds");

            migrationBuilder.DropTable(
                name: "SaleVisuals");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "CheckVisuals");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Bonus_Cards");

            migrationBuilder.AddForeignKey(
                name: "FK_Includeds_Papers_PaperId",
                table: "Includeds",
                column: "PaperId",
                principalTable: "Papers",
                principalColumn: "Id");
        }
    }
}
