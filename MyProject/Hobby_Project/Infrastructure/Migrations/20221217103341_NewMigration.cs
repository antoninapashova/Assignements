using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HobbyCategories",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 9, 12, 27, 0, 761, DateTimeKind.Local).AddTicks(1858), "Sports" },
                    { 2, new DateTime(2022, 12, 9, 12, 27, 0, 761, DateTimeKind.Local).AddTicks(1919), "Cooking" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 9, 12, 27, 0, 761, DateTimeKind.Local).AddTicks(2083), "Outside sports" },
                    { 2, new DateTime(2022, 12, 9, 12, 27, 0, 761, DateTimeKind.Local).AddTicks(2087), "Vegetariаn food" }
                });

            migrationBuilder.InsertData(
                table: "HobbySubCategories",
                columns: new[] { "Id", "CreatedDate", "HobbyCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 9, 12, 27, 0, 761, DateTimeKind.Local).AddTicks(2048), 1, "Voleyball" },
                    { 2, new DateTime(2022, 12, 9, 12, 27, 0, 761, DateTimeKind.Local).AddTicks(2055), 2, "Salads" }
                });
        }
    }
}
