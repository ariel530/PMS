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
    public class StaffCategoryController : Controller
    {
        StaffCategoryDAL staffCategoryDAL;
        public StaffCategoryController()
        {
            staffCategoryDAL = new StaffCategoryDAL();
        }
        public ActionResult Index()
        {
            return RedirectToAction("DisplayStaffCategory");
        }
        public ActionResult AddStaffCategory()
        {

            return View();
        }
        public ActionResult DisplayStaffCategory()
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            List<StaffCategory> staffCategoriesData = staffCategoryDAL.GetStaffCategoryDataList(companyId);
            return View(staffCategoriesData);
        }
        public ActionResult UpdateStaffCategory(int id)
        {

            StaffCategory StaffCategory = staffCategoryDAL.GetStaffCategoryDataByStaffCategoryCode(id, User.Identity.Name);
            if (StaffCategory == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to update";
                TempData["ResultMessageTitle"] = "Updation Failed";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayStaffCategory");
            }
            else
            {
                return View(StaffCategory);
            }
        }
        public ActionResult InsertStaffCategoryData()
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            string staffCategoryName = Request["staffcategoryname"];
            string staffCategoryDescription = Request["staffcategorydescription"];
            string[] res = staffCategoryDAL.InsertStaffCategoryData(staffCategoryName, staffCategoryDescription, User.Identity.Name,companyId);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayStaffCategory");
        }
        public ActionResult UpdateStaffCategoryData(int id)
        {
            //int id = 0;
            //int.TryParse(Request["usertypeid"], out id);
            string staffCategoryName = Request["staffcategoryname"];
            string staffCategoryDescription = Request["staffcategorydescription"];

            string[] res = staffCategoryDAL.UpdateStaffCategoryData(staffCategoryName, staffCategoryDescription, id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayStaffCategory");
        }
        public ActionResult DeleteStaffCategoryData(int id)
        {
            string[] res = staffCategoryDAL.DeleteStaffCategoryData(id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayStaffCategory");
        }
        public ActionResult ViewStaffCategory(int id)
        {
            StaffCategory StaffCategory = staffCategoryDAL.GetStaffCategoryDataByStaffCategoryCode(id, User.Identity.Name);
            if (StaffCategory == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to To View";
                TempData["ResultMessageTitle"] = "View";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayStaffCategory");
            }
            else
            {
                return View(StaffCategory);
            }
        }

    }
}