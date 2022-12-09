using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDeletecascading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HobbyCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 8, 15, 0, 3, 861, DateTimeKind.Local).AddTicks(7985));

            migrationBuilder.UpdateData(
                table: "HobbyCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 8, 15, 0, 3, 861, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "HobbySubCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2022, 12, 8, 15, 0, 3, 861, DateTimeKind.Local).AddTicks(8186), "Voleyball" });

            migrationBuilder.UpdateData(
                table: "HobbySubCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 8, 15, 0, 3, 861, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2022, 12, 8, 15, 0, 3, 861, DateTimeKind.Local).AddTicks(8242), "Outside sports" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2022, 12, 8, 15, 0, 3, 861, DateTimeKind.Local).AddTicks(8247), "Vegetariаn food" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HobbyCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 8, 13, 56, 55, 781, DateTimeKind.Local).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "HobbyCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 8, 13, 56, 55, 781, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "HobbySubCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2022, 12, 8, 13, 56, 55, 781, DateTimeKind.Local).AddTicks(7804), "Volleyball" });

            migrationBuilder.UpdateData(
                table: "HobbySubCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 8, 13, 56, 55, 781, DateTimeKind.Local).AddTicks(7812));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2022, 12, 8, 13, 56, 55, 781, DateTimeKind.Local).AddTicks(7855), "Ouside sports" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2022, 12, 8, 13, 56, 55, 781, DateTimeKind.Local).AddTicks(7860), "Vegetarin food" });
        }
    }
}
