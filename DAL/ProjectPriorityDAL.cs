using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class ProjectPriorityDAL
    {
        public string[] InsertProjectPriorityData(string projectPriorityName, string projectPriorityBackGoroundColor, string projectPriorityTextColor, string projectPriorityDescription, int projectPriorityPoints, string addedBy, string userName)
        {
            //string tableName = "PP_" + userName + "_ProjectPriority";
            string tableName = "ProjectPriority";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "insert into " + tableName + " (ProjectPriorityName,ProjectPriorityBackGroundColor,ProjectPriorityTextColor,ProjectPriorityDescription,ProjectPriorityPoints ,AddedBy,AddedOn,UserInfoUserName) values(@ProjectPriorityName,@ProjectPriorityBackGroundColor,@ProjectPriorityTextColor,@ProjectPriorityDescription,@ProjectPriorityPoints, @addedBy,@addedOn,@UserInfoUserName)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("ProjectPriorityName", projectPriorityName);
                SqlParameter p2 = new SqlParameter("ProjectPriorityBackGroundColor", projectPriorityBackGoroundColor);
                SqlParameter p3 = new SqlParameter("ProjectPriorityTextColor", projectPriorityTextColor);
                SqlParameter p4 = new SqlParameter("ProjectPriorityPoints", projectPriorityPoints);
                SqlParameter p5 = new SqlParameter("addedBy", addedBy);
                SqlParameter p6 = new SqlParameter("addedOn", DateTime.Now);
                SqlParameter p7 = new SqlParameter("ProjectPriorityDescription", projectPriorityDescription);
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
                    result[0] = "ProjectPriority " + projectPriorityName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                result[0] = "ProjectPriority " + projectPriorityName + " does not added successfully.";
                result[1] = "fail";
                result[2] = "Insertion Failed !";
                con.Close();
            }
            return result;

        }



        public string[] UpdateProjectPriorityData(string projectPriorityName, string projectPriorityBackGoroundColor, string projectPriorityTextColor, string projectPriorityDescription, int projectPriorityPoints,  int projectPriorityId, string modifiedBy, string userName)
        {
          //  string tableName = "PP_" + userName + "_ProjectPriority";
            string tableName = "ProjectPriority";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set ProjectPriorityName =@ProjectPriorityName,ProjectPriorityBackGroundColor =@ProjectPriorityBackGroundColor,ProjectPriorityTextColor =@ProjectPriorityTextColor, ProjectPriorityDescription=@projectPriorityDescription,ProjectPriorityPoints=@ProjectPriorityPoints ,LastModifiedOn=@LastModifiedOn ,LastModifiedBy = @LastModifiedBy where Id=@ProjectPriorityId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("ProjectPriorityName", projectPriorityName);
                SqlParameter p2 = new SqlParameter("ProjectPriorityBackGroundColor", projectPriorityBackGoroundColor);
                SqlParameter p3 = new SqlParameter("ProjectPriorityTextColor", projectPriorityTextColor);
                SqlParameter p4 = new SqlParameter("ProjectPriorityPoints", projectPriorityPoints);
                SqlParameter p5 = new SqlParameter("ProjectPriorityId", projectPriorityId);
                SqlParameter p6 = new SqlParameter("LastModifiedBy", modifiedBy);
                SqlParameter p7 = new SqlParameter("ProjectPriorityDescription", projectPriorityDescription);
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
                    result[0] = "ProjectPriority  with Id " + projectPriorityId + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                result[0] = "ProjectPriority  with Id " + projectPriorityId + " does not updated successfully.";
                result[1] = "fail";
                result[2] = "Updation Failed !";
                con.Close();

            }

            return result;
        }



        public string[] DeleteProjectPriorityData(int projectPriorityId, string deletedBy, string userName)
        {
          //  string tableName = "PP_" + userName + "_ProjectPriority";
            string tableName = "ProjectPriority";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where Id=@ProjectPriorityId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("ProjectPriorityId", projectPriorityId);
                SqlParameter p2 = new SqlParameter("deletedBy", deletedBy);
                SqlParameter p3 = new SqlParameter("deletedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "ProjectPriority with Id " + projectPriorityId + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "ProjectPriority  with id " + projectPriorityId + "does not deleted successfully.";
                result[1] = "Deletion Failed !";
                con.Close();
            }


            return result;

        }


        public ProjectPriority GetProjectPriorityDataByProjectPriorityId(int projectPriorityId, string userName)
        {
            //string tableName = "PP_" + userName + "_ProjectPriority";
            string tableName = "ProjectPriority";
            ProjectPriority ProjectPriority = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where Id=@ProjectPriorityId and IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("ProjectPriorityId", projectPriorityId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    ProjectPriority = new ProjectPriority(int.Parse(dr["Id"].ToString()), dr["ProjectPriorityName"].ToString(), dr["ProjectPriorityBackGroundColor"].ToString(), dr["ProjectPriorityTextColor"].ToString(), dr["ProjectPriorityDescription"].ToString(), int.Parse(dr["ProjectPriorityPoints"].ToString()), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, dr["UserInfoUserName"].ToString());

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return ProjectPriority;

        }



        public List<ProjectPriority> GetProjectPriorityDataList(string userName)
        {
           // string tableName = "PP_" + userName + "_ProjectPriority";
            string tableName = "ProjectPriority";
            List<ProjectPriority> ProjectPriority = new List<ProjectPriority>();
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

                    ProjectPriority tempProjectPriority = new ProjectPriority(int.Parse(dr["Id"].ToString()), dr["ProjectPriorityName"].ToString(), dr["ProjectPriorityBackGroundColor"].ToString(), dr["ProjectPriorityTextColor"].ToString(), dr["ProjectPriorityDescription"].ToString(), int.Parse(dr["ProjectPriorityPoints"].ToString()), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                    , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn,dr["UserInfoUserName"].ToString());
                    ProjectPriority.Add(tempProjectPriority);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return ProjectPriority;

        }

        public List<ProjectPriority> GetProjectPriorityDataListForDropdown(string userName)
        {
            //string tableName = "PP_" + userName + "_ProjectPriority";
            string tableName = "ProjectPriority";
            List<ProjectPriority> ProjectPriority = new List<ProjectPriority>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,ProjectPriorityName from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   
                    ProjectPriority tempProjectPriority = new ProjectPriority(int.Parse(dr["Id"].ToString()), dr["ProjectPriorityName"].ToString());
                    ProjectPriority.Add(tempProjectPriority);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return ProjectPriority;

        }

    }
}