using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using VideoGameStore2.Models;

namespace VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : Controller
    {
        StoreDBContext db = new StoreDBContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("product/{id}")]
        public IActionResult AddProduct(int id, string name, string category, float price, int qtyAvailable)
        {
            Product p = new Product();
            p.productId = id;
            p.productName = name;
            p.productGenre = category;
            p.productCost = price;
            p.productQty = qtyAvailable;
            db.ProductList.Add(p);
            db.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route("product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = db.ProductList.First(p => p.productId == id);
            db.ProductList.Remove(product);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [Route("product/{id}/{name}/{category}/{qty}")]
        public IActionResult UpdateProduct(int id, string name, string category, int qty)
        {
            var product = db.ProductList.First(p => p.productId == id);
            db.ProductList.Remove(product);
            product = new Product();
            product.productId = id;
            product.productName = name;
            product.productGenre = category;
            product.productQty = qty;
            db.ProductList.Add(product);
            db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("product")]
        public IActionResult ViewProducts()
        {
            return View(db.ProductList);
        }
    }
}
