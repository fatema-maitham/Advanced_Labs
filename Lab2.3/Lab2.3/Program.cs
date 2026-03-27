using Lab2._3.Dat;
using Lab2._3.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Runtime.CompilerServices;

using var context = new MusicStoreContext();

Console.WriteLine("Affordable Albums (Under $13)...");

var affordable = context.Albums
    .Include(a=>a.Artist)
    .Where(a => a.Price < 13m)
    .ToList();

foreach(var a in affordable)
{
    Console.WriteLine($"{a.Title} by {a.Artist.Name} - {a.Price:C}");
}


Console.WriteLine("\nRock Albums...");
var rockAlbums = context.Albums
    .Include(a => a.Artist)
    .Include(a => a.Genre)
    .Where(a => a.Genre.Name == "Rock")
    .OrderBy(a => a.ReleaseDate)
    .ToList();



foreach (var a in rockAlbums)
{
    Console.WriteLine($"{a.ReleaseDate:d} - {a.Title}" +
        $" ({a.Artist.Name})");
}

Console.WriteLine("\nStore Statistics...");
int totalAlbums = context.Albums.Count();
decimal averagePrice = context.Albums.Average(a => a.Price);
decimal minPrice = context.Albums.Min(a => a.Price);
decimal maxPrice = context.Albums.Max(a => a.Price);


Console.WriteLine($"Total Albums: {totalAlbums}");
Console.WriteLine($"Average Price: {averagePrice:C}");
Console.WriteLine($"Price Range: {minPrice:C} - {maxPrice:C}");


Console.WriteLine("Artist with the most albums...");
var topArtist = context.Artists
    .Select(a => new { a.Id,a.Name, AlbumCount = a.Albums.Count })
    .OrderByDescending(a=>a.AlbumCount)
    .First();

Console.WriteLine($"\nTop Artist: {topArtist.Name} (ID:{topArtist.Id}) has {topArtist.AlbumCount} albums");

/*   Console.Writ eLine($"  {g.Genre}: {g.Count} albums," + 
     $" avg {g.AvgPrice:C}"); */


var genreCount = context.Albums
    .GroupBy(a => a.Genre.Name)
    .Count();
Console.WriteLine($"\n{genreCount} Total Genres");

Console.WriteLine("\nAlbums by Genre:");
var byGenre = context.Albums
    .Include(a => a.Genre)
    .GroupBy(a => a.Genre.Name)
    .Select(g => new
    {
        Genre = g.Key,
        AlbumCountPerGroup = g.Count(),
        AvgPrice= g.Average(a=>a.Price)
    })
    .OrderByDescending(g=>g.AlbumCountPerGroup)
    .ToList();

foreach(var album in byGenre)
{
    Console.WriteLine($"{album.Genre}: {album.AlbumCountPerGroup} Album(s) - Average Price: {album.AvgPrice}");
}


Console.WriteLine("1990s Albums...");

var nineties = context.Albums
    .Include(a => a.Artist)
    .Where(a => a.ReleaseDate.Year >= 1990 && a.ReleaseDate.Year < 2000)
    .OrderByDescending(a => a.ReleaseDate)
    .ToList();

foreach (var a in nineties)
{
    Console.WriteLine($"{a.ReleaseDate.Year} - {a.Title} ({a.Artist.Name})");
}


Console.WriteLine("UK Artists");
var UKArtists = context.Artists
    .Include(ar => ar.Albums)
    .Select(ar => new { ar.Name, AlbumCount=ar.Albums.Count})
    .OrderBy(ar=>ar.Name)
    .ToList();



foreach (var a in UKArtists)
{
    Console.WriteLine($"{a.Name} - {a.AlbumCount} album(s)");
}


/*
 Exercise 2: Complex Queries 
    • Write a query that finds the most expensive album in each genre and displays the genre name, album title, and price. 
    • Write a query that lists all artists who have albums in more than one genre. 
    • Write a query that calculates the total value of all albums in the store (sum of all prices) and the average track count.  
 */

Console.WriteLine("\nWrite a query that finds the most expensive album in each genre and displays the genre name, album title, and price.");
var mostExpensiveByGenre = context.Albums
    .Include(al => al.Genre)
    .GroupBy(al => al.Genre.Name)
    .Select(g => new
    {
        Genre=g.Key,
        Title=g.OrderByDescending(a=>a.Price).First().Title,
        Price = g.Max(a=>a.Price)
    });


foreach (var item in mostExpensiveByGenre)
{
    Console.WriteLine($"{item.Genre}: {item.Title} - {item.Price:C}");
}

Console.WriteLine("\nWrite a query that calculates the total value of all albums in the store (sum of all prices) and the average track count.");
var storeSummary = context.Albums;

var totalValue = storeSummary.Sum(a => a.Price);
var avgTracks = storeSummary.Average(a => a.TrackCount);

