using euseControler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace euseControler.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
       
            // GET: Home
            public ActionResult Index()
            {

                UserData u = new UserData();
                u.Username = "Customer";
                u.Products = new List<string> { "Product #1", "Product #2", "Product #3", "Product #4" };


                return View(u);
            }
            public ActionResult Index2()
            {
                return View();
            }
            public ActionResult Product()
            {
                var product = Request.QueryString["p"];

                UserData u = new UserData();
                u.Username = "Customer";
                u.SingleProduct = product;

                return View(u);
            }


            //http://localhost:31843/Home/Product?p=JORA
            [HttpPost]
            public ActionResult Product(string btn)
            {
                return RedirectToAction("Product", "Home", new { @p = btn });
            }
        
    }
}