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
                String getUser = frm["txtUser"].ToString();
                String getPassword = frm["txtPassword"].ToString();

                if (String.IsNullOrEmpty(getUser) && String.IsNullOrEmpty(getPassword))
                {
                    EmployeesEL u = EmployeesBL.Instance.VerifyUserAccess(getUser, getPassword);

                    Session["empleado"] = u;
                    return RedirectToAction("PrincipalMain", "Intranet");
                }
                else
                {
                    return RedirectToAction("Login", "Intranet", new { msjError = "User and Password incorrect" });
                }
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