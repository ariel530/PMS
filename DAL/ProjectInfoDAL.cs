using PMS.DynamicBindingModels;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class ProjectInfoDAL
    {
        public string[] InsertProjectData(ProjectInfo projectInfo, string userName, string addedBy)
        {
           // string tableName = "PI_" + userName + "_ProjectInfo";
            string tableName = "ProjectInfo";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "insert into " + tableName + " (ProjectName,ProjectDescription,ProjectStatusId,ProjectClientCompany,ProjectTypeId" +
                    ",ProjectPriorityId,ProjectSearchingKeywords,ProjectPath,ProjectCustomerId,ProjectCountryCode,ProjectEstimatedBudget" +
                    ",ProjectTotalAmountSpent,ProjectEstimatedDuration,ProjectReceivedDate,ProjectDeliveredDate,ProjectStartDate" +
                    ",ProjectSubmitDate,ProjectStartTime,ProjectEndTime" +
                    ",AddedBy,AddedOn,UserInfoUserName) values(" +
                    "@ProjectName,@ProjectDescription,@ProjectStatusId,@ProjectClientCompany,@ProjectTypeId" +
                    ",@ProjectPriorityId,@ProjectSearchingKeywords,@ProjectPath,@ProjectCustomerId,@ProjectCountryCode,@ProjectEstimatedBudget" +
                    ",@ProjectTotalAmountSpent,@ProjectEstimatedDuration,@ProjectReceivedDate,@ProjectDeliveredDate,@ProjectStartDate" +
                    ",@ProjectSubmitDate,@ProjectStartTime,@ProjectEndTime" +
                    ",@AddedBy,@AddedOn,@UserInfoUserName)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("ProjectName", projectInfo.ProjectName);
                SqlParameter p2 = new SqlParameter("ProjectDescription", projectInfo.ProjectDescription);
                SqlParameter p3 = new SqlParameter("ProjectStatusId", projectInfo.ProjectStatusId);
                SqlParameter p4 = new SqlParameter("ProjectClientCompany", projectInfo.ProjectClientCompany);
                SqlParameter p5 = new SqlParameter("ProjectTypeId", projectInfo.ProjectTypeId);
                SqlParameter p6 = new SqlParameter("ProjectPriorityId", projectInfo.ProjectPriorityId);
                SqlParameter p7 = new SqlParameter("ProjectSearchingKeywords", projectInfo.ProjectSearchingKeywords);
                SqlParameter p8 = new SqlParameter("ProjectPath", projectInfo.ProjectPath);
                SqlParameter p9 = new SqlParameter("ProjectCustomerId", projectInfo.ProjectCustomerId);
                SqlParameter p10 = new SqlParameter("ProjectEstimatedBudget", projectInfo.ProjectEstimatedBudget);
                SqlParameter p11 = new SqlParameter("ProjectTotalAmountSpent", projectInfo.ProjectTotalAmountSpent);
                SqlParameter p12 = new SqlParameter("ProjectEstimatedDuration", projectInfo.ProjectEstimatedDuration);
                SqlParameter p13 = new SqlParameter("ProjectReceivedDate", projectInfo.ProjectReceivedDate);
                if (projectInfo.ProjectReceivedDate==null)
                {
                    p13 = new SqlParameter("ProjectReceivedDate", DBNull.Value);
                }
                SqlParameter p14 = new SqlParameter("ProjectDeliveredDate", projectInfo.ProjectDeliveredDate);
                if (projectInfo.ProjectDeliveredDate == null)
                {
                    p14 = new SqlParameter("ProjectDeliveredDate", DBNull.Value);
                }
                SqlParameter p15 = new SqlParameter("ProjectStartDate", projectInfo.ProjectStartDate);
                if (projectInfo.ProjectStartDate == null)
                {
                    p15 = new SqlParameter("ProjectStartDate", DBNull.Value);
                }
                SqlParameter p16 = new SqlParameter("ProjectSubmitDate", projectInfo.ProjectSubmitDate);
                if (projectInfo.ProjectSubmitDate == null)
                {
                    p16 = new SqlParameter("ProjectSubmitDate", DBNull.Value);
                }
                SqlParameter p17 = new SqlParameter("ProjectStartTime", projectInfo.ProjectStartTime);
                if (projectInfo.ProjectStartTime == null)
                {
                    p17 = new SqlParameter("ProjectStartTime", DBNull.Value);
                }
                SqlParameter p18 = new SqlParameter("ProjectEndTime", projectInfo.ProjectEndTime);
                if (projectInfo.ProjectEndTime == null)
                {
                    p18 = new SqlParameter("ProjectEndTime", DBNull.Value);
                }
                SqlParameter p19 = new SqlParameter("addedBy", addedBy);
                SqlParameter p20 = new SqlParameter("addedOn", DateTime.Now);
                SqlParameter p21 = new SqlParameter("ProjectCountryCode", projectInfo.ProjectCountryCode);
                SqlParameter p22 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
                cmd.Parameters.Add(p9);
                cmd.Parameters.Add(p10);
                cmd.Parameters.Add(p11);
                cmd.Parameters.Add(p12);
                cmd.Parameters.Add(p13);
                cmd.Parameters.Add(p14);
                cmd.Parameters.Add(p15);
                cmd.Parameters.Add(p16);
                cmd.Parameters.Add(p17);
                cmd.Parameters.Add(p18);
                cmd.Parameters.Add(p19);
                cmd.Parameters.Add(p20);
                cmd.Parameters.Add(p21);
                cmd.Parameters.Add(p22);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    UpdateProjectInMapCount(projectInfo.ProjectCountryCode, "", userName);
                    result[0] = "Project  with project name " + projectInfo.ProjectName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                }
                else
                {
                    result[0] = "Project  with project name " + projectInfo.ProjectName + " does not added successfully.";
                    result[1] = "fail";
                    result[2] = "Insertion Failed !";
                }
                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Unfortunately Some thing went Wrong.";
                result[1] = "fail";
                result[2] = "Unable to Insertion !";
                con.Close();
            }

            return result;

        }
        public string[] UpdateProjectData(ProjectInfo projectInfo, string previousCountryCode, string userName, string lastModifiedBy)
        {
           // string tableName = "PI_" + userName + "_ProjectInfo";
            string tableName = "ProjectInfo";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update  " + tableName + " Set ProjectName=@ProjectName,ProjectDescription=@ProjectDescription,ProjectStatusId=@ProjectStatusId,ProjectClientCompany=@ProjectClientCompany,ProjectTypeId=@ProjectTypeId" +
                    ",ProjectPriorityId=@ProjectPriorityId,ProjectSearchingKeywords=@ProjectSearchingKeywords,ProjectPath=@ProjectPath,ProjectCustomerId=@ProjectCustomerId,ProjectCountryCode=@ProjectCountryCode,ProjectEstimatedBudget=@ProjectEstimatedBudget" +
                    ",ProjectTotalAmountSpent=@ProjectTotalAmountSpent,ProjectEstimatedDuration=@ProjectEstimatedDuration,ProjectReceivedDate=@ProjectReceivedDate,ProjectDeliveredDate=@ProjectDeliveredDate,ProjectStartDate=@ProjectStartDate" +
                    ",ProjectSubmitDate=@ProjectSubmitDate,ProjectStartTime=@ProjectStartTime,ProjectEndTime=@ProjectEndTime" +
                    ",LastModifiedBy=@LastModifiedBy,LastModifiedOn=@LastModifiedOn where Id = @Id ";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("ProjectName", projectInfo.ProjectName);
                SqlParameter p2 = new SqlParameter("ProjectDescription", projectInfo.ProjectDescription);
                SqlParameter p3 = new SqlParameter("ProjectStatusId", projectInfo.ProjectStatusId);
                SqlParameter p4 = new SqlParameter("ProjectClientCompany", projectInfo.ProjectClientCompany);
                SqlParameter p5 = new SqlParameter("ProjectTypeId", projectInfo.ProjectTypeId);
                SqlParameter p6 = new SqlParameter("ProjectPriorityId", projectInfo.ProjectPriorityId);
                SqlParameter p7 = new SqlParameter("ProjectSearchingKeywords", projectInfo.ProjectSearchingKeywords);
                SqlParameter p8 = new SqlParameter("ProjectPath", projectInfo.ProjectPath);
                SqlParameter p9 = new SqlParameter("ProjectCustomerId", projectInfo.ProjectCustomerId);
                SqlParameter p10 = new SqlParameter("ProjectEstimatedBudget", projectInfo.ProjectEstimatedBudget);
                SqlParameter p11 = new SqlParameter("ProjectTotalAmountSpent", projectInfo.ProjectTotalAmountSpent);
                SqlParameter p12 = new SqlParameter("ProjectEstimatedDuration", projectInfo.ProjectEstimatedDuration);
                SqlParameter p13 = new SqlParameter("ProjectReceivedDate", projectInfo.ProjectReceivedDate);
                if (projectInfo.ProjectReceivedDate == null)
                {
                    p13 = new SqlParameter("ProjectReceivedDate", DBNull.Value);
                }
                SqlParameter p14 = new SqlParameter("ProjectDeliveredDate", projectInfo.ProjectDeliveredDate);
                if (projectInfo.ProjectDeliveredDate == null)
                {
                    p14 = new SqlParameter("ProjectDeliveredDate", DBNull.Value);
                }
                SqlParameter p15 = new SqlParameter("ProjectStartDate", projectInfo.ProjectStartDate);
                if (projectInfo.ProjectStartDate == null)
                {
                    p15 = new SqlParameter("ProjectStartDate", DBNull.Value);
                }
                SqlParameter p16 = new SqlParameter("ProjectSubmitDate", projectInfo.ProjectSubmitDate);
                if (projectInfo.ProjectSubmitDate == null)
                {
                    p16 = new SqlParameter("ProjectSubmitDate", DBNull.Value);
                }
                SqlParameter p17 = new SqlParameter("ProjectStartTime", projectInfo.ProjectStartTime);
                if (projectInfo.ProjectStartTime == null)
                {
                    p17 = new SqlParameter("ProjectStartTime", DBNull.Value);
                }
                SqlParameter p18 = new SqlParameter("ProjectEndTime", projectInfo.ProjectEndTime);
                if (projectInfo.ProjectEndTime == null)
                {
                    p18 = new SqlParameter("ProjectEndTime", DBNull.Value);
                }
                SqlParameter p19 = new SqlParameter("LastModifiedBy", lastModifiedBy);
                SqlParameter p20 = new SqlParameter("LastModifiedOn", DateTime.Now);
                SqlParameter p21 = new SqlParameter("ProjectCountryCode", projectInfo.ProjectCountryCode);
                SqlParameter p22 = new SqlParameter("Id", projectInfo.Id);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
                cmd.Parameters.Add(p9);
                cmd.Parameters.Add(p10);
                cmd.Parameters.Add(p11);
                cmd.Parameters.Add(p12);
                cmd.Parameters.Add(p13);
                cmd.Parameters.Add(p14);
                cmd.Parameters.Add(p15);
                cmd.Parameters.Add(p16);
                cmd.Parameters.Add(p17);
                cmd.Parameters.Add(p18);
                cmd.Parameters.Add(p19);
                cmd.Parameters.Add(p20);
                cmd.Parameters.Add(p21);
                cmd.Parameters.Add(p22);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    if (projectInfo.ProjectCountryCode.CompareTo(previousCountryCode) != 0)
                    {
                        UpdateProjectInMapCount(projectInfo.ProjectCountryCode, previousCountryCode, userName);
                    }
                    result[0] = "Project  with project name " + projectInfo.ProjectName + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully !";
                }
                else
                {
                    result[0] = "Project  with project name " + projectInfo.ProjectName + " does not updated successfully.";
                    result[1] = "fail";
                    result[2] = "Updation Failed !";
                }
                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Unfortunately Some thing went Wrong.";
                result[1] = "fail";
                result[2] = "Unable to Insertion !";
                con.Close();
            }

            return result;

        }
        public bool InsertProjectInMapCountByOne(string countryCode, string userName)
        {
         //   string tableName = "PCMC_" + userName + "_Country_MapCount";
            string tableName = "User_Country_MapCount";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                int projectsCount = 1;
                int countryCount = 0;
                string qry = "insert into " + tableName + " (CountryCode,ProjectsCount,CustomersCount," +
                    "AddedBy,AddedOn,UserInfoUserName) values(@CountryCode,@ProjectsCount,@CustomersCount,@addedBy,@addedOn,@UserInfoUserName)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CountryCode", countryCode);
                SqlParameter p2 = new SqlParameter("ProjectsCount", projectsCount);
                SqlParameter p3 = new SqlParameter("CustomersCount", countryCount);
                SqlParameter p4 = new SqlParameter("addedBy", userName);
                SqlParameter p5 = new SqlParameter("addedOn", DateTime.Now);
                SqlParameter p6 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }

            }
            catch (Exception ex)
            {
                con.Close();
                return false;

            }
        }
        public bool UpdateProjectInMapCount(string countryCode, string previousCountryCode, string userName)
        {
            string tableName = "User_Country_MapCount";
            if (previousCountryCode != "")
            {
                DecreamentProjectInMapCount(previousCountryCode, userName);
            }
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {


                string qry = "Update " + tableName + " Set ProjectsCount=ProjectsCount+1 " +
                    ",LastModifiedBy=@LastModifiedBy, LastModifiedOn=@LastModifiedOn where CountryCode=@CountryCode and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CountryCode", countryCode);
                SqlParameter p2 = new SqlParameter("LastModifiedBy", userName);
                SqlParameter p3 = new SqlParameter("LastModifiedOn", DateTime.Now);
                SqlParameter p4 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    InsertProjectInMapCountByOne(countryCode, userName);
                    con.Close();
                    return false;
                }

            }
            catch (Exception ex)
            {
                con.Close();
                return false;

            }

        }
        public bool DecreamentProjectInMapCount(string previousCountryCode, string userName)
        {
            string tableName = "User_Country_MapCount";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {


                string qry = "Update " + tableName + " Set ProjectsCount=ProjectsCount-1 " +
                    ",LastModifiedBy=@LastModifiedBy, LastModifiedOn=@LastModifiedOn where CountryCode=@CountryCode and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CountryCode", previousCountryCode);
                SqlParameter p2 = new SqlParameter("LastModifiedBy", userName);
                SqlParameter p3 = new SqlParameter("LastModifiedOn", DateTime.Now);
                SqlParameter p4 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    con.Close();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                con.Close();
                return false;

            }

        }
        public List<CustomersProjectsMapCount> GetProjectCountsForMap(string userName)
        {
            List<CustomersProjectsMapCount> mapCounts = new List<CustomersProjectsMapCount>();
           // string tableName = "PCMC_" + userName + "_Country_MapCount";
            string tableName = "User_Country_MapCount";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {


                string qry = "Select  Country.CountryCode, CountryName,CustomersCount from " + tableName + ",Country where CustomersCount > 0 and " + tableName + ".CountryCode=Country.CountryCode and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CustomersProjectsMapCount customersProjectsMapCount = new CustomersProjectsMapCount(dr["CountryCode"].ToString(), dr["CountryName"].ToString(), int.Parse(dr["CustomersCount"].ToString()), 0);
                    mapCounts.Add(customersProjectsMapCount);

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();

            }

            return mapCounts;
        }
        public ProjectInfo GetProjectDataById(int id, string userName)
        {
           // string tableName = "PI_" + userName + "_ProjectInfo";
            string tableName = "ProjectInfo";
            ProjectInfo projectInfo = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where Id=@Id and IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", id);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];
                    DateTime? projectReceivedDate = dr["ProjectReceivedDate"].ToString() == "" ? null : (DateTime?)dr["ProjectReceivedDate"];
                    DateTime? projectDeliveredDate = dr["ProjectDeliveredDate"].ToString() == "" ? null : (DateTime?)dr["ProjectDeliveredDate"];
                    DateTime? projectStartDate = dr["ProjectStartDate"].ToString() == "" ? null : (DateTime?)dr["ProjectStartDate"];
                    DateTime? projectSubmitDate = dr["ProjectSubmitDate"].ToString() == "" ? null : (DateTime?)dr["ProjectSubmitDate"];
                    DateTime? projectStartTime = dr["ProjectStartTime"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(dr["ProjectStartTime"].ToString());
                    DateTime? projectEndTime = dr["ProjectEndTime"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(dr["ProjectEndTime"].ToString());

                    projectInfo = new ProjectInfo(int.Parse(dr["Id"].ToString()), dr["ProjectName"].ToString(),
                        dr["ProjectDescription"].ToString(), int.Parse(dr["ProjectStatusId"].ToString()), dr["ProjectClientCompany"].ToString(),
                       int.Parse(dr["ProjectTypeId"].ToString()), int.Parse(dr["ProjectPriorityId"].ToString()), dr["ProjectSearchingKeywords"].ToString(),
                        dr["ProjectPath"].ToString(), dr["ProjectCustomerId"].ToString(), dr["ProjectCountryCode"].ToString(),
                        double.Parse(dr["ProjectEstimatedBudget"].ToString()), double.Parse(dr["ProjectTotalAmountSpent"].ToString()), int.Parse(dr["ProjectEstimatedDuration"].ToString()),
                        projectReceivedDate, projectDeliveredDate, projectStartDate,
                        projectSubmitDate, projectStartTime, projectEndTime,
                        (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn,dr["UserInfoUserName"].ToString());

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return projectInfo;

        }
        public List<Project_Country_Priority_ForDisplay> GetProjectDataList(string userName)
        {
            //string projectTableName = "PI_" + userName + "_ProjectInfo";
            //string projectTypeTableName = "PT_" + userName + "_ProjectType";
            //string projectPriorityTableName = "PP_" + userName + "_ProjectPriority";
            //string projectStatusTableName = "PS_" + userName + "_ProjectStatus"; 
            
            string projectTableName = "ProjectInfo";
            string projectTypeTableName = "ProjectType";
            string projectPriorityTableName = "ProjectPriority";
            string projectStatusTableName = "ProjectStatus";
            List<Project_Country_Priority_ForDisplay> project_Country_Priority_ForDisplays = new List<Project_Country_Priority_ForDisplay>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select " + projectTableName + ".Id, ProjectName,ProjectCustomerId,ProjectSearchingKeywords,ProjectPath,CountryName,ProjectEstimatedBudget,ProjectTotalAmountSpent,ProjectDeliveredDate,ProjectStartDate," +
                      projectTableName + ".LastModifiedBy," + projectTableName + ".LastModifiedOn," + projectTableName + ".AddedBy," + projectTableName + ".AddedOn,ProjectStatusName,ProjectPriorityName,ProjectTypeName" +
                    " from  " + projectTableName + ", " + projectTypeTableName + ", " + projectPriorityTableName + ", " + projectStatusTableName + ",Country where  " + projectTableName + ".IsDeleted = 0 and " +
                     projectTableName + ".ProjectTypeId = " + projectTypeTableName + ".Id and " + projectTableName + ".ProjectPriorityId = " + projectPriorityTableName + ".Id" +
                    " and " + projectTableName + ".ProjectStatusId = " + projectStatusTableName + ".Id and Country.CountryCode = " + projectTableName + ".ProjectCountryCode and "+projectTableName+ ".UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];
                    DateTime? projectDeliveredDate = dr["ProjectDeliveredDate"].ToString() == "" ? null : (DateTime?)dr["ProjectDeliveredDate"];
                    DateTime? projectStartDate = dr["ProjectStartDate"].ToString() == "" ? null : (DateTime?)dr["ProjectStartDate"];

                    Project_Country_Priority_ForDisplay projectInfo = new Project_Country_Priority_ForDisplay(int.Parse(dr["Id"].ToString())
                                            , dr["ProjectName"].ToString(), dr["ProjectCustomerId"].ToString(), dr["ProjectSearchingKeywords"].ToString(), dr["ProjectPath"].ToString(), dr["CountryName"].ToString(),
                                            double.Parse(dr["ProjectEstimatedBudget"].ToString()), double.Parse(dr["ProjectTotalAmountSpent"].ToString()), dr["ProjectStatusName"].ToString(),
                                            dr["ProjectPriorityName"].ToString(), dr["ProjectTypeName"].ToString(), dr["LastModifiedBy"].ToString(),
                                            lastModifiedOn, dr["AddedBy"].ToString(), addedOn, projectDeliveredDate, projectStartDate);

                    project_Country_Priority_ForDisplays.Add(projectInfo);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return project_Country_Priority_ForDisplays;

        }
        public Project_Country_Status_DetailsForView GetProjectDataByIdForDisplay(int id, string userName)
        {
            //string projectTableName = "PI_" + userName + "_ProjectInfo";
            //string projectTypeTableName = "PT_" + userName + "_ProjectType";
            //string projectPriorityTableName = "PP_" + userName + "_ProjectPriority";
            //string projectStatusTableName = "PS_" + userName + "_ProjectStatus";
            string projectTableName = "ProjectInfo";
            string projectTypeTableName = "ProjectType";
            string projectPriorityTableName = "ProjectPriority";
            string projectStatusTableName = "ProjectStatus";
            Project_Country_Status_DetailsForView project_Country_Status_DetailsForView = new Project_Country_Status_DetailsForView();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select " + projectTableName + ".*,ProjectStatusName,ProjectPriorityName,ProjectTypeName,CountryName" +
                    " from  " + projectTableName + ", " + projectTypeTableName + ", " + projectPriorityTableName + ", " + projectStatusTableName + ",Country where  " + projectTableName + ".IsDeleted = 0 and " +
                     projectTableName + ".ProjectTypeId = " + projectTypeTableName + ".Id and " + projectTableName + ".ProjectPriorityId = " + projectPriorityTableName + ".Id" +
                    " and " + projectTableName + ".ProjectStatusId = " + projectStatusTableName + ".Id and Country.CountryCode = " + projectTableName + ".ProjectCountryCode" +
                    " and  " + projectTableName + ".Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", id);
                cmd.Parameters.Add(p1);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];
                    DateTime? projectReceivedDate = dr["ProjectReceivedDate"].ToString() == "" ? null : (DateTime?)dr["ProjectReceivedDate"];
                    DateTime? projectDeliveredDate = dr["ProjectDeliveredDate"].ToString() == "" ? null : (DateTime?)dr["ProjectDeliveredDate"];
                    DateTime? projectStartDate = dr["ProjectStartDate"].ToString() == "" ? null : (DateTime?)dr["ProjectStartDate"];
                    DateTime? projectSubmitDate = dr["ProjectSubmitDate"].ToString() == "" ? null : (DateTime?)dr["ProjectSubmitDate"];
                    DateTime? projectStartTime = dr["ProjectStartTime"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(dr["ProjectStartTime"].ToString());
                    DateTime? projectEndTime = dr["ProjectEndTime"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(dr["ProjectEndTime"].ToString());


                    ProjectInfo tempProjectInfo = new ProjectInfo(int.Parse(dr["Id"].ToString()), dr["ProjectName"].ToString(),
                        dr["ProjectDescription"].ToString(), int.Parse(dr["ProjectStatusId"].ToString()), dr["ProjectClientCompany"].ToString(),
                       int.Parse(dr["ProjectTypeId"].ToString()), int.Parse(dr["ProjectPriorityId"].ToString()), dr["ProjectSearchingKeywords"].ToString(),
                        dr["ProjectPath"].ToString(), dr["ProjectCustomerId"].ToString(), dr["ProjectCountryCode"].ToString(),
                        double.Parse(dr["ProjectEstimatedBudget"].ToString()), double.Parse(dr["ProjectTotalAmountSpent"].ToString()), int.Parse(dr["ProjectEstimatedDuration"].ToString()),
                        projectReceivedDate, projectDeliveredDate, projectStartDate,
                        projectSubmitDate, projectStartTime, projectEndTime,
                        (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn,dr["UserInfoUserName"].ToString());
                    project_Country_Status_DetailsForView.ProjectInfoData = tempProjectInfo;
                    project_Country_Status_DetailsForView.ProjectCountryName = dr["CountryName"].ToString();
                    project_Country_Status_DetailsForView.ProjectTypeName = dr["ProjectTypeName"].ToString();
                    project_Country_Status_DetailsForView.ProjectStatusName = dr["ProjectStatusName"].ToString();
                    project_Country_Status_DetailsForView.ProjectPriorityName = dr["ProjectPriorityName"].ToString();

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }
            return project_Country_Status_DetailsForView;
        }
        public string[] DeleteProjectInfoData(int projectInfoId, string userName, string deletedBy)
        {
           // string tableName = "PI_" + userName + "_ProjectInfo";
            string tableName = "ProjectInfo";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", projectInfoId);
                SqlParameter p2 = new SqlParameter("deletedBy", deletedBy);
                SqlParameter p3 = new SqlParameter("deletedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "Project with Id " + projectInfoId + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Project  with Id " + projectInfoId + " does not deleted successfully.";
                result[1] = "fail";
                result[2] = "Deletion Failed !";
                con.Close();
            }

            return result;

        }
        public int TotalCancelProjectsCount(string userName)
        {
           // string projectTableName = "PI_" + userName + "_ProjectInfo";
           // string projectStatusTableName = "PS_" + userName + "_ProjectStatus";
           string projectTableName = "ProjectInfo";
            string projectStatusTableName = "ProjectStatus";
            int count = 0;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Count(Id) from " + projectTableName + " where " + projectTableName + ".IsDeleted=0 and " + projectTableName + ".ProjectStatusId in (select Id" +
                    " from " + projectStatusTableName + " where UPPER(ProjectStatusName) like '%CANCEL%' and "+projectStatusTableName+ ".UserInfoUserName=@UserInfoUserName)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    count = int.Parse(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return count;
        }
        public int TotalProjectsCount(string userName)
        {
           // string projectTableName = "PI_" + userName + "_ProjectInfo";
            string projectTableName = "ProjectInfo";
            int count = 0;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Count(Id) from " + projectTableName + " where " + projectTableName + ".IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    count = int.Parse(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return count;
        }
        public List<Project_Info_Status_Priority_ForDashboard> GetAllRuningProjects(string userName)
        {
            List<Project_Info_Status_Priority_ForDashboard> project_Info_Status_Priority_ForDashboard = new List<Project_Info_Status_Priority_ForDashboard>();
            //string projectInfoTableName = "PI_" + userName + "_ProjectInfo";
            //string projectStatusTableName = "PS_" + userName + "_ProjectStatus";
            //string projectPriorityTableName = "PP_" + userName + "_ProjectPriority";
           string projectInfoTableName = "ProjectInfo";
            string projectStatusTableName = "ProjectStatus";
            string projectPriorityTableName = "ProjectPriority";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {


                string qry = "SELECT projectinfo.Id,projectinfo.ProjectName,projectinfo.ProjectCustomerId,projectinfo.ProjectEstimatedBudget"
                              + " ,projectinfo.ProjectDeliveredDate, projectinfo.ProjectEndTime,projectstatus.ProjectStatusName,projectstatus.ProjectStatusBackGroundColor"
                              + " ,projectstatus.ProjectStatusTextColor,projectpriority.ProjectPriorityName,projectpriority.ProjectPriorityBackGroundColor"
                              + " , projectpriority.ProjectPriorityTextColor"
                              + " FROM "+projectInfoTableName+" as projectinfo ,"+projectStatusTableName+" as projectstatus ,"+projectPriorityTableName+" as projectpriority"
                              + " where projectpriority.Id = projectInfo.ProjectPriorityId and projectStatus.Id = projectInfo.ProjectStatusId and projectStatus.ProjectStatusShowInList = 'true'  and projectInfo.UserInfoUserName=@UserInfoUserName "
                              + " order by projectinfo.ProjectDeliveredDate asc, projectpriority.ProjectPriorityPoints desc";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? projectDeliveredDate = dr["ProjectDeliveredDate"].ToString() == "" ? null : (DateTime?)dr["ProjectDeliveredDate"];
                    DateTime? projectEndTime = dr["ProjectEndTime"].ToString() == "" ? null : (DateTime?)Convert.ToDateTime(dr["ProjectEndTime"].ToString());

                    Project_Info_Status_Priority_ForDashboard tempProject_Info_Status_Priority_ForDashboard = new Project_Info_Status_Priority_ForDashboard(int.Parse(dr["Id"].ToString())
                        ,dr["ProjectName"].ToString(), dr["ProjectCustomerId"].ToString(),double.Parse(dr["ProjectEstimatedBudget"].ToString()), 
                        projectDeliveredDate,projectEndTime, dr["ProjectStatusName"].ToString(), dr["ProjectStatusBackGroundColor"].ToString(), dr["ProjectStatusTextColor"].ToString(),
                        dr["ProjectPriorityName"].ToString(), dr["ProjectPriorityBackGroundColor"].ToString(), dr["ProjectPriorityTextColor"].ToString());
                    project_Info_Status_Priority_ForDashboard.Add(tempProject_Info_Status_Priority_ForDashboard);

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();

            }

            return project_Info_Status_Priority_ForDashboard;
        }


        public List<CustomersProjectsMapCount> GetProjectsCountsForMap(string userName)
        {
            List<CustomersProjectsMapCount> mapCounts = new List<CustomersProjectsMapCount>();
            //string tableName = "PCMC_" + userName + "_Country_MapCount";
            string tableName = "User_Country_MapCount";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {


                string qry = "Select  Country.CountryCode, CountryName,ProjectsCount from " + tableName + ",Country where ProjectsCount > 0 and " + tableName + ".CountryCode=Country.CountryCode and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CustomersProjectsMapCount customersProjectsMapCount = new CustomersProjectsMapCount(dr["CountryCode"].ToString(), dr["CountryName"].ToString(),0, int.Parse(dr["ProjectsCount"].ToString()));
                    mapCounts.Add(customersProjectsMapCount);

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();

            }

            return mapCounts;
        }

        public string[] InsertProjectFilesDetailData(ProjectFilesDetail projectFilesDetail, string userName, string addedBy)
        {
            // string tableName = "PI_" + userName + "_ProjectInfo";
            string tableName = "ProjectFilesDetail";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "insert into " + tableName + " (Title,FileName,FileSize,FilePath,ProjectId,AddedOn, AddedBy) values" +
                    "(@Title,@FileName,@FileSize,@FilePath,@ProjectId,@AddedOn,@AddedBy)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Title", projectFilesDetail.Title);
                SqlParameter p2 = new SqlParameter("FileName", projectFilesDetail.FileName);
                SqlParameter p3 = new SqlParameter("FileSize", projectFilesDetail.FileSize);
                SqlParameter p4 = new SqlParameter("FilePath", projectFilesDetail.FilePath);
                SqlParameter p5 = new SqlParameter("ProjectId", projectFilesDetail.ProjectId);
                SqlParameter p6 = new SqlParameter("addedBy", addedBy);
                SqlParameter p7 = new SqlParameter("addedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);

                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "Project File " + projectFilesDetail.FileName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                }
                else
                {
                    result[0] = "Project File " + projectFilesDetail.FileName + " does not added successfully.";
                    result[1] = "fail";
                    result[2] = "Insertion Failed !";
                }
                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Unfortunately Some thing went Wrong.";
                result[1] = "fail";
                result[2] = "Unable to Insertion Project File !";
                con.Close();
            }

            return result;

        }

        public List<ProjectFilesDetail> GetProjectFileDetailsData(int projectId)
        {
            List<ProjectFilesDetail> projectFilesDetail = new List<ProjectFilesDetail>();
            //string tableName = "PCMC_" + userName + "_Country_MapCount";
            string tableName = "ProjectFilesDetail";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {


                string qry = "Select * from " + tableName + " where  ProjectId=@ProjectId and IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("ProjectId", projectId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    ProjectFilesDetail tempProjectFileDetails = new ProjectFilesDetail(int.Parse(dr["Id"].ToString())
                        , dr["Title"].ToString(), dr["FileName"].ToString(), dr["FileSize"].ToString(), dr["FilePath"].ToString(),
                        projectId, bool.Parse(dr["IsDeleted"].ToString()), dr["DeletedBy"].ToString(),
                        deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);

                    projectFilesDetail.Add(tempProjectFileDetails);

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();

            } 

            return projectFilesDetail;
        }

        public ProjectFilesDetail GetProjectFileDetailsDataById(int id)
        {
            ProjectFilesDetail projectFilesDetail = null;
            //string tableName = "PCMC_" + userName + "_Country_MapCount";
            string tableName = "ProjectFilesDetail";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {


                string qry = "Select * from " + tableName + " where  Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", id);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                     projectFilesDetail = new ProjectFilesDetail(int.Parse(dr["Id"].ToString())
                        , dr["Title"].ToString(), dr["FileName"].ToString(), dr["FileSize"].ToString(), dr["FilePath"].ToString(),
                        int.Parse(dr["ProjectId"].ToString()), bool.Parse(dr["IsDeleted"].ToString()), dr["DeletedBy"].ToString(),
                        deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);

                 

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();

            }

            return projectFilesDetail;
        }

        public string[] DeleteProjectFileDetailData(int projectFileId, string userName, string deletedBy)
        {
            // string tableName = "PI_" + userName + "_ProjectInfo";
            string tableName = "ProjectFilesDetail";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", projectFileId);
                SqlParameter p2 = new SqlParameter("deletedBy", deletedBy);
                SqlParameter p3 = new SqlParameter("deletedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "Project File  with Id " + projectFileId + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Project File  with Id " + projectFileId + " does not deleted successfully.";
                result[1] = "fail";
                result[2] = "Deletion Failed !";
                con.Close();
            }

            return result;

        }



    }
}