using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddTableCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISDCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7682), new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7686) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7704), new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7704) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7711), new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7711) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7718), new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7718) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7724), new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7725) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7734), new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7734) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7740), new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7741) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7747), new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7747) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7753), new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7754) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7761), new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7761) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7767), new DateTime(2022, 2, 11, 18, 10, 49, 62, DateTimeKind.Utc).AddTicks(7767) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9005), new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9006) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9028), new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9028) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9036), new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9036) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9044), new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9044) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9051), new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9051) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9061), new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9061) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9068), new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9068) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9075), new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9076) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9082), new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9083) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9091), new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9091) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9098), new DateTime(2022, 2, 11, 10, 42, 5, 705, DateTimeKind.Utc).AddTicks(9098) });
        }
    }
}
