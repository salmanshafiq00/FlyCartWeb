using FlyCart.Entities;
using FlyCart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlyCart.Web.Controllers
{
    public class CatagoryController : Controller
    {
        CatagoryServices catagoryServices = new CatagoryServices();
        [HttpGet]
        public ActionResult Index()
        {
            var catagoriesList = catagoryServices.GetCatagories();
            return View(catagoriesList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Catagory catagory)
        {
            if (ModelState.IsValid)
            {
            catagoryServices.CreateCatagory(catagory);
             return RedirectToAction("Index", "Catagory");
            }
            else
            {
                ViewBag.err = ModelState.Values.SelectMany(s => s.Errors);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int CatagoryID)
        {
            var sldCatagory = catagoryServices.GetCatagory(CatagoryID);
            return View(sldCatagory);
        }

        [HttpPost]
        public ActionResult Edit(Catagory catagory)
        {
            catagoryServices.EditCatagory(catagory);
            return RedirectToAction("Index", "Catagory");
        }

        [HttpGet]
        public ActionResult Delete(int CatagoryID)
        {
            var sldCatagory = catagoryServices.GetCatagory(CatagoryID);
            return View(sldCatagory);
        }

        [HttpPost]
        public ActionResult Delete(Catagory catagory)
        {
            var dltCatagory = catagoryServices.GetCatagory(catagory.CatagoryID);
            catagoryServices.DeleteCatagory(dltCatagory);
            return RedirectToAction("Index", "Catagory");
        }
    }
}