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
    public class ProjectPriorityController : Controller
    {
        // GET: ProjectPriority
        ProjectPriorityDAL projectPriorityDAL;
        public ProjectPriorityController()
        {
            projectPriorityDAL = new ProjectPriorityDAL();
        }
        public ActionResult Index()
        {
            return RedirectToAction("DisplayProjectPriority");
        }
        public ActionResult AddProjectPriority(string resultMessage = null, string resultMessageTitle = null, string resultPriority = null)
        {

           return View();

        }
        public ActionResult DisplayProjectPriority(string resultMessage = null, string resultMessageTitle = null, string resultPriority = null)
        {

          
            List<ProjectPriority> projectPriorityesData = projectPriorityDAL.GetProjectPriorityDataList(User.Identity.Name);
            return View(projectPriorityesData);
        }
        public ActionResult UpdateProjectPriority(int id)
        {
            ProjectPriority projectPriority = projectPriorityDAL.GetProjectPriorityDataByProjectPriorityId(id, User.Identity.Name);
            if (projectPriority == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to update";
                TempData["ResultMessageTitle"] = "Updation Failed !";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayProjectPriority");
            }
            else
            {
                return View(projectPriority);
            }
        }
        public ActionResult InsertProjectPriorityData()
        {
            string projectPriorityName = Request["projectpriorityname"];
            string projectPriorityBackGroundColor = Request["projectPrioritybackgroundcolor"];
            string projectPriorityTextColor = Request["projectPrioritytextcolor"];
            string projectPriorityDescription = Request["projectPrioritydescription"];
            int projectPriorityPoints = int.Parse(Request["ProjectPriorityPoints"].ToString());


            string[] res = projectPriorityDAL.InsertProjectPriorityData(projectPriorityName, projectPriorityBackGroundColor, projectPriorityTextColor, projectPriorityDescription, projectPriorityPoints, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayProjectPriority");
        }
        public ActionResult UpdateProjectPriorityData(int id)
        {
            string projectPriorityName = Request["projectPriorityname"];
            string projectPriorityBackGroundColor = Request["projectPrioritybackgroundcolor"];
            string projectPriorityTextColor = Request["projectPrioritytextcolor"];
            string projectPriorityDescription = Request["projectPrioritydescription"];
            int projectPriorityPoints = int.Parse(Request["ProjectPriorityPoints"].ToString());

            string[] res = projectPriorityDAL.UpdateProjectPriorityData(projectPriorityName, projectPriorityBackGroundColor, projectPriorityTextColor, projectPriorityDescription, projectPriorityPoints, id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayProjectPriority");
        }
        public ActionResult DeleteProjectPriorityData(int id)
        {

            string[] res = projectPriorityDAL.DeleteProjectPriorityData(id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayProjectPriority");
        }
        public ActionResult ViewProjectPriority(int id)
        {
            ProjectPriority projectPriority = projectPriorityDAL.GetProjectPriorityDataByProjectPriorityId(id, User.Identity.Name);
            if (projectPriority == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to View";
                TempData["ResultMessageTitle"] = "View Failed !";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayProjectPriority");
            }
            else
            {
                return View(projectPriority);
            }
        }


    }
}