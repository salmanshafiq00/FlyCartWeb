using FlyCart.Database;
using FlyCart.Entities;
using FlyCart.Services;
using FlyCart.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlyCart.Web.Controllers
{
    public class ProductController : Controller
    {
        FlyCartContext db = new FlyCartContext();
        ProductServices productServices = new ProductServices();
        public ActionResult Index()
        {
            ViewBag.Catagory = new SelectList(db.Catagories, "ID", "Name"); 
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
        public ActionResult Create(Product product, HttpPostedFileBase Images)
        {
            var fileName = Images.FileName;
            var localPath = Server.MapPath("~/Images/") + fileName;
            var serverPath = "~/Images/" +fileName;
            Images.SaveAs(localPath);
            product.Images = serverPath;

            productServices.CreateProduct(product);
            return RedirectToAction("ProductList", "Product");
        }

        [HttpGet]
        public ActionResult Edit(int ProductID)
        {
            var sldProduct = productServices.GetProduct(ProductID);
            ViewBag.Catagory = db.Catagories.ToList();
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