using PMS.DAL;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers.Common
{

    [Authorize]
    public class DailyExpenseTypeController : Controller
    {
        DailyExpenseTypeDAL dailyExpenseTypeDAL;
        // GET: DailyExpenseType
    public DailyExpenseTypeController()
        {
            dailyExpenseTypeDAL = new DailyExpenseTypeDAL();
        }
        public ActionResult Index()
        {
            return RedirectToAction("DisplayDailyExpenseType");
        }

        public ActionResult AddDailyExpenseType()
        {
            return View();
        }
       
      
        public ActionResult DisplayDailyExpenseType()
        {

            List<DailyExpenseType> coutryData = dailyExpenseTypeDAL.GetDailyExpenseTypeDataList(User.Identity.Name);
            return View(coutryData);
        }
        public ActionResult UpdateDailyExpenseType(int id)
        {

            DailyExpenseType DailyExpenseType = dailyExpenseTypeDAL.GetDailyExpenseTypeDataByDailyExpenseTypeCode(id, User.Identity.Name);
            if (DailyExpenseType == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to update"; ;
                TempData["ResultMessageTitle"] = "Updation Failed";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("DisplayDailyExpenseType");
            }
            else
            {
                return View(DailyExpenseType);
            }
        }
        public ActionResult InsertDailyExpenseTypeData()
        {
            string dailyExpenseTypeName = Request["dailyExpensetypename"];
            string dailyExpenseTypeDescription = Request["dailyExpensetypedescription"];
           string[] res = dailyExpenseTypeDAL.InsertDailyExpenseTypeData(dailyExpenseTypeName, dailyExpenseTypeDescription, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];

            return RedirectToAction("DisplayDailyExpenseType");
        }
        public ActionResult UpdateDailyExpenseTypeData(int id)
        {

            //int id = 0;
            //int.TryParse(Request["usertypeid"], out id);
            string dailyExpenseTypeName = Request["dailyExpensetypename"];
            string dailyExpenseTypeDescription = Request["dailyExpensetypedescription"];
           
            string[] res = dailyExpenseTypeDAL.UpdateDailyExpenseTypeData(dailyExpenseTypeName, dailyExpenseTypeDescription, id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];

            return RedirectToAction("DisplayDailyExpenseType");
        }
        public ActionResult DeleteDailyExpenseTypeData(int id)
        {
            string[] res = dailyExpenseTypeDAL.DeleteDailyExpenseTypeData(id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];

            return RedirectToAction("DisplayDailyExpenseType");
        }
        public ActionResult ViewDailyExpenseType(int id)
        {
            DailyExpenseType DailyExpenseType = dailyExpenseTypeDAL.GetDailyExpenseTypeDataByDailyExpenseTypeCode(id, User.Identity.Name);
            if (DailyExpenseType == null)
            {

                TempData["ResultMessage"] = "Something went wrong. Unable to To View";
                TempData["ResultMessageTitle"] = "View Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("DisplayDailyExpenseType");
            }
            else
            {
                return View(DailyExpenseType);
            }
        }

    }
}