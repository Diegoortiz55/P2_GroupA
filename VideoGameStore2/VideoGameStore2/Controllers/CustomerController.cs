using Microsoft.AspNetCore.Mvc;
using VideoGameStore2.Models;

namespace VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        StoreDBContext db = new StoreDBContext();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var cust = new AuthenticateUser();
            ViewBag.result = cust.CheckUserLogin(username, password).Result;

            if (ViewBag.result == "Login Successfull")
            {
                RedirectToAction("Index", "Products");
            }
            return View();
        }

        [HttpGet]
        [Route("customerAdd/{cust}")]
        public IActionResult AddCustomer(Register cust)
        {
            Register rObj = new Register();
            ViewBag.response = rObj.AddCustomer(cust).Result;
            return View();
        }
        [HttpGet]
        [Route("customerDelete/{username}")]
        public IActionResult DeleteCustomer(string username)
        {
            var cust = db.CustomerList.First(p => p.userName == username);
            db.CustomerList.Remove(cust);
            db.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("customerUpdate/{username}/{password}/{firstName}/{lastName}/{email}/{phone}/{dobMonth}/{dobDay}/{dobYear}/{addressCity}/{addressState}/{addressZip}")]
        public IActionResult UpdateCustomer(string username, string password, string firstName, string lastName, string email, string phone, int dobMonth, int dobDay, int dobYear, string addressCity, string addressState, int addressZip)
        {
            var cust = db.CustomerList.First(p => p.userName == username);
            db.CustomerList.Remove(cust);
            cust = new Register(username);
            cust.userPassword = password;
            cust.firstName = firstName;
            cust.lastName = lastName;
            cust.city = addressCity;
            cust.customerState = addressState;
            cust.AddressZip = addressZip;
            db.CustomerList.Add(cust);
            db.SaveChanges();
            return Ok();
        }
    }
}
