using FlyCart.Entities;
using FlyCart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlyCart.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductServices productServices = new ProductServices();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductList()
        {
            var products = productServices.GetProducts();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            productServices.CreateProduct(product);
            return RedirectToAction("ProductList", "Product");
        }
    }
}