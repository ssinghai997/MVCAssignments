using MVCWebAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebAssignment.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var product = GetProducts();
            return View(product);
        }
        private IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
               new Product { Id = 101, Name = "AC", Rate = 45000 },
               new Product { Id = 102, Name = "Mobile", Rate = 38000 },
               new Product { Id = 103, Name = "Bike", Rate = 94000 }
            };
        }
        public ActionResult Details(int id)
        {
            var product = GetProducts().SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }
    }
}