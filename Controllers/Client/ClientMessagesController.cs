using Newtonsoft.Json;
using PMS.DAL;
using PMS.DynamicBindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers.Client
{
    [Authorize]
    public class ClientMessagesController : Controller
    {
        private CustomerUserMessageDAL customerUserMessageDAL;
        public ClientMessagesController()
        {
             customerUserMessageDAL = new CustomerUserMessageDAL();
        }
        // GET: ClientMessages
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChatBox()
        {
            List<Customer_User_Messages_Lists> messgesData = customerUserMessageDAL.GetCustomer_User_MessagesList(User.Identity.Name);
            ViewBag.UnReadMessagesCount = messgesData.Sum(data => data.UnReadMessages);
            return View(messgesData);
        }
        //public JsonResult GetAllMessagesByUserName(string userName)
        //{

        //    string[] res = customerUserMessageDAL.CheckUserNameExists(userName.ToUpper());


        //    var uniquenessResult = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
        //    {
        //        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        //    });


        //    return Json(new { uniquenessResult = uniquenessResult, JsonRequestBehavior.AllowGet });
        //}


        public ActionResult ViewMessages()
        {
            return View();
        }
    }
}