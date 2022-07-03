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
    public class GenderController : Controller
    {
        GenderDAL genderDAL;
        public GenderController()
        {
            genderDAL = new GenderDAL();
        }
        public ActionResult Index()
        {
            return RedirectToAction("DisplayGender");
        }
        public ActionResult AddGender()
        {

            return View();
        }
        public ActionResult DisplayGender()
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            List<Gender> staffCategoriesData = genderDAL.GetGenderDataList(companyId);
            return View(staffCategoriesData);
        }
        public ActionResult UpdateGender(int id)
        {

            Gender Gender = genderDAL.GetGenderDataByGenderCode(id, User.Identity.Name);
            if (Gender == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to update";
                TempData["ResultMessageTitle"] = "Updation Failed";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayGender");
            }
            else
            {
                return View(Gender);
            }
        }
        public ActionResult InsertGenderData()
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            string genderName = Request["gendername"];
            string genderDescription = Request["genderdescription"];
            string[] res = genderDAL.InsertGenderData(genderName, genderDescription, User.Identity.Name, companyId);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayGender");
        }
        public ActionResult UpdateGenderData(int id)
        {
            //int id = 0;
            //int.TryParse(Request["usertypeid"], out id);
            string genderName = Request["gendername"];
            string genderDescription = Request["genderdescription"];

            string[] res = genderDAL.UpdateGenderData(genderName, genderDescription, id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayGender");
        }
        public ActionResult DeleteGenderData(int id)
        {
            string[] res = genderDAL.DeleteGenderData(id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayGender");
        }
        public ActionResult ViewGender(int id)
        {
            Gender Gender = genderDAL.GetGenderDataByGenderCode(id, User.Identity.Name);
            if (Gender == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to To View";
                TempData["ResultMessageTitle"] = "View";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayGender");
            }
            else
            {
                return View(Gender);
            }
        }

    }
}