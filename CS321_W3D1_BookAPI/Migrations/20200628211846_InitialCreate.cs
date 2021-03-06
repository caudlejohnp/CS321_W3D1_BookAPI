﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS321_W3D1_BookAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    FoundedYear = table.Column<int>(nullable: false),
                    CountryofOrigin = table.Column<string>(nullable: true),
                    HeadQuartersLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    PublisherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Birthday", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1892, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.R.R.", "Tolkein" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Birthday", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1977, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brent", "Weeks" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "CountryofOrigin", "FoundedYear", "HeadQuartersLocation", "Name" },
                values: new object[] { 1, "USA", 1925, "NY, NY", "Viking Press" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "CountryofOrigin", "FoundedYear", "HeadQuartersLocation", "Name" },
                values: new object[] { 2, "USA", 1897, "NY, NY", "Doubleday" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Category", "PublisherId", "Title" },
                values: new object[] { 1, 1, "Fantasy", 1, "The Hobbit" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Category", "PublisherId", "Title" },
                values: new object[] { 2, 1, "Fantasy", 1, "The Fellowship of the Ring" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Category", "PublisherId", "Title" },
                values: new object[] { 3, 1, "Fantasy", 1, "The Two Towers" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Category", "PublisherId", "Title" },
                values: new object[] { 4, 2, "Fantasy", 2, "The Broken Mirror" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
