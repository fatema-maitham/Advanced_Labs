using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab2._3.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
