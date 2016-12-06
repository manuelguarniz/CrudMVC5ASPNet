using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using EntitiesLayer;

namespace PresentationLayer.Controllers.Intranet
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public ActionResult MaintaineProducts()
        {
            List<ProductsEL> list = ProductsBL.Instance.ListProducts(0);
            
            return View(list);
        }
        [HttpGet]
        public ActionResult CreateProducts()
        {
            List<CategoriesEL> listCate = CategoriesBL.Instance.ListCategories();
            var listCategory = new SelectList(listCate, "idCategoria", "descripcionCat");
            ViewBag.ListCategory = listCategory;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProducts(ProductsEL p)
        {
            try
            {
                Boolean var = ProductsBL.Instance.AddNewProducts(p);
                if (var)
                {
                    return RedirectToAction("MaintaineProducts");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { mensaje = e.Message });
            }
        }
        [HttpGet]
        public ActionResult EditProducts(Int16 idProducto)
        {
            try
            {
                List<CategoriesEL> listCate = CategoriesBL.Instance.ListCategories();
                var listCategory = new SelectList(listCate, "idCategoria", "descripcionCat");
                ViewBag.ListCategory = listCategory;
                ProductsEL prodEnt = ProductsBL.Instance.CallProductId(idProducto);
                return View(prodEnt);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { mensaje = e.Message });
            }
        }
        [HttpPost]
        public ActionResult EditProducts(ProductsEL p)
        {
            try
            {
                Boolean var = ProductsBL.Instance.EditProduct(p);
                if (var)
                {
                    return RedirectToAction("MaintaineProducts");
                }
                else {
                    return View();
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { mensaje = e.Message });
            }
        }
        public ActionResult ViewProducts(Int16 idProducto)
        {
            ProductsEL prodEnt = ProductsBL.Instance.CallProductId(idProducto);
            return View(prodEnt);
        }
    }
}