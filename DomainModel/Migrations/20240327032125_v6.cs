using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainModel.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Conversations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_EmployeeId",
                table: "Conversations",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_Employees_EmployeeId",
                table: "Conversations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_Employees_EmployeeId",
                table: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_Conversations_EmployeeId",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Conversations");
        }
    }
}
