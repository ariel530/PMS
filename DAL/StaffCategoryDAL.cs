using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class StaffCategoryDAL
    {
        public string[] InsertStaffCategoryData(string staffCategoryName, string staffCategoryDescription, string addedBy, int companyId)
        {
            //string tableName = "PT_" + userName + "_StaffCategory";
            string tableName = "StaffCategory";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {

                string qry = "insert into " + tableName + " (StaffCategoryName,StaffCategoryDescription,AddedBy,AddedOn,CompanyId) values(@StaffCategoryName,@StaffCategoryDescription,@addedBy,@addedOn,@CompanyId)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("StaffCategoryName", staffCategoryName);
                SqlParameter p2 = new SqlParameter("StaffCategoryDescription", staffCategoryDescription);
                SqlParameter p3 = new SqlParameter("addedBy", addedBy);
                SqlParameter p4 = new SqlParameter("addedOn", DateTime.Now);
                SqlParameter p5 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "StaffCategory " + staffCategoryName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "StaffCategory " + staffCategoryName + " does not added successfully.";
                result[1] = "fail";
                result[2] = "Insertion Failed !";
                con.Close();
            }

            return result;

        }
        public string[] UpdateStaffCategoryData(string staffCategoryName, string staffCategoryDescription, int id, string modifiedBy, string userName)
        {
            // string tableName = "PT_" + userName + "_StaffCategory";
            string tableName = "StaffCategory";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set StaffCategoryName =@StaffCategoryName,StaffCategoryDescription =@StaffCategoryDescription,LastModifiedOn=@lastModifiedOn ,LastModifiedBy = @lastModifiedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", id);
                SqlParameter p2 = new SqlParameter("StaffCategoryDescription", staffCategoryDescription);
                SqlParameter p3 = new SqlParameter("StaffCategoryName", staffCategoryName);
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
                    result[0] = "StaffCategory " + staffCategoryName + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "StaffCategory " + staffCategoryName + " does not updated successfully.";
                result[1] = "fail";
                result[2] = "Updation Failed !";
                con.Close();
            }

            return result;

        }
        public string[] DeleteStaffCategoryData(int userTypeId, string deletedBy, string userName)
        {
            // string tableName = "PT_" + userName + "_StaffCategory";
            string tableName = "StaffCategory";
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
                    result[0] = "StaffCategory with Id " + userTypeId + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "StaffCategory  with Id " + userTypeId + " does not deleted successfully.";
                result[1] = "fail";
                result[2] = "Deletion Failed !";
                con.Close();
            }

            return result;

        }
        public StaffCategory GetStaffCategoryDataByStaffCategoryCode(int userTypeId, string userName)
        {
            // string tableName = "PT_" + userName + "_StaffCategory";
            string tableName = "StaffCategory";
            StaffCategory staffCategory = null;
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

                    staffCategory = new StaffCategory(int.Parse(dr["Id"].ToString()), dr["StaffCategoryName"].ToString(),
                     dr["StaffCategoryDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn,  int.Parse(dr["CompanyId"].ToString()));

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffCategory;

        }
        public List<StaffCategory> GetStaffCategoryDataListForDropDown(string userName)
        {
            //  string tableName = "PT_" + userName + "_StaffCategory";
            string tableName = "StaffCategory";
            List<StaffCategory> staffCategory = new List<StaffCategory>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,StaffCategoryName from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    StaffCategory tempStaffCategory = new StaffCategory(int.Parse(dr["Id"].ToString()), dr["StaffCategoryName"].ToString());
                    staffCategory.Add(tempStaffCategory);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffCategory;
        }
        public List<StaffCategory> GetStaffCategoryDataListForDropDown(int companyId)
        {
            //  string tableName = "PT_" + userName + "_StaffCategory";
            string tableName = "StaffCategory";
            List<StaffCategory> staffCategory = new List<StaffCategory>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,StaffCategoryName from " + tableName + " where IsDeleted=0 and CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    StaffCategory tempStaffCategory = new StaffCategory(int.Parse(dr["Id"].ToString()), dr["StaffCategoryName"].ToString());
                    staffCategory.Add(tempStaffCategory);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffCategory;
        }
        public List<StaffCategory> GetStaffCategoryDataListForDropDownAllIncludedDeleted(string userName)
        {
            //string tableName = "PT_" + userName + "_StaffCategory";
            string tableName = "StaffCategory";
            List<StaffCategory> staffCategory = new List<StaffCategory>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,StaffCategoryName from " + tableName + " where UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    StaffCategory tempStaffCategory = new StaffCategory(int.Parse(dr["Id"].ToString()), dr["StaffCategoryName"].ToString());
                    staffCategory.Add(tempStaffCategory);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffCategory;

        }
        public List<StaffCategory> GetStaffCategoryDataListForDropDownAllIncludedDeleted(int companyId)
        {
            //string tableName = "PT_" + userName + "_StaffCategory";
            string tableName = "StaffCategory";
            List<StaffCategory> staffCategory = new List<StaffCategory>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,StaffCategoryName from " + tableName + " where CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    StaffCategory tempStaffCategory = new StaffCategory(int.Parse(dr["Id"].ToString()), dr["StaffCategoryName"].ToString());
                    staffCategory.Add(tempStaffCategory);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffCategory;

        }
        public List<StaffCategory> GetStaffCategoryDataList(string userName)
        {
            // string tableName = "PT_" + userName + "_StaffCategory";
            string tableName = "StaffCategory";
            List<StaffCategory> staffCategory = new List<StaffCategory>();
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

                    StaffCategory tempStaffCategory = new StaffCategory(int.Parse(dr["Id"].ToString()), dr["StaffCategoryName"].ToString(),
                        dr["StaffCategoryDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, int.Parse(dr["CompanyId"].ToString()));
                    staffCategory.Add(tempStaffCategory);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffCategory;

        }
        public List<StaffCategory> GetStaffCategoryDataList(int companyId)
        {
            // string tableName = "PT_" + userName + "_StaffCategory";
            string tableName = "StaffCategory";
            List<StaffCategory> staffCategory = new List<StaffCategory>();
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

                    StaffCategory tempStaffCategory = new StaffCategory(int.Parse(dr["Id"].ToString()), dr["StaffCategoryName"].ToString(),
                        dr["StaffCategoryDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn,  int.Parse(dr["CompanyId"].ToString()));
                    staffCategory.Add(tempStaffCategory);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffCategory;

        }

    }
}