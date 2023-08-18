using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Password = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cashes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashes", x => x.Id);
                    table.UniqueConstraint("AK_Cashes_Number", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bonus_Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barkod = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Bonus = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonus_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bonus_Cards_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discount_Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barkod = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Fin = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount_Cards", x => x.Id);
                    table.UniqueConstraint("AK_Discount_Cards_Fin", x => x.Fin);
                    table.ForeignKey(
                        name: "FK_Discount_Cards_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Papers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Paper_Number = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Concession = table.Column<float>(type: "real", nullable: true),
                    Discount = table.Column<float>(type: "real", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Final_Amount = table.Column<float>(type: "real", nullable: false),
                    Inclusive = table.Column<int>(type: "int", nullable: false),
                    Correction = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papers", x => x.Id);
                    table.UniqueConstraint("AK_Papers_Paper_Number", x => x.Paper_Number);
                    table.ForeignKey(
                        name: "FK_Papers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cross_Account_Role",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cross_Account_Role", x => new { x.AccountId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Cross_Account_Role_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cross_Account_Role_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bonus_Card_Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bonus_CardId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonus_Card_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bonus_Card_Reports_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bonus_Card_Reports_Bonus_Cards_Bonus_CardId",
                        column: x => x.Bonus_CardId,
                        principalTable: "Bonus_Cards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sub_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount_Check = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sub_Categories_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sub_Categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Company_Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    First_Debt = table.Column<float>(type: "real", nullable: false),
                    Our_Debt = table.Column<float>(type: "real", nullable: false),
                    Us_Debt = table.Column<float>(type: "real", nullable: false),
                    Final_Debt = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Reports_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Company_Reports_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Checks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bonus_CardId = table.Column<int>(type: "int", nullable: false),
                    Discount_CardId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Add_Amount = table.Column<float>(type: "real", nullable: false),
                    Out_Amount = table.Column<float>(type: "real", nullable: false),
                    Bonus_Amount = table.Column<int>(type: "int", nullable: false),
                    Final_Amount = table.Column<float>(type: "real", nullable: false),
                    CashId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checks_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checks_Bonus_Cards_Bonus_CardId",
                        column: x => x.Bonus_CardId,
                        principalTable: "Bonus_Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checks_Cashes_CashId",
                        column: x => x.CashId,
                        principalTable: "Cashes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Checks_Discount_Cards_Discount_CardId",
                        column: x => x.Discount_CardId,
                        principalTable: "Discount_Cards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barkod = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Sub_CategoryId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.UniqueConstraint("AK_Items_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Items_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Sub_Categories_Sub_CategoryId",
                        column: x => x.Sub_CategoryId,
                        principalTable: "Sub_Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Discount_Card_Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount_CardId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Report = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount_Card_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_Card_Reports_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discount_Card_Reports_Discount_Cards_Discount_CardId",
                        column: x => x.Discount_CardId,
                        principalTable: "Discount_Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Discount_Card_Reports_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Includeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Buy_Price = table.Column<float>(type: "real", nullable: false),
                    Sale_Percentage = table.Column<float>(type: "real", nullable: false),
                    Sale_Price = table.Column<float>(type: "real", nullable: false),
                    Concession = table.Column<float>(type: "real", nullable: true),
                    Discount = table.Column<float>(type: "real", nullable: true),
                    Discount_Percentage = table.Column<float>(type: "real", nullable: true),
                    Buy_Amount = table.Column<float>(type: "real", nullable: false),
                    Sale_Amount = table.Column<float>(type: "real", nullable: false),
                    Final = table.Column<float>(type: "real", nullable: false),
                    Print_Number = table.Column<int>(type: "int", nullable: false),
                    PaperId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Includeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Includeds_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Includeds_Papers_PaperId",
                        column: x => x.PaperId,
                        principalTable: "Papers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    CheckId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Checks_CheckId",
                        column: x => x.CheckId,
                        principalTable: "Checks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sales_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_Card_Reports_AccountId",
                table: "Bonus_Card_Reports",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_Card_Reports_Bonus_CardId",
                table: "Bonus_Card_Reports",
                column: "Bonus_CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_Cards_AccountId",
                table: "Bonus_Cards",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_Cards_Barkod",
                table: "Bonus_Cards",
                column: "Barkod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AccountId",
                table: "Categories",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_AccountId",
                table: "Checks",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_Bonus_CardId",
                table: "Checks",
                column: "Bonus_CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checks_CashId",
                table: "Checks",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_Checks_Discount_CardId",
                table: "Checks",
                column: "Discount_CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AccountId",
                table: "Companies",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Reports_AccountId",
                table: "Company_Reports",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Reports_CompanyId",
                table: "Company_Reports",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cross_Account_Role_RoleId",
                table: "Cross_Account_Role",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_Card_Reports_AccountId",
                table: "Discount_Card_Reports",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_Card_Reports_Discount_CardId",
                table: "Discount_Card_Reports",
                column: "Discount_CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_Card_Reports_ItemId",
                table: "Discount_Card_Reports",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discount_Cards_AccountId",
                table: "Discount_Cards",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_Cards_Barkod",
                table: "Discount_Cards",
                column: "Barkod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Includeds_ItemId",
                table: "Includeds",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Includeds_PaperId",
                table: "Includeds",
                column: "PaperId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_AccountId",
                table: "Items",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Barkod",
                table: "Items",
                column: "Barkod",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CompanyId",
                table: "Items",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Sub_CategoryId",
                table: "Items",
                column: "Sub_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Papers_AccountId",
                table: "Papers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CheckId",
                table: "Sales",
                column: "CheckId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ItemId",
                table: "Sales",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Categories_AccountId",
                table: "Sub_Categories",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Categories_CategoryId",
                table: "Sub_Categories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonus_Card_Reports");

            migrationBuilder.DropTable(
                name: "Company_Reports");

            migrationBuilder.DropTable(
                name: "Cross_Account_Role");

            migrationBuilder.DropTable(
                name: "Discount_Card_Reports");

            migrationBuilder.DropTable(
                name: "Includeds");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Papers");

            migrationBuilder.DropTable(
                name: "Checks");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Bonus_Cards");

            migrationBuilder.DropTable(
                name: "Cashes");

            migrationBuilder.DropTable(
                name: "Discount_Cards");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Sub_Categories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
