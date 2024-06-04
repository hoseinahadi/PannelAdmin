using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainModel.Migrations
{
    /// <inheritdoc />
    public partial class v15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderHistories_OrderHistoryId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderHistoryId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderHistoryId",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddDate",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderHistoryId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
