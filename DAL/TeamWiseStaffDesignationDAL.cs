using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class TeamWiseStaffDesignationDAL
    {
        public string[] InsertTeamWiseStaffDesignationData(string teamWiseStaffDesignationName, string teamWiseStaffDesignationDescription, int teamWiseStaffDesignationRank, string addedBy, int companyId)
        {
            //string tableName = "PT_" + userName + "_TeamWiseStaffDesignation";
            string tableName = "TeamWiseStaffDesignation";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {

                string qry = "insert into " + tableName + " (TeamWiseStaffDesignationName,TeamWiseStaffDesignationDescription,TeamWiseStaffDesignationRank,AddedBy,AddedOn,CompanyId) values(@TeamWiseStaffDesignationName,@TeamWiseStaffDesignationDescription,@TeamWiseStaffDesignationRank,@addedBy,@addedOn,@CompanyId)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("TeamWiseStaffDesignationName", teamWiseStaffDesignationName);
                SqlParameter p2 = new SqlParameter("TeamWiseStaffDesignationDescription", teamWiseStaffDesignationDescription);
                SqlParameter p3 = new SqlParameter("TeamWiseStaffDesignationRank", teamWiseStaffDesignationRank);
                SqlParameter p4 = new SqlParameter("addedBy", addedBy);
                SqlParameter p5 = new SqlParameter("addedOn", DateTime.Now);
                SqlParameter p6 = new SqlParameter("CompanyId", companyId);
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
                    result[0] = "TeamWiseStaffDesignation " + teamWiseStaffDesignationName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "TeamWiseStaffDesignation " + teamWiseStaffDesignationName + " does not added successfully.";
                result[1] = "fail";
                result[2] = "Insertion Failed !";
                con.Close();
            }

            return result;

        }
        public string[] UpdateTeamWiseStaffDesignationData(string teamWiseStaffDesignationName, string teamWiseStaffDesignationDescription, int teamWiseStaffDesignationRank, int id, string modifiedBy, string userName)
        {
            // string tableName = "PT_" + userName + "_TeamWiseStaffDesignation";
            string tableName = "TeamWiseStaffDesignation";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set TeamWiseStaffDesignationName =@TeamWiseStaffDesignationName,TeamWiseStaffDesignationDescription =@TeamWiseStaffDesignationDescription ,TeamWiseStaffDesignationRank=@TeamWiseStaffDesignationRank     ,LastModifiedOn=@lastModifiedOn ,LastModifiedBy = @lastModifiedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", id);
                SqlParameter p2 = new SqlParameter("TeamWiseStaffDesignationDescription", teamWiseStaffDesignationDescription);
                SqlParameter p3 = new SqlParameter("TeamWiseStaffDesignationName", teamWiseStaffDesignationName);
                SqlParameter p4 = new SqlParameter("lastModifiedBy", modifiedBy);
                SqlParameter p5 = new SqlParameter("lastModifiedOn", DateTime.Now);
                SqlParameter p6 = new SqlParameter("TeamWiseStaffDesignationRank", teamWiseStaffDesignationRank);
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
                    result[0] = "TeamWiseStaffDesignation " + teamWiseStaffDesignationName + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "TeamWiseStaffDesignation " + teamWiseStaffDesignationName + " does not updated successfully.";
                result[1] = "fail";
                result[2] = "Updation Failed !";
                con.Close();
            }

            return result;

        }
        public string[] DeleteTeamWiseStaffDesignationData(int userTypeId, string deletedBy, string userName)
        {
            // string tableName = "PT_" + userName + "_TeamWiseStaffDesignation";
            string tableName = "TeamWiseStaffDesignation";
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
                    result[0] = "TeamWiseStaffDesignation with Id " + userTypeId + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "TeamWiseStaffDesignation  with Id " + userTypeId + " does not deleted successfully.";
                result[1] = "fail";
                result[2] = "Deletion Failed !";
                con.Close();
            }

            return result;

        }
        public TeamWiseStaffDesignation GetTeamWiseStaffDesignationDataByTeamWiseStaffDesignationCode(int userTypeId, string userName)
        {
            // string tableName = "PT_" + userName + "_TeamWiseStaffDesignation";
            string tableName = "TeamWiseStaffDesignation";
            TeamWiseStaffDesignation teamWiseStaffDesignation = null;
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

                    teamWiseStaffDesignation = new TeamWiseStaffDesignation(int.Parse(dr["Id"].ToString()), dr["TeamWiseStaffDesignationName"].ToString(),
             int.Parse(dr["TeamWiseStaffDesignationRank"].ToString()), dr["TeamWiseStaffDesignationDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, int.Parse(dr["CompanyId"].ToString()));

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return teamWiseStaffDesignation;

        }
        public List<TeamWiseStaffDesignation> GetTeamWiseStaffDesignationDataListForDropDown(string userName)
        {
            //  string tableName = "PT_" + userName + "_TeamWiseStaffDesignation";
            string tableName = "TeamWiseStaffDesignation";
            List<TeamWiseStaffDesignation> teamWiseStaffDesignation = new List<TeamWiseStaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,TeamWiseStaffDesignationName from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    TeamWiseStaffDesignation tempTeamWiseStaffDesignation = new TeamWiseStaffDesignation(int.Parse(dr["Id"].ToString()), dr["TeamWiseStaffDesignationName"].ToString());
                    teamWiseStaffDesignation.Add(tempTeamWiseStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return teamWiseStaffDesignation;
        }
        public List<TeamWiseStaffDesignation> GetTeamWiseStaffDesignationDataListForDropDown(int companyId)
        {
            //  string tableName = "PT_" + userName + "_TeamWiseStaffDesignation";
            string tableName = "TeamWiseStaffDesignation";
            List<TeamWiseStaffDesignation> teamWiseStaffDesignation = new List<TeamWiseStaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,TeamWiseStaffDesignationName from " + tableName + " where IsDeleted=0 and CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    TeamWiseStaffDesignation tempTeamWiseStaffDesignation = new TeamWiseStaffDesignation(int.Parse(dr["Id"].ToString()), dr["TeamWiseStaffDesignationName"].ToString());
                    teamWiseStaffDesignation.Add(tempTeamWiseStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return teamWiseStaffDesignation;
        }
        public List<TeamWiseStaffDesignation> GetTeamWiseStaffDesignationDataListForDropDownAllIncludedDeleted(string userName)
        {
            //string tableName = "PT_" + userName + "_TeamWiseStaffDesignation";
            string tableName = "TeamWiseStaffDesignation";
            List<TeamWiseStaffDesignation> teamWiseStaffDesignation = new List<TeamWiseStaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,TeamWiseStaffDesignationName from " + tableName + " where UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    TeamWiseStaffDesignation tempTeamWiseStaffDesignation = new TeamWiseStaffDesignation(int.Parse(dr["Id"].ToString()), dr["TeamWiseStaffDesignationName"].ToString());
                    teamWiseStaffDesignation.Add(tempTeamWiseStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return teamWiseStaffDesignation;

        }
        public List<TeamWiseStaffDesignation> GetTeamWiseStaffDesignationDataListForDropDownAllIncludedDeleted(int companyId)
        {
            //string tableName = "PT_" + userName + "_TeamWiseStaffDesignation";
            string tableName = "TeamWiseStaffDesignation";
            List<TeamWiseStaffDesignation> teamWiseStaffDesignation = new List<TeamWiseStaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,TeamWiseStaffDesignationName from " + tableName + " where CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    TeamWiseStaffDesignation tempTeamWiseStaffDesignation = new TeamWiseStaffDesignation(int.Parse(dr["Id"].ToString()), dr["TeamWiseStaffDesignationName"].ToString());
                    teamWiseStaffDesignation.Add(tempTeamWiseStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return teamWiseStaffDesignation;

        }
        public List<TeamWiseStaffDesignation> GetTeamWiseStaffDesignationDataList(string userName)
        {
            // string tableName = "PT_" + userName + "_TeamWiseStaffDesignation";
            string tableName = "TeamWiseStaffDesignation";
            List<TeamWiseStaffDesignation> teamWiseStaffDesignation = new List<TeamWiseStaffDesignation>();
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

                    TeamWiseStaffDesignation tempTeamWiseStaffDesignation = new TeamWiseStaffDesignation(int.Parse(dr["Id"].ToString()), dr["TeamWiseStaffDesignationName"].ToString(),
                int.Parse(dr["TeamWiseStaffDesignationRank"].ToString()), dr["TeamWiseStaffDesignationDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, int.Parse(dr["CompanyId"].ToString()));
                    teamWiseStaffDesignation.Add(tempTeamWiseStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return teamWiseStaffDesignation;

        }
        public List<TeamWiseStaffDesignation> GetTeamWiseStaffDesignationDataList(int companyId)
        {
            // string tableName = "PT_" + userName + "_TeamWiseStaffDesignation";
            string tableName = "TeamWiseStaffDesignation";
            List<TeamWiseStaffDesignation> teamWiseStaffDesignation = new List<TeamWiseStaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where IsDeleted=0 and CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    TeamWiseStaffDesignation tempTeamWiseStaffDesignation = new TeamWiseStaffDesignation(int.Parse(dr["Id"].ToString()), dr["TeamWiseStaffDesignationName"].ToString(),
                  int.Parse(dr["TeamWiseStaffDesignationRank"].ToString()), dr["TeamWiseStaffDesignationDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, int.Parse(dr["CompanyId"].ToString()));
                    teamWiseStaffDesignation.Add(tempTeamWiseStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return teamWiseStaffDesignation;

        }

    }
}