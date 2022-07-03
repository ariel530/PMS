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
    public class ProjectStatusController : Controller
    {

        // GET: ProjectStatus
        ProjectStatusDAL projectStatusDAL;
        public ProjectStatusController()
        {
            projectStatusDAL = new ProjectStatusDAL();
        }
        public ActionResult Index()
        {
            return RedirectToAction("DisplayProjectStatus");
        }

        public ActionResult AddProjectStatus(string resultMessage = null, string resultMessageTitle = null, string resultStatus = null)
        {
            return View();

        }
        public ActionResult DisplayProjectStatus(string resultMessage = null, string resultMessageTitle = null, string resultStatus = null)
        {


            List<ProjectStatus> projectStatusesData = projectStatusDAL.GetProjectStatusDataList(User.Identity.Name);
            return View(projectStatusesData);
        }

        public ActionResult UpdateProjectStatus(int id)
        {
            ProjectStatus projectStatus = projectStatusDAL.GetProjectStatusDataByProjectStatusId(id, User.Identity.Name);
            if (projectStatus == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to update";
                TempData["ResultMessageTitle"] = "Updation Failed !";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayProjectStatus");
            }
            else
            {
                return View(projectStatus);
            }
        }


        public ActionResult InsertProjectStatusData()
        {
            string projectStatusName = Request["projectstatusname"];
            string projectStatusBackGroundColor = Request["projectStatusbackgroundcolor"];
            string projectStatusTextColor = Request["projectStatustextcolor"];
            string projectStatusDescription = Request["projectStatusdescription"];
            bool projectStatusDisplayedMessage = bool.Parse(Request["projectstatusdisplayedmessage"].ToString());


            string[] res = projectStatusDAL.InsertProjectStatusData(projectStatusName, projectStatusBackGroundColor, projectStatusTextColor, projectStatusDescription, projectStatusDisplayedMessage, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayProjectStatus");
        }

        public ActionResult UpdateProjectStatusData(int id)
        {
            string projectStatusName = Request["projectStatusname"];
            string projectStatusBackGroundColor = Request["projectStatusbackgroundcolor"];
            string projectStatusTextColor = Request["projectStatustextcolor"];
            string projectStatusDescription = Request["projectStatusdescription"];
            bool projectStatusDisplayedMessage = bool.Parse(Request["projectstatusdisplayedmessage"].ToString());

            string[] res = projectStatusDAL.UpdateProjectStatusData(projectStatusName, projectStatusBackGroundColor, projectStatusTextColor, projectStatusDescription, projectStatusDisplayedMessage, id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayProjectStatus");
        }
        public ActionResult DeleteProjectStatusData(int id)
        {

            string[] res = projectStatusDAL.DeleteProjectStatusData(id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayProjectStatus");
        }
        public ActionResult ViewProjectStatus(int id)
        {
            ProjectStatus projectStatus = projectStatusDAL.GetProjectStatusDataByProjectStatusId(id, User.Identity.Name);
            if (projectStatus == null)
            {

                TempData["ResultMessage"] = "Something went wrong. Unable to View";
                TempData["ResultMessageTitle"] = "View Failed !";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayProjectStatus");
            }
            else
            {
                return View(projectStatus);
            }
        }





    }
}