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

        public ActionResult ProductList(string searchString)
        {
            var products = productServices.GetProducts();
           products = productServices.searchProduct(searchString);
            return PartialView(products);
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

        [HttpGet]
        public ActionResult Edit(int ProductID)
        {
            var sldProduct = productServices.GetProduct(ProductID);
            return View(sldProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productServices.EditProduct(product);
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public ActionResult Delete(int ProductID)
        {
            var sldProduct = productServices.GetProduct(ProductID);
            return PartialView(sldProduct);
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
            var dltProduct = productServices.GetProduct(product.ProductID);
            productServices.DeleteProduct(dltProduct);
            return RedirectToAction("ProductList", "Product");
        }
    }
}