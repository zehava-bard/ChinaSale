using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class zehavi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresentsID = table.Column<int>(type: "int", nullable: false),
                    PurchasesID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Presents_PresentsID",
                        column: x => x.PresentsID,
                        principalTable: "Presents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Card_Purchases_PurchasesID",
                        column: x => x.PurchasesID,
                        principalTable: "Purchases",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_PresentsID",
                table: "Card",
                column: "PresentsID");

            migrationBuilder.CreateIndex(
                name: "IX_Card_PurchasesID",
                table: "Card",
                column: "PurchasesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");
        }
    }
}