Console.WriteLine($"Total value of albums: {totalValue:C}");
Console.WriteLine($"Average track count: {avgTracks:F2}");


Console.WriteLine("\n\n\n\n\n\n");

// Artists with albums in more than one genre

Console.WriteLine("\nArtists with albums in more than one genre:");

var multiGenreArtists = context.Artists
    .Where(ar => ar.Albums.Select(a => a.GenreId).Distinct().Count() > 1)
    .Select(ar => new { ar.Name })
    .ToList();

foreach (var artist in multiGenreArtists)
{
    Console.WriteLine($"{artist.Name} has albums in more than one genre.");
}


Console.WriteLine("\nArtists with albums in more than one genre:");

var multiGenreArtists1 = context.Albums
    .Select(a => new { a.Artist.Name, a.GenreId })
    .ToList() // materialize into memory
    .GroupBy(a => a.Name)
    .Where(g => g.Select(a => a.GenreId).Distinct().Count() > 1)
    .ToList();


foreach (var group in multiGenreArtists1)
{
    var genreCount1 = group.Select(a => a.GenreId).Distinct().Count();
    Console.WriteLine($"{group.Key} has albums in {genreCount1} different genres.");
}

// Artists with albums released before 1990
var artistsBefore1990 = context.Artists
    .Where(ar => ar.Albums.Any(a => a.ReleaseDate.Year < 1990))
    .ToList();

Console.WriteLine("Artists with albums released before 1990:");
foreach (var artist in artistsBefore1990)
{
    Console.WriteLine(artist.Name);
}

// Artists with albums priced above $20
var artistsAbove20 = context.Artists
    .Where(ar => ar.Albums.Any(a => a.Price > 20))
    .ToList();

Console.WriteLine("\nArtists with albums priced above $20:");
foreach (var artist in artistsAbove20)
{
    Console.WriteLine(artist.Name);
}


// Medium
// Artists with more than 5 albums

var artistsWithManyAlbums = context.Artists
    .Select(a => new { a.Name, AlbumCount = a.Albums.Count()})
    .Where(a=>a.AlbumCount>5)
    .ToList();

foreach (var artist in artistsWithManyAlbums)
{
    Console.WriteLine($"{artist.Name} has {artist.AlbumCount} albums.");
}

// Albums released per year in the 2000s
// Albums released per year in the 2000s
var albumsPerYear2000s = context.Albums
    .Where(a => a.ReleaseDate.Year >= 2000 && a.ReleaseDate.Year < 2010)
    .GroupBy(a => a.ReleaseDate.Year)
    .Select(g => new { Year = g.Key, Count = g.Count() })
    .ToList();

Console.WriteLine("Albums released per year in the 2000s:");
foreach (var yearGroup in albumsPerYear2000s)
{
    Console.WriteLine($"{yearGroup.Year}: {yearGroup.Count} albums");
}

// Hard
// Genres with average album price above $15
// Artists whose average album price is higher than the overall store average
// Artist with the highest average album price
// Artists with albums in every genre

// Genres with average album price above $15
var genresAbove15 = context.Albums
    .GroupBy(a => a.Genre.Name)
    .Select(g => new { Genre = g.Key, AvgPrice = g.Average(a => a.Price) })
    .Where(g => g.AvgPrice > 15)
    .ToList();

Console.WriteLine("Genres with average album price above $15:");
foreach (var genre in genresAbove15)
{
    Console.WriteLine($"{genre.Genre} average price: {genre.AvgPrice:C}");
}

// Artists whose average album price is higher than the overall store average
var overallAvg = context.Albums.Average(a => a.Price);

var artistsAboveAvg = context.Artists
    .Select(ar => new { ar.Name, AvgPrice = ar.Albums.Average(a => a.Price) })
    .Where(ar => ar.AvgPrice > overallAvg)
    .ToList();

Console.WriteLine("\nArtists with average album price above store average:");
foreach (var artist in artistsAboveAvg)
{
    Console.WriteLine($"{artist.Name} average price: {artist.AvgPrice:C}");
}


// Artist with the highest average album price
var topArtistPrice = context.Artists
    .Select(ar => new { ar.Name, AvgPrice = ar.Albums.Average(a => a.Price) })
    .OrderByDescending(ar => ar.AvgPrice)
    .FirstOrDefault();

Console.WriteLine("\nArtist with the highest average album price:");
Console.WriteLine($"{topArtistPrice.Name} average price: {topArtistPrice.AvgPrice:C}");


// Artists with albums in every genre
var allGenres = context.Genres.Select(g => g.Id).ToList();

var artistsAllGenres = context.Artists
    .Where(ar => allGenres.All(gid => ar.Albums.Any(a => a.GenreId == gid)))
    .ToList();

Console.WriteLine("\nArtists with albums in every genre:");
foreach (var artist in artistsAllGenres)
{
    Console.WriteLine(artist.Name);
}
