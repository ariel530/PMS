using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class DailyExpenseTypeDAL
    {

        public string[] InsertDailyExpenseTypeData(string expenseTypeName, string expenseTypeDescription, string addedBy, string userName)
        {
            //  string tableName = "CT_" + userName + "_DailyExpenseType";
            string tableName = "DailyExpenseType";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {

                string qry = "insert into " + tableName + " (DailyExpenseTypeName,DailyExpenseTypeDescription,AddedBy,AddedOn,UserInfoUserName) values(@DailyExpenseTypeName,@DailyExpenseTypeDescription,@addedBy,@addedOn,@UserInfoUserName)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("DailyExpenseTypeName", expenseTypeName);
                SqlParameter p2 = new SqlParameter("DailyExpenseTypeDescription", expenseTypeDescription);
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
                    result[0] = "DailyExpenseType " + expenseTypeName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "DailyExpenseType " + expenseTypeName + " does not added successfully.";
                result[1] = "fail";
                result[2] = "Insertion Failed !";
                con.Close();
            }

            return result;

        }
        public string[] UpdateDailyExpenseTypeData(string expenseTypeName, string expenseTypeDescription,  int id, string modifiedBy, string userName)
        {
            // string tableName = "CT_" + userName + "_DailyExpenseType";
            string tableName = "DailyExpenseType";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set DailyExpenseTypeName =@DailyExpenseTypeName,DailyExpenseTypeDescription =@DailyExpenseTypeDescription,LastModifiedOn=@lastModifiedOn ,LastModifiedBy = @lastModifiedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", id);
                SqlParameter p2 = new SqlParameter("DailyExpenseTypeDescription", expenseTypeDescription);
                SqlParameter p3 = new SqlParameter("DailyExpenseTypeName", expenseTypeName);
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
                    result[0] = "DailyExpenseType " + expenseTypeName + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "DailyExpenseType " + expenseTypeName + " does not updated successfully.";
                result[1] = "fail";
                result[2] = "Updation Failed !";
                con.Close();
            }

            return result;

        }
        public string[] DeleteDailyExpenseTypeData(int userTypeId, string deletedBy, string userName)
        {
            // string tableName = "CT_" + userName + "_DailyExpenseType";
            string tableName = "DailyExpenseType";
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
                    result[0] = "DailyExpenseType with Id " + userTypeId + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "DailyExpenseType  with Id " + userTypeId + " does not deleted successfully.";
                result[1] = "fail";
                result[2] = "Deletion Failed !";
                con.Close();
            }

            return result;

        }
        public DailyExpenseType GetDailyExpenseTypeDataByDailyExpenseTypeCode(int expenseTypeId, string userName)
        {
            //  string tableName = "CT_" + userName + "_DailyExpenseType";
            string tableName = "DailyExpenseType";
            DailyExpenseType expenseType = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where Id=@Id and IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", expenseTypeId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    expenseType = new DailyExpenseType(int.Parse(dr["Id"].ToString()), dr["DailyExpenseTypeName"].ToString(),
                     dr["DailyExpenseTypeDescription"].ToString(),  (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, dr["UserInfoUserName"].ToString());

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return expenseType;

        }
        public List<DailyExpenseType> GetDailyExpenseTypeDataListForDropDown(string userName)
        {
            //  string tableName = "CT_" + userName + "_DailyExpenseType";
            string tableName = "DailyExpenseType";
            List<DailyExpenseType> expenseType = new List<DailyExpenseType>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,DailyExpenseTypeName from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";

                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    DailyExpenseType tempDailyExpenseType = new DailyExpenseType(int.Parse(dr["Id"].ToString()), dr["DailyExpenseTypeName"].ToString());
                    expenseType.Add(tempDailyExpenseType);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return expenseType;
        }
        public List<DailyExpenseType> GetDailyExpenseTypeDataListForDropDownAllIncludedDeleted(string userName)
        {
            string tableName = "DailyExpenseType";
            List<DailyExpenseType> expenseType = new List<DailyExpenseType>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,DailyExpenseTypeName from " + tableName + " where UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    DailyExpenseType tempDailyExpenseType = new DailyExpenseType(int.Parse(dr["Id"].ToString()), dr["DailyExpenseTypeName"].ToString());
                    expenseType.Add(tempDailyExpenseType);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return expenseType;

        }
        public List<DailyExpenseType> GetDailyExpenseTypeDataList(string userName)
        {
            //string tableName = "CT_" + userName + "_DailyExpenseType";
            string tableName = "DailyExpenseType";
            List<DailyExpenseType> expenseType = new List<DailyExpenseType>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    DailyExpenseType tempDailyExpenseType = new DailyExpenseType(int.Parse(dr["Id"].ToString()), dr["DailyExpenseTypeName"].ToString(),
                        dr["DailyExpenseTypeDescription"].ToString(),  (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, dr["UserInfoUserName"].ToString());
                    expenseType.Add(tempDailyExpenseType);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return expenseType;

        }

    }
}