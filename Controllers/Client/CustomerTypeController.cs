using PMS.DAL;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    [Authorize]
    public class CustomerTypeController : Controller
    {
        // GET: CustomerType
        
        CustomerTypeDAL customerTypeDAL;
        public CustomerTypeController()
        {
            customerTypeDAL = new CustomerTypeDAL();
        }
        public ActionResult Index()
        {
            return RedirectToAction("DisplayCustomerType");
        }
        public ActionResult AddCustomerType(string resultMessage = null, string resultMessageTitle = null, string resultStatus = null)
        {
    
            return View();
        }
        public ActionResult DisplayCustomerType(string resultMessage = null, string resultMessageTitle = null, string resultStatus = null)
        {

            List<CustomerType> coutryData = customerTypeDAL.GetCustomerTypeDataList(User.Identity.Name);
            return View(coutryData);
        }
        public ActionResult UpdateCustomerType(int id)
        {

            CustomerType CustomerType = customerTypeDAL.GetCustomerTypeDataByCustomerTypeCode(id, User.Identity.Name);
            if (CustomerType == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to update"; ;
                TempData["ResultMessageTitle"] = "Updation Failed";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("DisplayCustomerType");
            }
            else
            {
                return View(CustomerType);
            }
        }
        public ActionResult InsertCustomerTypeData()
        {
            string customerTypeName = Request["customertypename"];
            string customerTypeDescription = Request["customertypedescription"];
            int customerTypePoints=int.Parse(  Request["customertypepoints"]);
            string[] res = customerTypeDAL.InsertCustomerTypeData(customerTypeName, customerTypeDescription, customerTypePoints, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];

            return RedirectToAction("DisplayCustomerType");
        }
        public ActionResult UpdateCustomerTypeData(int id)
        {
            //int id = 0;
            //int.TryParse(Request["usertypeid"], out id);
            string customerTypeName = Request["customertypename"];
            string customerTypeDescription = Request["customertypedescription"];
            int customerTypePoints = int.Parse(Request["customertypepoints"]);

            string[] res = customerTypeDAL.UpdateCustomerTypeData(customerTypeName, customerTypeDescription, customerTypePoints, id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];

            return RedirectToAction("DisplayCustomerType");
        }
        public ActionResult DeleteCustomerTypeData(int id)
        {
            string[] res = customerTypeDAL.DeleteCustomerTypeData(id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];

            return RedirectToAction("DisplayCustomerType");
        }
        public ActionResult ViewCustomerType(int id)
        {
            CustomerType CustomerType = customerTypeDAL.GetCustomerTypeDataByCustomerTypeCode(id, User.Identity.Name);
            if (CustomerType == null)
            {

                TempData["ResultMessage"] = "Something went wrong. Unable to To View";
                TempData["ResultMessageTitle"] = "View Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("DisplayCustomerType");
            }
            else
            {
                return View(CustomerType);
            }
        }

    }
}