using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Correction",
                table: "Papers");

            migrationBuilder.DropColumn(
                name: "Inclusive",
                table: "Papers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Includeds",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Includeds");

            migrationBuilder.AddColumn<int>(
                name: "Correction",
                table: "Papers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Inclusive",
                table: "Papers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
