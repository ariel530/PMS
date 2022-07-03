using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers.Common
{
    public class ExpenseTypeController : Controller
    {
        // GET: ExpenseType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddExpenseType()
        {
            return View();
        }

    }
}