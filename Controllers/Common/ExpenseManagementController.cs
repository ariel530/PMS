using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers.Common
{
    public class ExpenseManagementController : Controller
    {
        // GET: ExpenseManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddExpenseInfo()
        {
            return View();
        }
    }
}