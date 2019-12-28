using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPersonalAssistant.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkItemStatus",
                columns: table => new
                {
                    WorkItemStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusLabel = table.Column<string>(nullable: true),
                    IsConsideredActive = table.Column<string>(nullable: false),
                    IsDefault = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemStatus", x => x.WorkItemStatusId);
                });

            migrationBuilder.InsertData(
                table: "WorkItemStatus",
                columns: new[] { "WorkItemStatusId", "IsConsideredActive", "IsDefault", "StatusLabel" },
                values: new object[,]
                {
                    { 1, "Y", "Y", "Active" },
                    { 2, "Y", "N", "Awaiting Feedback" },
                    { 3, "N", "Y", "Completed" },
                    { 4, "N", "N", "Cancelled" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkItemStatus");
        }
    }
}
