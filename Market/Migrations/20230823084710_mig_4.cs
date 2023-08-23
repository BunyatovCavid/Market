using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "Items",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "CheckNumber",
                table: "Checks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "Bonus_Card_Reports",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CheckVisuals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckNumber = table.Column<int>(type: "int", nullable: false),
                    Bonus_CardId = table.Column<int>(type: "int", nullable: true),
                    Discount_CardId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Add_Amount = table.Column<float>(type: "real", nullable: true),
                    Out_Amount = table.Column<float>(type: "real", nullable: true),
                    Bonus_Amount = table.Column<int>(type: "int", nullable: true),
                    Final_Amount = table.Column<float>(type: "real", nullable: true),
                    CashId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckVisuals", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckVisuals");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CheckNumber",
                table: "Checks");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Bonus_Card_Reports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}
