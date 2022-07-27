using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using Microsoft.AspNetCore.Mvc;




namespace RetroStoreMVC2.Controllers
{
    //[Authorize]
    public class ProductController : Controller
    {
        // GET: /<controller>/
        public IActionResult ViewProducts()
        {
            return View();
        }
    }
}

