using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HobbyProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addUserIdInRelatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HobbyArticles_UserEntity_UserId1",
                table: "HobbyArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_HobbyComments_UserEntity_UserId1",
                table: "HobbyComments");

            migrationBuilder.DropIndex(
                name: "IX_HobbyComments_UserId1",
                table: "HobbyComments");

            migrationBuilder.DropIndex(
                name: "IX_HobbyArticles_UserId1",
                table: "HobbyArticles");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserEntity");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "HobbyComments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "HobbyArticles");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserEntity",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserEntity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_HobbyComments_UserId",
                table: "HobbyComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HobbyArticles_UserId",
                table: "HobbyArticles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyArticles_UserEntity_UserId",
                table: "HobbyArticles",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyComments_UserEntity_UserId",
                table: "HobbyComments",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HobbyArticles_UserEntity_UserId",
                table: "HobbyArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_HobbyComments_UserEntity_UserId",
                table: "HobbyComments");

            migrationBuilder.DropIndex(
                name: "IX_HobbyComments_UserId",
                table: "HobbyComments");

            migrationBuilder.DropIndex(
                name: "IX_HobbyArticles_UserId",
                table: "HobbyArticles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserEntity");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserEntity",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "UserEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "UserEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "UserEntity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "UserEntity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "UserEntity",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "UserEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "UserEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "UserEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "UserEntity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "UserEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "UserEntity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "HobbyComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "HobbyArticles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_HobbyComments_UserId1",
                table: "HobbyComments",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_HobbyArticles_UserId1",
                table: "HobbyArticles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyArticles_UserEntity_UserId1",
                table: "HobbyArticles",
                column: "UserId1",
                principalTable: "UserEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyComments_UserEntity_UserId1",
                table: "HobbyComments",
                column: "UserId1",
                principalTable: "UserEntity",
                principalColumn: "Id");
        }
    }
}
