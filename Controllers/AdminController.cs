using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCountry()
        {
            return View();
        }
        public ActionResult DisplayCountry()
        {
            return View();
        }
        public ActionResult UpdateCountry()
        {
            return View();
        }
        public ActionResult AddCustomerType()
        {
            return View();
        }
        public ActionResult DisplayCustomerType()
        {
            return View();
        }
        public ActionResult UpdateCustomerType()
        {
            return View();
        }

        public ActionResult AddProjectStatus()
        {
            return View();

        }
        public ActionResult DisplayProjectStatus()
        {
            return View();
        }

        public ActionResult UpdateProjectStatus()
        {
            return View();
        }

        public ActionResult AddUsers()
        {
            return View();

        }
        public ActionResult UpdateUsers()
        {
            return View();
        }

        public ActionResult DisplayUsers()
        {

            return View();
        }

    }
}