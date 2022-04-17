using FlyCart.Database;
using FlyCart.Services;
using FlyCart.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlyCart.Web.Controllers
{
    public class HomeController : Controller
    {
        ProductServices productServices = new ProductServices();
        FlyCartContext context = new FlyCartContext();
        public ActionResult Index()
        {
            var pList = productServices.GetProducts();
            return View(pList);
        }

        public ActionResult ProductDetails(int ProductID)
        {
            var product = productServices.GetProduct(ProductID);
            var pOption = context.ProductOptions.Find(ProductID);

            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = product;
            productViewModel.ProductOptions = pOption;
            
            return View(productViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}