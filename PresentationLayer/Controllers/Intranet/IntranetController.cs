using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntitiesLayer;
using BusinessLayer;

namespace PresentationLayer.Controllers.Intranet
{
    public class IntranetController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            try
            {
                EmployeesEL u = EmployeesBL.Instance.VerifyUserAccess(
                                            frm["txtUser"].ToString(),
                                            frm["txtPassword"].ToString());

                Session["empleado"] = u;
                return RedirectToAction("PrincipalMain", "Intranet");
            }
            catch (ApplicationException ae)
            {
                return RedirectToAction("Login", "Intranet", new { msjError = ae.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { msjError = e.Message });
            }
        }
        public ActionResult PrincipalMain()
        {
            return View();
        }
    }
}