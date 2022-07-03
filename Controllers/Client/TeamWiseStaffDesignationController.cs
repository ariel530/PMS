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
    public class TeamWiseStaffDesignationController : Controller
    {
        TeamWiseStaffDesignationDAL teamWiseStaffDesignationDAL;
        public TeamWiseStaffDesignationController()
        {
            teamWiseStaffDesignationDAL = new TeamWiseStaffDesignationDAL();
        }
        public ActionResult Index()
        {
            return RedirectToAction("DisplayTeamWiseStaffDesignation");
        }
        public ActionResult AddTeamWiseStaffDesignation()
        {

            return View();
        }
        public ActionResult DisplayTeamWiseStaffDesignation()
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            List<TeamWiseStaffDesignation> teamwisestaffdesignationCategoriesData = teamWiseStaffDesignationDAL.GetTeamWiseStaffDesignationDataList(companyId);
            return View(teamwisestaffdesignationCategoriesData);
        }
        public ActionResult UpdateTeamWiseStaffDesignation(int id)
        {

            TeamWiseStaffDesignation TeamWiseStaffDesignation = teamWiseStaffDesignationDAL.GetTeamWiseStaffDesignationDataByTeamWiseStaffDesignationCode(id, User.Identity.Name);
            if (TeamWiseStaffDesignation == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to update";
                TempData["ResultMessageTitle"] = "Updation Failed";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayTeamWiseStaffDesignation");
            }
            else
            {
                return View(TeamWiseStaffDesignation);
            }
        }
        public ActionResult InsertTeamWiseStaffDesignationData()
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            string teamwisestaffdesignationname = Request["teamwisestaffdesignationname"];
            string teamwisestaffdesignationdescription = Request["teamwisestaffdesignationdescription"];
            int teamwisestaffdesignationrank = int.Parse(Request["teamwisestaffdesignationrank"]);
            string[] res = teamWiseStaffDesignationDAL.InsertTeamWiseStaffDesignationData(teamwisestaffdesignationname, teamwisestaffdesignationdescription, teamwisestaffdesignationrank, User.Identity.Name, companyId);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayTeamWiseStaffDesignation");
        }
        public ActionResult UpdateTeamWiseStaffDesignationData(int id)
        {
            //int id = 0;
            //int.TryParse(Request["usertypeid"], out id);
            string teamwisestaffdesignationname = Request["teamwisestaffdesignationname"];
            string teamwisestaffdesignationdescription = Request["teamwisestaffdesignationdescription"];

            int teamwisestaffdesignationrank = int.Parse(Request["teamwisestaffdesignationrank"]);
            string[] res = teamWiseStaffDesignationDAL.UpdateTeamWiseStaffDesignationData(teamwisestaffdesignationname, teamwisestaffdesignationdescription, teamwisestaffdesignationrank, id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayTeamWiseStaffDesignation");
        }
        public ActionResult DeleteTeamWiseStaffDesignationData(int id)
        {
            string[] res = teamWiseStaffDesignationDAL.DeleteTeamWiseStaffDesignationData(id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayTeamWiseStaffDesignation");
        }
        public ActionResult ViewTeamWiseStaffDesignation(int id)
        {
            TeamWiseStaffDesignation TeamWiseStaffDesignation = teamWiseStaffDesignationDAL.GetTeamWiseStaffDesignationDataByTeamWiseStaffDesignationCode(id, User.Identity.Name);
            if (TeamWiseStaffDesignation == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to To View";
                TempData["ResultMessageTitle"] = "View";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayTeamWiseStaffDesignation");
            }
            else
            {
                return View(TeamWiseStaffDesignation);
            }
        }

    }
}