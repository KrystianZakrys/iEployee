using Microsoft.EntityFrameworkCore.Migrations;

namespace iEmployee.CommandQuery.Migrations
{
    public partial class FixJobHistoryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories",
                columns: new[] { "Id", "EmployeeId", "PositionId" });

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_EmployeeId",
                table: "JobHistories",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories");

            migrationBuilder.DropIndex(
                name: "IX_JobHistories_EmployeeId",
                table: "JobHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobHistories",
                table: "JobHistories",
                columns: new[] { "EmployeeId", "PositionId" });
        }
    }
}
