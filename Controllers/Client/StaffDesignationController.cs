using PMS.DAL;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers.Client
{
    [Authorize]
    public class StaffDesignationController : Controller
    {
        StaffDesignationDAL staffDesignationDAL;
        public StaffDesignationController()
        {
            staffDesignationDAL = new StaffDesignationDAL();
        }
        public ActionResult Index()
        {
            return RedirectToAction("DisplayStaffDesignation");
        }
        public ActionResult AddStaffDesignation()
        {

            return View();
        }
        public ActionResult DisplayStaffDesignation()
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            List<StaffDesignation> staffCategoriesData = staffDesignationDAL.GetStaffDesignationDataList(companyId);
            return View(staffCategoriesData);
        }
        public ActionResult UpdateStaffDesignation(int id)
        {

            StaffDesignation StaffDesignation = staffDesignationDAL.GetStaffDesignationDataByStaffDesignationCode(id, User.Identity.Name);
            if (StaffDesignation == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to update";
                TempData["ResultMessageTitle"] = "Updation Failed";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayStaffDesignation");
            }
            else
            {
                return View(StaffDesignation);
            }
        }
        public ActionResult InsertStaffDesignationData()
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            string staffDesignationName = Request["staffdesignationname"];
            string staffDesignationDescription = Request["staffdesignationdescription"];
            int staffdesignationrank =int.Parse( Request["staffdesignationrank"]);
            string[] res = staffDesignationDAL.InsertStaffDesignationData(staffDesignationName, staffDesignationDescription, staffdesignationrank,User.Identity.Name, companyId);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayStaffDesignation");
        }
        public ActionResult UpdateStaffDesignationData(int id)
        {
            //int id = 0;
            //int.TryParse(Request["usertypeid"], out id);
            string staffDesignationName = Request["staffdesignationname"];
            string staffDesignationDescription = Request["staffdesignationdescription"];

            int staffdesignationrank = int.Parse(Request["staffdesignationrank"]);
            string[] res = staffDesignationDAL.UpdateStaffDesignationData(staffDesignationName, staffDesignationDescription, staffdesignationrank, id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayStaffDesignation");
        }
        public ActionResult DeleteStaffDesignationData(int id)
        {
            string[] res = staffDesignationDAL.DeleteStaffDesignationData(id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayStaffDesignation");
        }
        public ActionResult ViewStaffDesignation(int id)
        {
            StaffDesignation StaffDesignation = staffDesignationDAL.GetStaffDesignationDataByStaffDesignationCode(id, User.Identity.Name);
            if (StaffDesignation == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to To View";
                TempData["ResultMessageTitle"] = "View";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayStaffDesignation");
            }
            else
            {
                return View(StaffDesignation);
            }
        }

    }
}