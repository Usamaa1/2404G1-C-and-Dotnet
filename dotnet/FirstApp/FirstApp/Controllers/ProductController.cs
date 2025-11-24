using FirstApp.Data;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductsContext _context;

        public ProductController(ProductsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           var products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if(product != null)
            {
            _context.Products.Add(product);
            _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
