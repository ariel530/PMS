using Newtonsoft.Json;
using PMS.DAL;
using PMS.DynamicBindingModels;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PMS.Controllers.Client
{
    [Authorize]
    public class TeamManagementController : Controller
    {
        // GET: TeamManagement
        StaffCategoryDAL staffCategoryDAL;
        TeamWiseStaffDesignationDAL teamWiseStaffDesignationDAL;
        StaffDesignationDAL staffDesignationDAL;
        StaffInfoDAL staffInfoDAL;
        TeamInfoOverviewDAL teamInfoOverviewDAL;
        // GET: DailyExpenseManagement

        public TeamManagementController()
        {
            staffCategoryDAL = new StaffCategoryDAL();
            teamWiseStaffDesignationDAL = new TeamWiseStaffDesignationDAL();
            staffDesignationDAL = new StaffDesignationDAL();
            staffInfoDAL = new StaffInfoDAL();
            teamInfoOverviewDAL = new TeamInfoOverviewDAL();
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddTeam()
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            TeamWiseDesignation_StaffCategory_ForTeamInsertion teamdesignatonInfo = new TeamWiseDesignation_StaffCategory_ForTeamInsertion();
            teamdesignatonInfo.StaffCategories = staffCategoryDAL.GetStaffCategoryDataListForDropDown(companyId);
            if (!teamdesignatonInfo.StaffCategories.Any())
            {
                TempData["ResultMessage"] = "Unable to perform team insertion. Add Staff Category to proceed for Team insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddStaffCategory", "StaffCategory");
            }
            teamdesignatonInfo.TeamWiseStaffDesignations = teamWiseStaffDesignationDAL.GetTeamWiseStaffDesignationDataListForDropDown(companyId);

            return View(teamdesignatonInfo);
        }
        public JsonResult getStaffMemerDataByCategoryId(string staffcategoryid)
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            int _staffCategoryId = int.Parse(staffcategoryid);


            List<Tuple<String, String>> res = staffInfoDAL.GetAllStaffDataByCategoryId(_staffCategoryId, companyId);


            var uniquenessResult = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { uniquenessResult = uniquenessResult, JsonRequestBehavior.AllowGet });
        }
        public JsonResult getStaffDesignationDataByMemberId(string staffmemberid)
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());



            Tuple<int, string> res = staffDesignationDAL.GetStaffDesignationInfoByStaffId(staffmemberid, companyId);


            var uniquenessResult = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { uniquenessResult = uniquenessResult, JsonRequestBehavior.AllowGet });
        }
        public JsonResult InsertTeamData(FormCollection formCollection)
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            string teamname = formCollection.Get("teamname");
            string description = formCollection.Get("teamdescription");
            int totalrowcount = int.Parse(formCollection.Get("totalrowcount"));
            string memberid = "";
            int designationid = 0;
            string designationtype = "";

            List<TeamInfoMemberDetail> memberDetails = new List<TeamInfoMemberDetail>();
            for (int i = 0; i < totalrowcount; i++)
            {
                memberid = (formCollection.Get(("memberid_" + i)));
                designationid = int.Parse(formCollection.Get(("designationid_" + i)));
                designationtype = formCollection.Get(("designationtype_" + i));

                memberDetails.Add(new TeamInfoMemberDetail()
                {
                    TeamMemberId = memberid,
                    TeamMemberDesignationId = designationid,
                    TeamMemberDesignationType = designationtype,
                    AddedBy = User.Identity.Name,
                    CompanyId = companyId
                });
            }

            TeamInfoOverview teamInfoOverview = new TeamInfoOverview(teamname, description, memberDetails.Count, User.Identity.Name, DateTime.Now, companyId);



            String[] res = teamInfoOverviewDAL.InsertTeamInfoData(teamInfoOverview, memberDetails);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];

            var uniquenessResult = JsonConvert.SerializeObject(res[1], Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { uniquenessResult = uniquenessResult, JsonRequestBehavior.AllowGet });
        }



        public ActionResult DisplayTeams()
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            List<TeamInfoOverview_UserImageId_ForDisplay> teamInfo = teamInfoOverviewDAL.GetTeamInfoOverviewData(companyId);
            return View(teamInfo);
        }

        public ActionResult ViewTeamInfoData(int id)
        {
            TeamMemberOverview_Detail_ForViewUpdate teamMemberDetail = teamInfoOverviewDAL.GetTeamCompleteDetailById(id);
            return View(teamMemberDetail);

        }

        public ActionResult DeleteTeamInfoData(int id)
        {
            string[] res = teamInfoOverviewDAL.DeleteTeamInfoData(id,User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayTeams");
        }




    }


}