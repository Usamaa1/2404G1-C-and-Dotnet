using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly _2404g1Context _context;

        public ProductController(_2404g1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ProductList()
        {

            return Ok(_context.Products.ToList());
        }
        [HttpGet("fetch/{prodId}")]
        public IActionResult SingleProductWithId(int prodId)
        {

            return Ok(_context.Products.Find(prodId));
        }

        [HttpGet("{prodName}")]
        public IActionResult ProductFilter(string prodName)
        {
            //return Ok(_context.Products.Where(p=>p.ProdName == prodName));

            return Ok(_context.Products.Where(p=>p.ProdName.Contains(prodName)));
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {

            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Product Added Successfully!");

        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }
            existingProduct.ProdName = product.ProdName;
            existingProduct.ProdPrice = product.ProdPrice;
            existingProduct.ProdDesc = product.ProdDesc;
            _context.SaveChanges();
            return Ok("Product Updated Successfully!");
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Product Deleted Successfully!");
        }
    }
}
