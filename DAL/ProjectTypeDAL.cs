using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class ProjectTypeDAL
    {
        public string[] InsertProjectTypeData(string projectTypeName, string projectTypeDescription,  string addedBy, string userName)
        {
            //string tableName = "PT_" + userName + "_ProjectType";
            string tableName ="ProjectType";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {

                string qry = "insert into " + tableName + " (ProjectTypeName,ProjectTypeDescription,AddedBy,AddedOn,UserInfoUserName) values(@ProjectTypeName,@ProjectTypeDescription,@addedBy,@addedOn,@UserInfoUserName)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("ProjectTypeName", projectTypeName);
                SqlParameter p2 = new SqlParameter("ProjectTypeDescription", projectTypeDescription);
                SqlParameter p3 = new SqlParameter("addedBy", addedBy);
                SqlParameter p4 = new SqlParameter("addedOn", DateTime.Now);
                SqlParameter p5 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "ProjectType " + projectTypeName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "ProjectType " + projectTypeName + " does not added successfully.";
                result[1] = "fail";
                result[2] = "Insertion Failed !";
                con.Close();
            }

            return result;

        }
        public string[] UpdateProjectTypeData(string projectTypeName, string projectTypeDescription,  int id, string modifiedBy, string userName)
        {
           // string tableName = "PT_" + userName + "_ProjectType";
            string tableName = "ProjectType";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set ProjectTypeName =@ProjectTypeName,ProjectTypeDescription =@ProjectTypeDescription,LastModifiedOn=@lastModifiedOn ,LastModifiedBy = @lastModifiedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", id);
                SqlParameter p2 = new SqlParameter("ProjectTypeDescription", projectTypeDescription);
                SqlParameter p3 = new SqlParameter("ProjectTypeName", projectTypeName);
                SqlParameter p4 = new SqlParameter("lastModifiedBy", modifiedBy);
                SqlParameter p5 = new SqlParameter("lastModifiedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "ProjectType " + projectTypeName + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "ProjectType " + projectTypeName + " does not updated successfully.";
                result[1] = "fail";
                result[2] = "Updation Failed !";
                con.Close();
            }

            return result;

        }
        public string[] DeleteProjectTypeData(int userTypeId, string deletedBy, string userName)
        {
           // string tableName = "PT_" + userName + "_ProjectType";
            string tableName = "ProjectType";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", userTypeId);
                SqlParameter p2 = new SqlParameter("deletedBy", deletedBy);
                SqlParameter p3 = new SqlParameter("deletedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "ProjectType with Id " + userTypeId + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "ProjectType  with Id " + userTypeId + " does not deleted successfully.";
                result[1] = "fail";
                result[2] = "Deletion Failed !";
                con.Close();
            }

            return result;

        }
        public ProjectType GetProjectTypeDataByProjectTypeCode(int userTypeId, string userName)
        {
           // string tableName = "PT_" + userName + "_ProjectType";
            string tableName = "ProjectType";
            ProjectType projectType = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where Id=@Id and IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", userTypeId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    projectType = new ProjectType(int.Parse(dr["Id"].ToString()), dr["ProjectTypeName"].ToString(),
                     dr["ProjectTypeDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn,dr["UserInfoUserName"].ToString());

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return projectType;

        }
        public List<ProjectType> GetProjectTypeDataListForDropDown(string userName)
        {
          //  string tableName = "PT_" + userName + "_ProjectType";
            string tableName = "ProjectType";
            List<ProjectType> projectType = new List<ProjectType>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,ProjectTypeName from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    ProjectType tempProjectType = new ProjectType(int.Parse(dr["Id"].ToString()), dr["ProjectTypeName"].ToString());
                    projectType.Add(tempProjectType);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return projectType;
        }
        public List<ProjectType> GetProjectTypeDataListForDropDownAllIncludedDeleted(string userName)
        {
            //string tableName = "PT_" + userName + "_ProjectType";
            string tableName = "ProjectType";
            List<ProjectType> projectType = new List<ProjectType>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,ProjectTypeName from " + tableName + " where UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    ProjectType tempProjectType = new ProjectType(int.Parse(dr["Id"].ToString()), dr["ProjectTypeName"].ToString());
                    projectType.Add(tempProjectType);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return projectType;

        }
        public List<ProjectType> GetProjectTypeDataList(string userName)
        {
           // string tableName = "PT_" + userName + "_ProjectType";
            string tableName = "ProjectType";
            List<ProjectType> projectType = new List<ProjectType>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName"; 
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

                    ProjectType tempProjectType = new ProjectType(int.Parse(dr["Id"].ToString()), dr["ProjectTypeName"].ToString(),
                        dr["ProjectTypeDescription"].ToString(),  (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn , dr["UserInfoUserName"].ToString());
                    projectType.Add(tempProjectType);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return projectType;

        }



    }
}