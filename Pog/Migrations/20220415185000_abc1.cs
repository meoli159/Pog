using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pog.Migrations
{
    public partial class abc1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Student Support" },
                    { 2, "Teaching Resource" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "Business" },
                    { 3, "Graphic" }
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ADMIN",
                column: "ConcurrencyStamp",
                value: "b8c201ea-40bf-4e92-ac00-c827db964ce2");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "QACOORDINATOR",
                column: "ConcurrencyStamp",
                value: "a248f0a4-8e8f-4c37-b150-8a262836eef6");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "QAMANAGER",
                column: "ConcurrencyStamp",
                value: "5ee73e27-2151-4807-a897-bed6338bb0d0");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "STAFF",
                column: "ConcurrencyStamp",
                value: "cad70ce3-9981-433a-b4a1-4f1c23594bcc");

            migrationBuilder.UpdateData(
                table: "TopicDueDates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DueDate", "FinalDate" },
                values: new object[] { new DateTime(2022, 4, 16, 1, 49, 59, 705, DateTimeKind.Local).AddTicks(9411), new DateTime(2022, 4, 16, 1, 49, 59, 705, DateTimeKind.Local).AddTicks(9421) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ADMIN",
                column: "ConcurrencyStamp",
                value: "fea8606d-9449-4e28-8075-7c447356322f");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "QACOORDINATOR",
                column: "ConcurrencyStamp",
                value: "50e9db9c-bc59-4c3f-b594-011f4e84639a");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "QAMANAGER",
                column: "ConcurrencyStamp",
                value: "67e03727-3b08-49df-95e2-960d79078d38");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "STAFF",
                column: "ConcurrencyStamp",
                value: "2b27fcf4-ec36-449e-8969-d74609101d0b");

            migrationBuilder.UpdateData(
                table: "TopicDueDates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DueDate", "FinalDate" },
                values: new object[] { new DateTime(2022, 4, 15, 13, 26, 19, 432, DateTimeKind.Local).AddTicks(5368), new DateTime(2022, 4, 15, 13, 26, 19, 432, DateTimeKind.Local).AddTicks(5378) });
        }
    }
}
