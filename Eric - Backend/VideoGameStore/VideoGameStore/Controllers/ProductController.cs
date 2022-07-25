using Microsoft.AspNetCore.Mvc;
using VideoGameStore.Models;

namespace VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        StoreDBContext db = new StoreDBContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("productAdd/{id}/{name}/{category}/{price}/{qtyAvailable}")]
        public IActionResult AddProduct(int id, string name, string category, float price, int qtyAvailable)
        {
            var p = new Product();
            p.productId = id;
            p.productType = name;
            p.productGenre = category;
            p.productCost = price;
            p.productQty = qtyAvailable;
            db.ProductList.Add(p);
            db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("productDelete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = db.ProductList.First(p => p.productId == id);
            db.ProductList.Remove(product);
            db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("productUpdate/{id}/{name}/{category}/{qty}")]
        public IActionResult UpdateProduct(int id, string name, string category, int qty)
        {
            var product = db.ProductList.First(p => p.productId == id);
            db.ProductList.Remove(product);
            product = new Product();
            product.productId = id;
            product.productType = name;
            product.productType = category;
            product.productQty = qty;
            db.ProductList.Add(product);
            db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("products")]
        public IActionResult ViewProducts()
        {
            return View(db.ProductList);
        }
    }
}
