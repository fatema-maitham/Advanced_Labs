using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MusicStoreMvc1.Data;
using Microsoft.EntityFrameworkCore;
namespace MusicStoreMvc1.Controllers
{
    public class CatalogController : Controller
    {
        private readonly MusicStoreContext _context;

        public CatalogController(MusicStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Browse(string genreName,
            string? artistName)
        {
            var query = _context.Albums
                .Include(a => a.Genre)
                .Include(a => a.Artist)
                .Where(a => a.Genre.Name == genreName);

            if (!string.IsNullOrEmpty(artistName))
            {
                query = query.Where(a =>
                    a.Artist.Name == artistName);
            }

            var albums = await query.ToListAsync();

            ViewBag.GenreName = genreName;
            ViewBag.ArtistName = artistName;
            return View(albums);
        }
    }
}