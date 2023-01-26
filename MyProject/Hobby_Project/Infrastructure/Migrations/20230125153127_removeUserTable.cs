using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HobbyProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HobbyArticles_Users_UserId",
                table: "HobbyArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_HobbyComments_Users_UserId",
                table: "HobbyComments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_HobbyComments_UserId",
                table: "HobbyComments");

            migrationBuilder.DropIndex(
                name: "IX_HobbyArticles_UserId",
                table: "HobbyArticles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HobbyArticles");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "HobbyComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "HobbyComments");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "HobbyArticles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HobbyComments_UserId",
                table: "HobbyComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HobbyArticles_UserId",
                table: "HobbyArticles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyArticles_Users_UserId",
                table: "HobbyArticles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyComments_Users_UserId",
                table: "HobbyComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
