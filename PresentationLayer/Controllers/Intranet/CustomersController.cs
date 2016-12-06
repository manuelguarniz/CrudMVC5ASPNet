using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntitiesLayer;
using BusinessLayer;

namespace PresentationLayer.Controllers.Intranet
{
    public class CustomersController : Controller
    {
        /*PRINCIPAL LISTADO CLIENTES ACTIVOS*/
        [HttpGet]
        public ActionResult MaintaineCustomers()
        {
            try
            {
                List<CustomersEL> list = CustomersBL.Instance.ListClientes(0);
                return View(list);
            }
            catch (Exception e)
            {

                return RedirectToAction("Error", "Error", new { mensaje = e.Message });
            }
            
        }
        /*CLIENTES INACTIVOS*/
        [HttpGet]
        public ActionResult CustomersDown()
        {
            try
            {
                List<CustomersEL> list = CustomersBL.Instance.ListClientesDown(0);
                return View(list);
            }
            catch (Exception e)
            {

                return RedirectToAction("Error", "Error", new { mensaje = e.Message });
            }

        }
        [HttpGet]
        public ActionResult ActiveCustomersDown(Int16 idCustomer)
        {
            try
            {
                CustomersEL cliEnt = CustomersBL.Instance.SearchClientesDown(idCustomer);
                return View(cliEnt);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { mensaje = e.Message });
            }
        }
        [HttpPost]
        public ActionResult ActiveCustomersDown(FormCollection frm)
        {
            try
            {
                if (frm["btnActivar"] != null)
                {
                    int id = Convert.ToInt16(frm["lblId"]);
                    Boolean var = CustomersBL.Instance.ActiveCustomer(id);
                    if (var)
                    {
                        return RedirectToAction("CustomersDown");
                    }
                    else
                    {
                        return View();
                    }
                }
                else {
                    return RedirectToAction("CustomersDown");
                }

            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { mensaje = e.Message });
            }
        }
        /*NUEVO CLIENTE*/
        [HttpGet]
        public ActionResult CreateCustomers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomers(CustomersEL c)
        {
            try
            {
                Boolean var = CustomersBL.Instance.AddCustomer(c);
                if (var)
                {
                    return RedirectToAction("MaintaineCustomers");
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
        /*EDITAR CLIENTE*/
        [HttpGet]
        public ActionResult EditCustomers(Int16 idCustomer)
        {
            try
            {
                CustomersEL cliEnt = CustomersBL.Instance.SearchClientes(idCustomer);
                return View(cliEnt);
            }
            catch (Exception e)
            {

                return RedirectToAction("Error", "Error", new { mensaje = e.Message });
            }
            
        }
        [HttpPost]
        public ActionResult EditCustomers(CustomersEL c)
        {
            try
            {
                Boolean var = CustomersBL.Instance.EditCustomer(c);
                if (var)
                {
                    return RedirectToAction("MaintaineCustomers");
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
        /*ELIMINAR CLIENTE*/
        [HttpGet]
        public ActionResult DeleteCustomers(Int16 idCustomer)
        {
            try
            {
                CustomersEL cliEnt = CustomersBL.Instance.SearchClientes(idCustomer);
                return View(cliEnt);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { mensaje = e.Message });
            }
        }
        [HttpPost]
        public ActionResult DeleteCustomers(FormCollection frm)
        {
            try
            {
                if (frm["btnEliminar"] != null)
                {
                    int id = Convert.ToInt16(frm["lblId"]);
                    Boolean var = CustomersBL.Instance.DeleteCustomer(id);
                    if (var)
                    {
                        return RedirectToAction("MaintaineCustomers");
                    }
                    else
                    {
                        return View();
                    }
                }
                else {
                    return RedirectToAction("MaintaineCustomers");
                }

            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { mensaje = e.Message });
            }
        }
        /*DETALLES CLIENTE*/
        public ActionResult ViewCustomers(Int16 idCustomer)
        {
            CustomersEL cliEnt = CustomersBL.Instance.SearchClientes(idCustomer);
            return View(cliEnt);
        }

    }
}