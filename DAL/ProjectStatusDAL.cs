using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    
    public class ProjectStatusDAL
    {
        public string[] InsertProjectStatusData(string projectStatusName, string projectStatusBackGoroundColor,string projectStatusTextColor , string projectStatusDescription ,bool projectStatusShowInList ,string addedBy,string userName)
        {
           // string tableName = "PS_" + userName + "_ProjectStatus"; 
            string tableName = "ProjectStatus"; 
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "insert into " + tableName + " (ProjectStatusName,ProjectStatusBackGroundColor,ProjectStatusTextColor,ProjectStatusDescription,ProjectStatusShowInList ,AddedBy,AddedOn,UserInfoUserName) values(@ProjectStatusName,@ProjectStatusBackGroundColor,@ProjectStatusTextColor,@ProjectStatusDescription, @ProjectStatusShowInList,@addedBy,@addedOn,@UserInfoUserName)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("ProjectStatusName", projectStatusName);
                SqlParameter p2 = new SqlParameter("ProjectStatusBackGroundColor", projectStatusBackGoroundColor);
                SqlParameter p3 = new SqlParameter("ProjectStatusTextColor", projectStatusTextColor);
                SqlParameter p4 = new SqlParameter("ProjectStatusShowInList", projectStatusShowInList);
                SqlParameter p5 = new SqlParameter("addedBy", addedBy);
                SqlParameter p6 = new SqlParameter("addedOn", DateTime.Now);
                SqlParameter p7 = new SqlParameter("ProjectStatusDescription", projectStatusDescription);
                SqlParameter p8 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "ProjectStatus " + projectStatusName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                result[0] = "ProjectStatus " + projectStatusName + " does not added successfully.";
                result[1] = "fail";
                result[2] = "Insertion Failed !";
                con.Close();
            }
            return result;

        }



        public string[] UpdateProjectStatusData(string projectStatusName, string projectStatusBackGoroundColor, string projectStatusTextColor,string projectStatusDescription, bool projectStatusShowInList, int projectStatusId , string modifiedBy, string userName)
        {
            //string tableName = "PS_" + userName + "_ProjectStatus";
            string tableName = "ProjectStatus";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set ProjectStatusName =@ProjectStatusName,ProjectStatusBackGroundColor =@ProjectStatusBackGroundColor,ProjectStatusTextColor =@ProjectStatusTextColor, ProjectStatusDescription=@projectStatusDescription,ProjectStatusShowInList=@ProjectStatusShowInList ,LastModifiedOn=@LastModifiedOn ,LastModifiedBy = @LastModifiedBy where Id=@ProjectStatusId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("ProjectStatusName", projectStatusName);
                SqlParameter p2 = new SqlParameter("ProjectStatusBackGroundColor", projectStatusBackGoroundColor);
                SqlParameter p3 = new SqlParameter("ProjectStatusTextColor", projectStatusTextColor);
                SqlParameter p4 = new SqlParameter("ProjectStatusId", projectStatusId);
                SqlParameter p5 = new SqlParameter("LastModifiedBy", modifiedBy);
                SqlParameter p6 = new SqlParameter("ProjectStatusDescription", projectStatusDescription);
                SqlParameter p7 = new SqlParameter("ProjectStatusShowInList", projectStatusShowInList);
                SqlParameter p8 = new SqlParameter("LastModifiedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "ProjectStatus  with Id " + projectStatusId + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                result[0] = "ProjectStatus  with Id " + projectStatusId + " does not updated successfully.";
                result[1] = "fail";
                result[2] = "Updation Failed !";
                con.Close();
          
            }
          
            return result;
        }



        public string[] DeleteProjectStatusData(int  projectStatusId, string deletedBy, string userName)
        {
           // string tableName = "PS_" + userName + "_ProjectStatus";
            string tableName = "ProjectStatus";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where Id=@ProjectStatusId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("ProjectStatusId", projectStatusId);
                SqlParameter p2 = new SqlParameter("deletedBy", deletedBy);
                SqlParameter p3 = new SqlParameter("deletedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "ProjectStatus with Id " + projectStatusId + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "ProjectStatus  with id " + projectStatusId + "does not deleted successfully.";
                result[1] = "Deletion Failed !";
                con.Close();
            }
            

            return result;

        }


        public ProjectStatus GetProjectStatusDataByProjectStatusId(int  projectStatusId, string userName)
        {
            //string tableName = "PS_" + userName + "_ProjectStatus";
            string tableName ="ProjectStatus";
            ProjectStatus ProjectStatus = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where Id=@ProjectStatusId and IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("ProjectStatusId", projectStatusId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    ProjectStatus = new ProjectStatus(int.Parse(dr["Id"].ToString()), dr["ProjectStatusName"].ToString(),dr["ProjectStatusBackGroundColor"].ToString(), dr["ProjectStatusTextColor"].ToString(), dr["ProjectStatusDescription"].ToString(), (bool)dr["ProjectStatusShowInList"],(bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn,dr["UserInfoUserName"].ToString());

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return ProjectStatus;

        }



        public List<ProjectStatus> GetProjectStatusDataList( string userName)
        {
         //   string tableName = "PS_" + userName + "_ProjectStatus";
            string tableName = "ProjectStatus";
            List<ProjectStatus> ProjectStatus = new List<ProjectStatus>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from "+ tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                   ProjectStatus tempProjectStatus = new ProjectStatus(int.Parse(dr["Id"].ToString()), dr["ProjectStatusName"].ToString(), dr["ProjectStatusBackGroundColor"].ToString(), dr["ProjectStatusTextColor"].ToString(), dr["ProjectStatusDescription"].ToString(), (bool)dr["ProjectStatusShowInList"],(bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn,dr["UserInfoUserName"].ToString());
                    ProjectStatus.Add(tempProjectStatus);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return ProjectStatus;

        }
        public List<ProjectStatus> GetProjectStatusDataListForDropDown(string userName)
        {
           // string tableName = "PS_" + userName + "_ProjectStatus";
            string tableName = "ProjectStatus";
            List<ProjectStatus> ProjectStatus = new List<ProjectStatus>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,ProjectStatusName from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ProjectStatus tempProjectStatus = new ProjectStatus(int.Parse(dr["Id"].ToString()), dr["ProjectStatusName"].ToString());
                    ProjectStatus.Add(tempProjectStatus);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return ProjectStatus;

        }
    }
}