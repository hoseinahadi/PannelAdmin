using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainModel.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderHistories_OrderHistoryId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderHistoryId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderHistoryId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderHistories");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderHistoryId",
                table: "Orders",
                column: "OrderHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderHistories_OrderHistoryId",
                table: "Orders",
                column: "OrderHistoryId",
                principalTable: "OrderHistories",
                principalColumn: "OrderHistoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderHistories_OrderHistoryId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderHistoryId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderHistoryId1",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderHistoryId1",
                table: "Orders",
                column: "OrderHistoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderHistories_OrderHistoryId1",
                table: "Orders",
                column: "OrderHistoryId1",
                principalTable: "OrderHistories",
                principalColumn: "OrderHistoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
