using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class newOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Purchases_PurchasesID",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "PurchasesID",
                table: "Card",
                newName: "PurchasesId");

            migrationBuilder.RenameIndex(
                name: "IX_Card_PurchasesID",
                table: "Card",
                newName: "IX_Card_PurchasesId");

            migrationBuilder.AlterColumn<int>(
                name: "PurchasesId",
                table: "Card",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Purchases_PurchasesId",
                table: "Card",
                column: "PurchasesId",
                principalTable: "Purchases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Purchases_PurchasesId",
                table: "Card");

            migrationBuilder.RenameColumn(
                name: "PurchasesId",
                table: "Card",
                newName: "PurchasesID");

            migrationBuilder.RenameIndex(
                name: "IX_Card_PurchasesId",
                table: "Card",
                newName: "IX_Card_PurchasesID");

            migrationBuilder.AlterColumn<int>(
                name: "PurchasesID",
                table: "Card",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Purchases_PurchasesID",
                table: "Card",
                column: "PurchasesID",
                principalTable: "Purchases",
                principalColumn: "ID");
        }
    }
}
