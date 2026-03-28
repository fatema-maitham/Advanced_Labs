using Microsoft.AspNetCore.Mvc;


namespace MusicStoreMvc1.Controllers
{
    public class DemoController : Controller
    {
        // Returns a Razor view 
        public IActionResult Index()
        {
            return View();
        }

        // Returns a plain text string 
        public IActionResult PlainText()
        {
            return Content("This is a plain text response.",
                "text/plain");
        }

        // Returns a JSON object 
        public IActionResult JsonData()
        {
            return Json(new
            {
                Message = "This is JSON",
                Timestamp = DateTime.Now,
                Items = new[] { "Alpha", "Beta", "Gamma" }
            });
        }

        // Redirects to another action 
        public IActionResult GoHome()
        {
            return RedirectToAction("Index", "Home");
        }

        // Returns 404 Not Found 
        public IActionResult Missing()
        {
            return NotFound();
        }
    }
}