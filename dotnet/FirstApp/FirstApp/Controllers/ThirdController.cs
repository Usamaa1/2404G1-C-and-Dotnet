using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class ThirdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
