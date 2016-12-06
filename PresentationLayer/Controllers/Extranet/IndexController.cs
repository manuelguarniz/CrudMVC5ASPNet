using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace PresentationLayer.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListProducts()
        {
            try
            {
                return View(ProductsBL.Instance.ListProducts(0));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Error");
            }
        }
    }
}