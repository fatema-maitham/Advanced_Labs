using Lab3._1_DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab3._1_DependencyInjection.Controllers
{
    public class LifetimeController: Controller
    {
        private readonly ITransientOperation _transient;
        private readonly IScopedOperation _scoped;
        private readonly ISingletonOperation _singleton;

        public LifetimeController(
            ITransientOperation transient,
            IScopedOperation scoped,
            ISingletonOperation singleton)
        {
            _transient = transient;
            _scoped = scoped;
            _singleton = singleton;
        }

        public IActionResult Index()
        {
            ViewBag.TransientCreatedAt = _transient.CreatedAt;
            ViewBag.ScopedCreatedAt = _scoped.CreatedAt;
            ViewBag.SingletonCreatedAt = _singleton.CreatedAt;
            ViewBag.RequestTime = DateTime.Now.ToString("HH:mm:ss.fff");
            return View();
        }
    }
}
