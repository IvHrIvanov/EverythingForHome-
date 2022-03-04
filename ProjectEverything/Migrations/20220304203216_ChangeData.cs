using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEverything.Migrations
{
    public partial class ChangeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Maggazines_ShopId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ElectricsParts_Maggazines_ShopId",
                table: "ElectricsParts");

            migrationBuilder.DropForeignKey(
                name: "FK_WatersParts_Maggazines_ShopId",
                table: "WatersParts");

            migrationBuilder.DropTable(
                name: "Maggazines");

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Shops_ShopId",
                table: "Accounts",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectricsParts_Shops_ShopId",
                table: "ElectricsParts",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WatersParts_Shops_ShopId",
                table: "WatersParts",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Shops_ShopId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ElectricsParts_Shops_ShopId",
                table: "ElectricsParts");

            migrationBuilder.DropForeignKey(
                name: "FK_WatersParts_Shops_ShopId",
                table: "WatersParts");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.CreateTable(
                name: "Maggazines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(28)", maxLength: 28, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maggazines", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Maggazines_ShopId",
                table: "Accounts",
                column: "ShopId",
                principalTable: "Maggazines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElectricsParts_Maggazines_ShopId",
                table: "ElectricsParts",
                column: "ShopId",
                principalTable: "Maggazines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WatersParts_Maggazines_ShopId",
                table: "WatersParts",
                column: "ShopId",
                principalTable: "Maggazines",
                principalColumn: "Id");
        }
    }
}
