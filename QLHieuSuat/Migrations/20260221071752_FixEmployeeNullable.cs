using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLHieuSuat.Migrations
{
    /// <inheritdoc />
    public partial class FixEmployeeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "TaskItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_EmployeeId",
                table: "TaskItems",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Employees_EmployeeId",
                table: "TaskItems",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Employees_EmployeeId",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_EmployeeId",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "TaskItems");
        }
    }
}
