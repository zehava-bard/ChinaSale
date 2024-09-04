using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class aaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Purchasers_BuyerID",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchasers",
                table: "Purchasers");

            migrationBuilder.RenameTable(
                name: "Purchasers",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_User_BuyerID",
                table: "Purchases",
                column: "BuyerID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_User_BuyerID",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Purchasers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchasers",
                table: "Purchasers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Purchasers_BuyerID",
                table: "Purchases",
                column: "BuyerID",
                principalTable: "Purchasers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
