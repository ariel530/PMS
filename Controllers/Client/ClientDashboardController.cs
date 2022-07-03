using PMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.DynamicBindingModels;
using PMS.Models;
using Newtonsoft.Json;

namespace PMS.Controllers.Client
{
    [Authorize]
    public class ClientDashboardController : Controller
    {
        ProjectInfoDAL projectInfoDAL;
        CustomerInfoDAL customerInfoDAL;
        NotificationsDAL notificationsDAL;
        StaffInfoDAL staffInfoDAL;
        public ClientDashboardController()
        {
            projectInfoDAL = new ProjectInfoDAL();
            customerInfoDAL = new CustomerInfoDAL();
            notificationsDAL = new NotificationsDAL();
            staffInfoDAL = new StaffInfoDAL();
        }
        // GET: ClientDashboard
        public ActionResult Index()
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());

            ViewBag.TotalCustomer = customerInfoDAL.TotalCustomersCount(User.Identity.Name);
            ViewBag.TotalProject = projectInfoDAL.TotalProjectsCount(User.Identity.Name);
            ViewBag.TotalCancelProject = projectInfoDAL.TotalCancelProjectsCount(User.Identity.Name);
            ViewBag.TotalStaff = staffInfoDAL.TotalStaffCount(companyId);
            Client_Dashboard_Model client_Dashboard_Model = new Client_Dashboard_Model();
            client_Dashboard_Model.project_Info_Status_Priority_ForDashboards = projectInfoDAL.GetAllRuningProjects(User.Identity.Name);
      
            return View(client_Dashboard_Model);
        }


        public JsonResult GetCustomersForMapCount()
        {
            List<MessagesNotification> messagesNotice = notificationsDAL.GetMessagesNotification(User.Identity.Name);

            //string[] res = countryDAL.InsertCountryData(countryCode.ToUpper(), countryName, Customer.Identity.Name);


            //var CustomerProjectsOnMap = JsonConvert.SerializeObject(customersProjectsMapCounts, Formatting.None, new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //});


            var messagesNotifications = JsonConvert.SerializeObject(messagesNotice, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });

            var numberOfUnreadMessages = JsonConvert.SerializeObject(notificationsDAL.GetUnReadMessagesCount(User.Identity.Name), Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { messagesNotifications = messagesNotifications, numberOfUnreadMessages= numberOfUnreadMessages  ,JsonRequestBehavior.AllowGet });
        }


    }
}