using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers.Errors
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Error_404()
        {

            if (Session["LoginType"] != null)
            {
                if (Session["LoginType"].ToString() == "user")
                {
                    return RedirectToAction("Error_404_ForUser");
                }
            }
                return View();
            
        }
        public ActionResult Error_404_ForUser()
        {
            return View();
        }
        public ActionResult Error_505_ForUser()
        {
            return View();
        }

    }
}