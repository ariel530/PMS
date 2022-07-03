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
    public class ProjectTypeController : Controller
    {
        // GET: ProjectType
        ProjectTypeDAL projectTypeDAL;
        public ProjectTypeController()
        {
            projectTypeDAL = new ProjectTypeDAL();
        }
        public ActionResult Index()
        {
            return RedirectToAction("DisplayProjectType");
        }
        public ActionResult AddProjectType(string resultMessage = null, string resultMessageTitle = null, string resultStatus = null)
        {
            ViewData["ResultMessage"] = resultMessage;
            ViewData["ResultMessageTitle"] = resultMessageTitle;
            ViewData["ResultStatus"] = resultStatus;

            return View();
        }
        public ActionResult DisplayProjectType(string resultMessage = null, string resultMessageTitle = null, string resultStatus = null)
        {
            List<ProjectType> coutryData = projectTypeDAL.GetProjectTypeDataList(User.Identity.Name);
            return View(coutryData);
        }
        public ActionResult UpdateProjectType(int id)
        {

            ProjectType ProjectType = projectTypeDAL.GetProjectTypeDataByProjectTypeCode(id, User.Identity.Name);
            if (ProjectType == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to update";
                TempData["ResultMessageTitle"] = "Updation Failed";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayProjectType");
            }
            else
            {
                return View(ProjectType);
            }
        }
        public ActionResult InsertProjectTypeData()
        {
            string projectTypeName = Request["projecttypename"];
            string projectTypeDescription = Request["projecttypedescription"];
            string[] res = projectTypeDAL.InsertProjectTypeData(projectTypeName, projectTypeDescription,  User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayProjectType");
        }
        public ActionResult UpdateProjectTypeData(int id)
        {
            //int id = 0;
            //int.TryParse(Request["usertypeid"], out id);
            string projectTypeName = Request["projecttypename"];
            string projectTypeDescription = Request["projecttypedescription"];
        
            string[] res = projectTypeDAL.UpdateProjectTypeData(projectTypeName, projectTypeDescription,  id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayProjectType");
        }
        public ActionResult DeleteProjectTypeData(int id)
        {
            string[] res = projectTypeDAL.DeleteProjectTypeData(id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayProjectType");
        }
        public ActionResult ViewProjectType(int id)
        {
            ProjectType ProjectType = projectTypeDAL.GetProjectTypeDataByProjectTypeCode(id, User.Identity.Name);
            if (ProjectType == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to To View";
                TempData["ResultMessageTitle"] = "View";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayProjectType");
            }
            else
            {
                return View(ProjectType);
            }
        }

    }
}