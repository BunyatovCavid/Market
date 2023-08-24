using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Migrations
{
    public partial class mig_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleVisuals_CheckVisuals_CheckVisualId",
                table: "SaleVisuals");

            migrationBuilder.RenameColumn(
                name: "CheckVisualId",
                table: "SaleVisuals",
                newName: "CheckId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleVisuals_CheckVisualId",
                table: "SaleVisuals",
                newName: "IX_SaleVisuals_CheckId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleVisuals_CheckVisuals_CheckId",
                table: "SaleVisuals",
                column: "CheckId",
                principalTable: "CheckVisuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleVisuals_CheckVisuals_CheckId",
                table: "SaleVisuals");

            migrationBuilder.RenameColumn(
                name: "CheckId",
                table: "SaleVisuals",
                newName: "CheckVisualId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleVisuals_CheckId",
                table: "SaleVisuals",
                newName: "IX_SaleVisuals_CheckVisualId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleVisuals_CheckVisuals_CheckVisualId",
                table: "SaleVisuals",
                column: "CheckVisualId",
                principalTable: "CheckVisuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
