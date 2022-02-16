using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddDataToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName", "CreatedDate", "Enabled", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Shirts", "Shirts", new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9005), true, new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9006) },
                    { 2, "Shoes", "Shoes", new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9028), true, new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9028) },
                    { 3, "Jeans", "Jeans", new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9036), true, new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9036) },
                    { 4, "Saress", "Sarees", new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9044), true, new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9044) },
                    { 5, "Trousers", "Trousers", new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9051), true, new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9051) },
                    { 6, "Electronics", "Electronics", new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9061), true, new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9061) },
                    { 7, "Perfumes", "Perfumes", new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9068), true, new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9068) },
                    { 8, "Softwares", "Softwares", new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9075), true, new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9076) },
                    { 9, "Stationary", "Stationary", new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9082), true, new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9083) },
                    { 10, "Watches", "Watches", new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9091), true, new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9091) },
                    { 11, "Furniture", "Furniture", new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9098), true, new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9098) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);
        }
    }
}
