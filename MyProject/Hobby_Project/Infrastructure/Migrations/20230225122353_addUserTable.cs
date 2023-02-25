using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HobbyProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HobbyArticleTag");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "HobbyComments");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "HobbyArticles");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "HobbyComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "HobbyArticles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HobbyEntityTag",
                columns: table => new
                {
                    HobbyArticlesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyEntityTag", x => new { x.HobbyArticlesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_HobbyEntityTag_HobbyArticles_HobbyArticlesId",
                        column: x => x.HobbyArticlesId,
                        principalTable: "HobbyArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HobbyEntityTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HobbyComments_UserId",
                table: "HobbyComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HobbyArticles_userId",
                table: "HobbyArticles",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_HobbyEntityTag_TagsId",
                table: "HobbyEntityTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyArticles_UserEntity_userId",
                table: "HobbyArticles",
                column: "userId",
                principalTable: "UserEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyComments_UserEntity_UserId",
                table: "HobbyComments",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HobbyArticles_UserEntity_userId",
                table: "HobbyArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_HobbyComments_UserEntity_UserId",
                table: "HobbyComments");

            migrationBuilder.DropTable(
                name: "HobbyEntityTag");

            migrationBuilder.DropTable(
                name: "UserEntity");

            migrationBuilder.DropIndex(
                name: "IX_HobbyComments_UserId",
                table: "HobbyComments");

            migrationBuilder.DropIndex(
                name: "IX_HobbyArticles_userId",
                table: "HobbyArticles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HobbyComments");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "HobbyArticles");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "HobbyComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "HobbyArticles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "HobbyArticleTag",
                columns: table => new
                {
                    HobbyArticlesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyArticleTag", x => new { x.HobbyArticlesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_HobbyArticleTag_HobbyArticles_HobbyArticlesId",
                        column: x => x.HobbyArticlesId,
                        principalTable: "HobbyArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HobbyArticleTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HobbyArticleTag_TagsId",
                table: "HobbyArticleTag",
                column: "TagsId");
        }
    }
}
