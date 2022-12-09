using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHobbyPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HobbyPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HobbyArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HobbyPhotos_HobbyArticles_HobbyArticleId",
                        column: x => x.HobbyArticleId,
                        principalTable: "HobbyArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "HobbyCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 12, 27, 0, 761, DateTimeKind.Local).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "HobbyCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 12, 27, 0, 761, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "HobbySubCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 12, 27, 0, 761, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "HobbySubCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 12, 27, 0, 761, DateTimeKind.Local).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 12, 27, 0, 761, DateTimeKind.Local).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 9, 12, 27, 0, 761, DateTimeKind.Local).AddTicks(2087));

            migrationBuilder.CreateIndex(
                name: "IX_HobbyPhotos_HobbyArticleId",
                table: "HobbyPhotos",
                column: "HobbyArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HobbyPhotos");

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
                column: "CreatedDate",
                value: new DateTime(2022, 12, 8, 15, 0, 3, 861, DateTimeKind.Local).AddTicks(8186));

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
                column: "CreatedDate",
                value: new DateTime(2022, 12, 8, 15, 0, 3, 861, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 8, 15, 0, 3, 861, DateTimeKind.Local).AddTicks(8247));
        }
    }
}
