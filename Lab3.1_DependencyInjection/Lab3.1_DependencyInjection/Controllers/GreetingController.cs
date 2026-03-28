using Lab3._1_DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab3._1_DependencyInjection.Controllers
{
    public class GreetingController : Controller
    {
        private readonly IGreetingService _greetingService;

        public GreetingController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        public IActionResult Index()
        {
            ViewBag.Greeting = _greetingService.GetGreeting();
            return View();
        }
    }
}