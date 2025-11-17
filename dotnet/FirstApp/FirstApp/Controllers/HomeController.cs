using System.Diagnostics;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            List<string> names = new List<string>
            {
                "Alice",
                "Bob",
                "Charlie",
                "Diana"
            };


            ViewData["Names"] = names;
            ViewBag.city = "New York";

            TempData["message"] = "Thank you for subscribing";
            TempData.Keep();

            return View();
        }

        public IActionResult Privacy()
        {

            TempData.Keep("message");
            return View();
        }

        public IActionResult About()
        {
            TempData.Keep("message");
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

  


    }
}
