using PMS.DAL;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers.Admin
{
    [Authorize]
    public class UserTypeController : Controller
    {
        // GET: UserType
        UserTypeDAL userTypeDAL;
        public UserTypeController()
        {
            userTypeDAL = new UserTypeDAL();
        }
        public ActionResult Index()
        {
            return RedirectToAction("DisplayUserType");
        }
        public ActionResult AddUserType(string resultMessage = null, string resultMessageTitle = null, string resultStatus = null)
        {
          

            return View();
        }
        public ActionResult DisplayUserType(string resultMessage = null, string resultMessageTitle = null, string resultStatus = null)
        {
            List<UserType> coutryData = userTypeDAL.GetUserTypeDataList();
            return View(coutryData);
        }
        public ActionResult UpdateUserType(int id)
        {

            UserType UserType = userTypeDAL.GetUserTypeDataByUserTypeCode(id);
            if (UserType == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to update";
                TempData["ResultMessageTitle"] = "Updation Failed";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayUserType");
            }
            else
            {
                return View(UserType);
            }
        }
        public ActionResult InsertUserTypeData()
        {
            string userTypeName = Request["usertypename"];
            string[] res = userTypeDAL.InsertUserTypeData(userTypeName, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayUserType");
        }
        public ActionResult UpdateUserTypeData(int id)
        {
            //int id = 0;
            //int.TryParse(Request["usertypeid"], out id);
            string userTypeName = Request["usertypename"];
            string[] res = userTypeDAL.UpdateUserTypeData(userTypeName, id, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayUserType");
        }
        public ActionResult DeleteUserTypeData(int id)
        {
            string[] res = userTypeDAL.DeleteUserTypeData(id, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayUserType");
        }
        public ActionResult ViewUserType(int id)
        {
            UserType UserType = userTypeDAL.GetUserTypeDataByUserTypeCode(id);
            if (UserType == null)
            {

                TempData["ResultMessage"] = "Something went wrong. Unable to To View";
                TempData["ResultMessageTitle"] = "View";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayUserType");
            }
            else
            {
                return View(UserType);
            }
        }




    }
}