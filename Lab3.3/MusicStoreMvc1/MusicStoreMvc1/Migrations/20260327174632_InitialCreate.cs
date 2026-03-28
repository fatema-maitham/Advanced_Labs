using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicStoreMvc1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DebutYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrackCount = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Albums_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Country", "DebutYear", "Name" },
                values: new object[,]
                {
                    { 1, "UK", 1965, "Pink Floyd" },
                    { 2, "USA", 1944, "Miles Davis" },
                    { 3, "France", 1993, "Daft Punk" },
                    { 4, "USA", 2004, "Kendrick Lamar" },
                    { 5, "UK", 1985, "Radiohead" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Jazz" },
                    { 3, "Electronic" },
                    { 4, "Hip-Hop" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "GenreId", "Price", "ReleaseDate", "Title", "TrackCount" },
                values: new object[,]
                {
                    { 1, 1, 1, 14.99m, new DateTime(1973, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Side of the Moon", 10 },
                    { 2, 1, 1, 13.99m, new DateTime(1975, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wish You Were Here", 5 },
                    { 3, 2, 2, 11.99m, new DateTime(1959, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kind of Blue", 5 },
                    { 4, 2, 2, 12.99m, new DateTime(1970, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bitches Brew", 6 },
                    { 5, 3, 3, 16.99m, new DateTime(2013, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Random Access Memories", 13 },
                    { 6, 3, 3, 12.99m, new DateTime(2001, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discovery", 14 },
                    { 7, 4, 4, 14.49m, new DateTime(2017, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "DAMN.", 14 },
                    { 8, 4, 4, 15.99m, new DateTime(2015, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "To Pimp a Butterfly", 16 },
                    { 9, 5, 1, 14.99m, new DateTime(1997, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "OK Computer", 12 },
                    { 10, 5, 3, 13.99m, new DateTime(2000, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kid A", 10 },
                    { 11, 5, 1, 12.99m, new DateTime(2007, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Rainbows", 10 },
                    { 12, 1, 1, 18.99m, new DateTime(1979, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Wall", 26 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_GenreId",
                table: "Albums",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
