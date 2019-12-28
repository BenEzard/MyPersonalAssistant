using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPersonalAssistant.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "WorkItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "WorkItemId",
                keyValue: 2);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "WorkItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDateTime",
                table: "WorkItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDateTime",
                table: "WorkItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "WorkItemId", "CreationDateTime", "DeletionDateTime", "Description", "ModificationDateTime", "Title" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nothing much here", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Sample WorkItem" });

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "WorkItemId", "CreationDateTime", "DeletionDateTime", "Description", "ModificationDateTime", "Title" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blah, blah blah", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second WorkItem" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "WorkItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkItems",
                keyColumn: "WorkItemId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "WorkItems");

            migrationBuilder.DropColumn(
                name: "DeletionDateTime",
                table: "WorkItems");

            migrationBuilder.DropColumn(
                name: "ModificationDateTime",
                table: "WorkItems");

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "WorkItemId", "Description", "Title" },
                values: new object[] { 1, "Nothing much here", "A Sample WorkItem" });

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "WorkItemId", "Description", "Title" },
                values: new object[] { 2, "Blah, blah blah", "Second WorkItem" });
        }
    }
}
