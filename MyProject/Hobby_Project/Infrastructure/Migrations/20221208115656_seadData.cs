using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seadData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HobbyCategories",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 8, 13, 56, 55, 781, DateTimeKind.Local).AddTicks(7611), "Sports" },
                    { 2, new DateTime(2022, 12, 8, 13, 56, 55, 781, DateTimeKind.Local).AddTicks(7663), "Cooking" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 8, 13, 56, 55, 781, DateTimeKind.Local).AddTicks(7855), "Ouside sports" },
                    { 2, new DateTime(2022, 12, 8, 13, 56, 55, 781, DateTimeKind.Local).AddTicks(7860), "Vegetarin food" }
                });

            migrationBuilder.InsertData(
                table: "HobbySubCategories",
                columns: new[] { "Id", "CreatedDate", "HobbyCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 8, 13, 56, 55, 781, DateTimeKind.Local).AddTicks(7804), 1, "Volleyball" },
                    { 2, new DateTime(2022, 12, 8, 13, 56, 55, 781, DateTimeKind.Local).AddTicks(7812), 2, "Salads" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HobbySubCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HobbySubCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HobbyCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HobbyCategories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
