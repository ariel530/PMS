using Newtonsoft.Json;
using PMS.DAL;
using PMS.DynamicBindingModels;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PMS.Controllers.Client
{
    [Authorize]
    public class ProjectController : Controller
    {
        // GET: Project
        ProjectInfoDAL projectInfoDAL;
        ProjectTypeDAL projectTypeDAL;
        ProjectStatusDAL projectStatusDAL;
        ProjectPriorityDAL projectPriorityDAL;
        CustomerInfoDAL customerInfoDAL;
        CountryDAL countryDAL;
        public ProjectController()
        {
            projectInfoDAL = new ProjectInfoDAL();
            projectTypeDAL = new ProjectTypeDAL();
            projectStatusDAL = new ProjectStatusDAL();
            projectPriorityDAL = new ProjectPriorityDAL();
            customerInfoDAL = new CustomerInfoDAL();
            countryDAL = new CountryDAL();
        }
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult AddProject()
        {
            Project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate = new Project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate();
            project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.CountryData = countryDAL.GetCountryDataListForDropDown();
            if (!project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.CountryData.Any())
            {
                return RedirectToAction("Error_505_ForUser", "Error");
            }
            project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.CustomerInfoData = customerInfoDAL.GetCustomerDataListForDropdown(User.Identity.Name);
            if (!project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.CustomerInfoData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform project insertion. Add Customer Info to proceed for Project insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddCustomer", "Customer");
            }
            project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectPriorityData = projectPriorityDAL.GetProjectPriorityDataListForDropdown(User.Identity.Name);
            if (!project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectPriorityData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform project insertion. Add Project Priority Data to proceed for Project insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddProjectPriority", "ProjectPriority");
            }
            project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectStatusData = projectStatusDAL.GetProjectStatusDataListForDropDown(User.Identity.Name);
            if (!project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectStatusData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform project insertion. Add Project Status Data to proceed for Project insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddProjectStatus", "ProjectStatus");
            }
            project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectTypeData = projectTypeDAL.GetProjectTypeDataListForDropDown(User.Identity.Name);
            if (!project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectTypeData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform project insertion. Add Project Type Data to proceed for Project insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddProjectType", "ProjectType");
            }


            return View(project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate);
        }
        public ActionResult DisplayProject()
        {
            List<Project_Country_Priority_ForDisplay> project_Country_Priority_ForDisplays = projectInfoDAL.GetProjectDataList(User.Identity.Name);
            return View(project_Country_Priority_ForDisplays);
        }
        public ActionResult MapProject()
        {
            return View();
        }
        public ActionResult MapProjectCustomization()
        {
            return View();
        }
        public ActionResult UpdateProject(int id)
        {
            Project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate = new Project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate();
            project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.CountryData = countryDAL.GetCountryDataListForDropDown();
            if (!project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.CountryData.Any())
            {
                return RedirectToAction("Error_505_ForUser", "Error");
            }
            project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.CustomerInfoData = customerInfoDAL.GetCustomerDataListForDropdown(User.Identity.Name);
            if (!project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.CustomerInfoData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform project updation. Add Customer Info to proceed for Project updation..";
                TempData["ResultMessageTitle"] = "Updation Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddCustomer", "Customer");
            }
            project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectPriorityData = projectPriorityDAL.GetProjectPriorityDataListForDropdown(User.Identity.Name);
            if (!project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectPriorityData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform project updation. Add Project Priority Data to proceed for Project updation..";
                TempData["ResultMessageTitle"] = "Updation Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddProjectPriority", "ProjectPriority");
            }
            project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectStatusData = projectStatusDAL.GetProjectStatusDataListForDropDown(User.Identity.Name);
            if (!project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectStatusData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform project updation. Add Project Status Data to proceed for Project updation..";
                TempData["ResultMessageTitle"] = "Updation Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddProjectStatus", "ProjectStatus");
            }
            project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectTypeData = projectTypeDAL.GetProjectTypeDataListForDropDown(User.Identity.Name);
            if (!project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectTypeData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform project updation. Add Project Type Data to proceed for Project updation..";
                TempData["ResultMessageTitle"] = "Updation Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddProjectType", "ProjectType");
            }
            project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectInfoData = projectInfoDAL.GetProjectDataById(id, User.Identity.Name);
            if (project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectInfoData == null)
            {
                TempData["ResultMessage"] = "Unable to perform project updation. Add Project Info Data to proceed for Project updation..";
                TempData["ResultMessageTitle"] = "Updation Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddProject", "Project");
            }
            project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate.ProjectFilesDetails = projectInfoDAL.GetProjectFileDetailsData(id);
            return View(project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate);


        }
        public ActionResult ViewProjectDetail(int id)
        {
            Project_Country_Status_DetailsForView project_Country_Status_DetailsForView = projectInfoDAL.GetProjectDataByIdForDisplay(id, User.Identity.Name);
            if (project_Country_Status_DetailsForView.ProjectInfoData == null)
            {
                TempData["ResultMessage"] = "Unable to perform project View. Add Project Info Data to proceed for Project View..";
                TempData["ResultMessageTitle"] = "View Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddProject", "Project");
            }
            project_Country_Status_DetailsForView.ProjectFilesDetails = projectInfoDAL.GetProjectFileDetailsData(id);

            return View(project_Country_Status_DetailsForView);
        }
        public ActionResult ViewProjectSpecific(int id)
        {
            Project_Country_Status_DetailsForView project_Country_Status_DetailsForView = projectInfoDAL.GetProjectDataByIdForDisplay(id, User.Identity.Name);
            if (project_Country_Status_DetailsForView.ProjectInfoData == null)
            {
                TempData["ResultMessage"] = "Unable to perform project View. Add Project Info Data to proceed for Project View..";
                TempData["ResultMessageTitle"] = "View Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddProject", "Project");
            }
            return View(project_Country_Status_DetailsForView);
        }
        public ActionResult InsertProjectInfoData()
        {
            string projectname = Request["projectname"];
            string projectdescription = Request["projectdescription"];
            int projectStatus = int.Parse(Request["projectStatus"]);
            string clientcompany = Request["clientcompany"];
            string country = Request["country"];
            int projectType = int.Parse(Request["projectType"]);
            int projectPriority = int.Parse(Request["projectPriority"]);
            string projectsearchingkeywords = Request["projectsearchingkeywords"];
            //            projectsearchingkeywords = projectsearchingkeywords.Replace(",", "^@@^");
            string projectpath = Request["projectpath"];
            string customer = Request["customer"];
            double estimatedbudget = double.Parse(Request["estimatedbudget"]);
            double totalamountspent = double.Parse(Request["totalamountspent"]);
            int estimatedprojectduration = int.Parse(Request["estimatedprojectduration"]);
            DateTime? recieveddate = null;
            if (Request["recieveddate"]!="")
            {
                recieveddate = DateTime.Parse(Request["recieveddate"]);
            }
            DateTime? delivereddate = null;
            if (Request["delivereddate"] != "")
            {
                delivereddate = DateTime.Parse(Request["delivereddate"]);
            }
            DateTime? startdate = null;
            if (Request["startdate"] != "")
            {
                startdate = DateTime.Parse(Request["startdate"]);
            }
            DateTime? submitdate = null;
            if (Request["submitdate"] != "")
            {
                submitdate = DateTime.Parse(Request["submitdate"]);
            }
            DateTime? startTime = null;
            if (Request["startTime"] != "")
            {
                startTime = DateTime.Parse(Request["startTime"]);
            }
            DateTime? endTime = null;
            if (Request["endTime"] != "")
            {
                endTime = DateTime.Parse(Request["endTime"]);
            }
            ProjectInfo projectInfo = new ProjectInfo(1, projectname, projectdescription, projectStatus, clientcompany
                , projectType, projectPriority, projectsearchingkeywords, projectpath, customer, country, estimatedbudget,
                totalamountspent, estimatedprojectduration, recieveddate, delivereddate, startdate, submitdate, startTime, endTime, false, "", null, "", null, "", null,User.Identity.Name);
            string[] res = projectInfoDAL.InsertProjectData(projectInfo, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayProject");
        }
        public ActionResult UpdateProjectInfoData(int id)
        {
            string projectname = Request["projectname"];
            string previouscountry = Request["previouscountry"];
            string projectdescription = Request["projectdescription"];
            int projectStatus = int.Parse(Request["projectStatus"]);
            string clientcompany = Request["clientcompany"];
            string country = Request["country"];
            int projectType = int.Parse(Request["projectType"]);
            int projectPriority = int.Parse(Request["projectPriority"]);
            string projectsearchingkeywords = Request["projectsearchingkeywords"];
            //            projectsearchingkeywords = projectsearchingkeywords.Replace(",", "^@@^");
            string projectpath = Request["projectpath"];
            string customer = Request["customer"];
            double estimatedbudget = double.Parse(Request["estimatedbudget"]);
            double totalamountspent = double.Parse(Request["totalamountspent"]);
            int estimatedprojectduration = int.Parse(Request["estimatedprojectduration"]);
            DateTime? recieveddate = null;
            if (Request["recieveddate"] != "")
            {
                recieveddate = DateTime.Parse(Request["recieveddate"]);
            }
            DateTime? delivereddate = null;
            if (Request["delivereddate"] != "")
            {
                delivereddate = DateTime.Parse(Request["delivereddate"]);
            }
            DateTime? startdate = null;
            if (Request["startdate"] != "")
            {
                startdate = DateTime.Parse(Request["startdate"]);
            }
            DateTime? submitdate = null;
            if (Request["submitdate"] != "")
            {
                submitdate = DateTime.Parse(Request["submitdate"]);
            }
            DateTime? startTime = null;
            if (Request["startTime"] != "")
            {
                startTime = DateTime.Parse(Request["startTime"]);
            }
            DateTime? endTime = null;
            if (Request["endTime"] != "")
            {
                endTime = DateTime.Parse(Request["endTime"]);
            }
            ProjectInfo projectInfo = new ProjectInfo(id, projectname, projectdescription, projectStatus, clientcompany
                , projectType, projectPriority, projectsearchingkeywords, projectpath, customer, country, estimatedbudget,
                totalamountspent, estimatedprojectduration, recieveddate, delivereddate, startdate, submitdate, startTime, endTime, false, "", null, "", null, "", null,User.Identity.Name);
            string[] res = projectInfoDAL.UpdateProjectData(projectInfo, previouscountry, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayProject");
        }
        public ActionResult DeleteProjectInfoData(int id)
        {
            string[] res = projectInfoDAL.DeleteProjectInfoData(id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayProject");
        }

        public ActionResult DeleteProjectFileDetailData(int id)
        {
            string[] res = projectInfoDAL.DeleteProjectFileDetailData(id, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            int projectId= int.Parse(Request["projectId"]);
            return RedirectToAction("UpdateProject/"+projectId);
        }


        public JsonResult GetProjectsForMapCount()
        {
            List<CustomersProjectsMapCount> customersProjectsMapCounts = projectInfoDAL.GetProjectsCountsForMap(User.Identity.Name);

            //string[] res = countryDAL.InsertCountryData(countryCode.ToUpper(), countryName, Customer.Identity.Name);


            //var CustomerProjectsOnMap = JsonConvert.SerializeObject(customersProjectsMapCounts, Formatting.None, new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //});


            return Json(customersProjectsMapCounts, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetSpecificProjectFileDetail(int id)
        {
           ProjectFilesDetail projectFilesDetails = projectInfoDAL.GetProjectFileDetailsDataById(id);

            //string[] res = countryDAL.InsertCountryData(countryCode.ToUpper(), countryName, Customer.Identity.Name);


            var ProjectFilesDetails = JsonConvert.SerializeObject(projectFilesDetails, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { ProjectFilesDetails = ProjectFilesDetails, JsonRequestBehavior.AllowGet });
        }

        public ActionResult TotalEstimatedBudget()
        {
            return View();
        }




        public JsonResult file_upload_parser(FormCollection formCollection)
        {
            string res = "Uploaded successfully...";
            try
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    string fileName = Request.Files[0].FileName;
                    string fileSize = (file.InputStream.Length*1.0/100).ToString()+" kb";
                    string title = Request["filetitle"];
                    string projectId = Request["projectidforfile"];
                    //  ["name"]; // The file name
                                                                 //string fileTmpLoc = Request.Files[0].le ["tmp_name"]; // File in the PHP tmp folder
                                                                 //$fileType = $_FILES["file1"]["type"]; // The type of file it is
                                                                 //$fileSize = $_FILES["file1"]["size"]; // File size in bytes
                                                                 //$fileErrorMsg = $_FILES["file1"]["error"]; // 0 for false... and 1 for true
                                                                 //                if (!$fileTmpLoc) { // if file not chosen
                                                                 //                    echo "ERROR: Please browse for a file before clicking the upload button.";
                                                                 //                    exit();
                                                                 //                }
                                                                 //                if (move_uploaded_file($fileTmpLoc, "test_uploads/$fileName"))
                                                                 //                {
                                                                 //                    echo "$fileName upload is complete";
                                                                 //                }
                                                                 //                else
                                                                 //                {
                                                                 //                    echo "move_uploaded_file function failed";
                                                                 //                }
                    var ext = Path.GetExtension(file.FileName);
                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    string filePath = projectId + "/" + name.ToUpper() + "_" + "temp" + "_" + DateTime.Now.ToString().Replace(":", String.Empty).Replace("/", String.Empty).Replace(" ", String.Empty) + "_" + ext; //appending the name with id  
                                                                                                                                                                                                                      // store the file inside ~/project folder(Img)  
                    var path = Path.Combine(Server.MapPath("~/ProjectFiles"), filePath);
                    if (!Directory.Exists(Server.MapPath("~/ProjectFiles/" + projectId)))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/ProjectFiles/" + projectId));
                    }
                    file.SaveAs(path);

                    ProjectFilesDetail projectFilesDetail = new ProjectFilesDetail()
                    {
                        Title = title,
                        FileName = fileName,
                        FileSize = fileSize,
                        FilePath = "ProjectFiles/" + filePath,
                        ProjectId = int.Parse(projectId)
                    };

                    projectInfoDAL.InsertProjectFilesDetailData(projectFilesDetail, User.Identity.Name, User.Identity.Name);
                }

            }catch(Exception ex)
            {
                res = ex.Message;
            }


            return Json(new { res, JsonRequestBehavior.AllowGet });
        }
    }
}


    
