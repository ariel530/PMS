using PMS.DAL;
using PMS.DynamicBindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers.Customer
{
    [Authorize]
    public class CustomerMessagesController : Controller
    {
        private CustomerUserMessageDAL customerUserMessageDAL;
        public CustomerMessagesController()
        {
            customerUserMessageDAL = new CustomerUserMessageDAL();
        }
        // GET: CustomerMessage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChatBox()
        {
            List<Customer_User_Messages_Lists> messgesData = customerUserMessageDAL.GetCustomer_User_MessagesListForCustomer(Session["customerseller"].ToString(), User.Identity.Name);
            ViewBag.UnReadMessagesCount = messgesData.Sum(data => data.UnReadMessages);
            return View(messgesData);
        }
    }
}