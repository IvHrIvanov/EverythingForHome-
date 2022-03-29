using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEverything.Migrations
{
    public partial class Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AccountId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AccountId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountId1",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId1",
                table: "Orders",
                column: "AccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AccountId",
                table: "Orders",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AccountId1",
                table: "Orders",
                column: "AccountId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AccountId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AccountId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AccountId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AccountId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AccountId",
                table: "Orders",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
