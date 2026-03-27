using Lab2._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Lab2._3.Dat
{
    public class MusicStoreContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Album> Albums { get; set; } = null!;
        public DbSet<Playlist> Playlists { get; set; } = null!;
        public DbSet<PlaylistAlbum> PlaylistAlbums { get; set; } = null!;

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;" +
                "Database=MusicStoreDB1;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Genres 
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Rock" },
                new Genre { Id = 2, Name = "Jazz" },
                new Genre { Id = 3, Name = "Electronic" },
                new Genre { Id = 4, Name = "Hip-Hop" }
            );

            // Seed Artists 
            modelBuilder.Entity<Artist>().HasData(
                new Artist
                {
                    Id = 1,
                    Name = "Pink Floyd",
                    Country = "UK",
                    DebutYear = 1965
                },
                new Artist
                {
                    Id = 2,
                    Name = "Miles Davis",
                    Country = "USA",
                    DebutYear = 1944
                },
                new Artist
                {
                    Id = 3,
                    Name = "Daft Punk",
                    Country = "France",
                    DebutYear = 1993
                },
                new Artist
                {
                    Id = 4,
                    Name = "Kendrick Lamar",
                    Country = "USA",
                    DebutYear = 2004
                },
                new Artist
                {
                    Id = 5,
                    Name = "Radiohead",
                    Country = "UK",
                    DebutYear = 1985
                }
            );

            // Seed Albums 
            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    Id = 1,
                    Title = "The Dark Side of the Moon",
                    ArtistId = 1,
                    GenreId = 1,
                    Price = 14.99m,
                    TrackCount = 10,
                    ReleaseDate = new DateTime(1973, 3, 1)
                },
                new Album
                {
                    Id = 2,
                    Title = "Wish You Were Here",
                    ArtistId = 1,
                    GenreId = 1,
                    Price = 13.99m,
                    TrackCount = 5,
                    ReleaseDate = new DateTime(1975, 9, 12)
                },
                new Album
                {
                    Id = 3,
                    Title = "Kind of Blue",
                    ArtistId = 2,
                    GenreId = 2,
                    Price = 11.99m,
                    TrackCount = 5,
                    ReleaseDate = new DateTime(1959, 8, 17)
                },
                new Album
                {
                    Id = 4,
                    Title = "Bitches Brew",
                    ArtistId = 2,
                    GenreId = 2,
                    Price = 12.99m,
                    TrackCount = 6,
                    ReleaseDate = new DateTime(1970, 3, 30)
                },
                new Album
                {
                    Id = 5,
                    Title = "Random Access Memories",
                    ArtistId = 3,
                    GenreId = 3,
                    Price = 16.99m,
                    TrackCount = 13,
                    ReleaseDate = new DateTime(2013, 5, 17)
                },
                new Album
                {
                    Id = 6,
                    Title = "Discovery",
                    ArtistId = 3,
                    GenreId = 3,
                    Price = 12.99m,
                    TrackCount = 14,
                    ReleaseDate = new DateTime(2001, 2, 26)
                },
                new Album
                {
                    Id = 7,
                    Title = "DAMN.",
                    ArtistId = 4,
                    GenreId = 4,
                    Price = 14.49m,
                    TrackCount = 14,
                    ReleaseDate = new DateTime(2017, 4, 14)
                },
                new Album
                {
                    Id = 8,
                    Title = "To Pimp a Butterfly",
                    ArtistId = 4,
                    GenreId = 4,
                    Price = 15.99m,
                    TrackCount = 16,
                    ReleaseDate = new DateTime(2015, 3, 15)
                },
                new Album
                {
                    Id = 9,
                    Title = "OK Computer",
                    ArtistId = 5,
                    GenreId = 1,
                    Price = 14.99m,
                    TrackCount = 12,
                    ReleaseDate = new DateTime(1997, 5, 21)
                },
                new Album
                {
                    Id = 10,
                    Title = "Kid A",
                    ArtistId = 5,
                    GenreId = 3,
                    Price = 13.99m,
                    TrackCount = 10,
                    ReleaseDate = new DateTime(2000, 10, 2)
                },
                new Album
                {
                    Id = 11,
                    Title = "In Rainbows",
                    ArtistId = 5,
                    GenreId = 1,
                    Price = 12.99m,
                    TrackCount = 10,
                    ReleaseDate = new DateTime(2007, 10, 10)
                },
                new Album
                {
                    Id = 12,
                    Title = "The Wall",
                    ArtistId = 1,
                    GenreId = 1,
                    Price = 18.99m,
                    TrackCount = 26,
                    ReleaseDate = new DateTime(1979, 11, 30)
                }
            );

            // Composite key for join table
            modelBuilder.Entity<PlaylistAlbum>()
                .HasKey(pa => new { pa.PlaylistId, pa.AlbumId });

            // Seed Playlists
            modelBuilder.Entity<Playlist>().HasData(
                new Playlist { Id = 1, Name = "My Favourites", CreatedDate = new DateTime(2024, 1, 1) },
                new Playlist { Id = 2, Name = "Chill Vibes", CreatedDate = new DateTime(2024, 2, 1) }
            );

            // Seed PlaylistAlbums (use real AlbumIds from your seed data)
            modelBuilder.Entity<PlaylistAlbum>().HasData(
                new PlaylistAlbum { PlaylistId = 1, AlbumId = 1, DateAdded = new DateTime(2024, 1, 5) },
                new PlaylistAlbum { PlaylistId = 1, AlbumId = 2, DateAdded = new DateTime(2024, 1, 6) },
                new PlaylistAlbum { PlaylistId = 2, AlbumId = 3, DateAdded = new DateTime(2024, 2, 5) },
                new PlaylistAlbum { PlaylistId = 2, AlbumId = 4, DateAdded = new DateTime(2024, 2, 6) }
            );
        }
    }
}
