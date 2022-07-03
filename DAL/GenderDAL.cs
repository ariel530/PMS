using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class GenderDAL
    {
        public string[] InsertGenderData(string genderName, string genderDescription, string addedBy, int companyId)
        {
            //string tableName = "PT_" + userName + "_Gender";
            string tableName = "Gender";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {

                string qry = "insert into " + tableName + " (GenderName,GenderDescription,AddedBy,AddedOn,CompanyId) values(@GenderName,@GenderDescription,@addedBy,@addedOn,@CompanyId)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("GenderName", genderName);
                SqlParameter p2 = new SqlParameter("GenderDescription", genderDescription);
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
                    result[0] = "Gender " + genderName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Gender " + genderName + " does not added successfully.";
                result[1] = "fail";
                result[2] = "Insertion Failed !";
                con.Close();
            }

            return result;

        }
        public string[] UpdateGenderData(string genderName, string genderDescription, int id, string modifiedBy, string userName)
        {
            // string tableName = "PT_" + userName + "_Gender";
            string tableName = "Gender";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set GenderName =@GenderName,GenderDescription =@GenderDescription,LastModifiedOn=@lastModifiedOn ,LastModifiedBy = @lastModifiedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", id);
                SqlParameter p2 = new SqlParameter("GenderDescription", genderDescription);
                SqlParameter p3 = new SqlParameter("GenderName", genderName);
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
                    result[0] = "Gender " + genderName + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Gender " + genderName + " does not updated successfully.";
                result[1] = "fail";
                result[2] = "Updation Failed !";
                con.Close();
            }

            return result;

        }
        public string[] DeleteGenderData(int userTypeId, string deletedBy, string userName)
        {
            // string tableName = "PT_" + userName + "_Gender";
            string tableName = "Gender";
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
                    result[0] = "Gender with Id " + userTypeId + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Gender  with Id " + userTypeId + " does not deleted successfully.";
                result[1] = "fail";
                result[2] = "Deletion Failed !";
                con.Close();
            }

            return result;

        }
        public Gender GetGenderDataByGenderCode(int userTypeId, string userName)
        {
            // string tableName = "PT_" + userName + "_Gender";
            string tableName = "Gender";
            Gender gender = null;
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

                    gender = new Gender(int.Parse(dr["Id"].ToString()), dr["GenderName"].ToString(),
                     dr["GenderDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, int.Parse(dr["CompanyId"].ToString()));

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return gender;

        }
        public List<Gender> GetGenderDataListForDropDown(string userName)
        {
            //  string tableName = "PT_" + userName + "_Gender";
            string tableName = "Gender";
            List<Gender> gender = new List<Gender>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,GenderName from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    Gender tempGender = new Gender(int.Parse(dr["Id"].ToString()), dr["GenderName"].ToString());
                    gender.Add(tempGender);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return gender;
        }
        public List<Gender> GetGenderDataListForDropDown(int companyId)
        {
            //  string tableName = "PT_" + userName + "_Gender";
            string tableName = "Gender";
            List<Gender> gender = new List<Gender>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,GenderName from " + tableName + " where IsDeleted=0 and CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    Gender tempGender = new Gender(int.Parse(dr["Id"].ToString()), dr["GenderName"].ToString());
                    gender.Add(tempGender);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return gender;
        }
        public List<Gender> GetGenderDataListForDropDownAllIncludedDeleted(string userName)
        {
            //string tableName = "PT_" + userName + "_Gender";
            string tableName = "Gender";
            List<Gender> gender = new List<Gender>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,GenderName from " + tableName + " where UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    Gender tempGender = new Gender(int.Parse(dr["Id"].ToString()), dr["GenderName"].ToString());
                    gender.Add(tempGender);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return gender;

        }
        public List<Gender> GetGenderDataListForDropDownAllIncludedDeleted(int companyId)
        {
            //string tableName = "PT_" + userName + "_Gender";
            string tableName = "Gender";
            List<Gender> gender = new List<Gender>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,GenderName from " + tableName + " where CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    Gender tempGender = new Gender(int.Parse(dr["Id"].ToString()), dr["GenderName"].ToString());
                    gender.Add(tempGender);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return gender;

        }
        public List<Gender> GetGenderDataList(string userName)
        {
            // string tableName = "PT_" + userName + "_Gender";
            string tableName = "Gender";
            List<Gender> gender = new List<Gender>();
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

                    Gender tempGender = new Gender(int.Parse(dr["Id"].ToString()), dr["GenderName"].ToString(),
                        dr["GenderDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, int.Parse(dr["CompanyId"].ToString()));
                    gender.Add(tempGender);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return gender;

        }
        public List<Gender> GetGenderDataList(int companyId)
        {
            // string tableName = "PT_" + userName + "_Gender";
            string tableName = "Gender";
            List<Gender> gender = new List<Gender>();
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

                    Gender tempGender = new Gender(int.Parse(dr["Id"].ToString()), dr["GenderName"].ToString(),
                        dr["GenderDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, int.Parse(dr["CompanyId"].ToString()));
                    gender.Add(tempGender);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return gender;

        }

    }
}