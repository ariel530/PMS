using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class CustomerTypeDAL
    {
        public string[] InsertCustomerTypeData(string customerTypeName,string customerTypeDescription,int customerTypePoints, string addedBy,string userName)
        {
          //  string tableName = "CT_" + userName + "_CustomerType";
            string tableName ="CustomerType";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {

                string qry = "insert into " + tableName + " (CustomerTypeName,CustomerTypeDescription,CustomerTypePoints,AddedBy,AddedOn,UserInfoUserName) values(@CustomerTypeName,@CustomerTypeDescription,@CustomerTypePoints,@addedBy,@addedOn,@UserInfoUserName)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CustomerTypeName", customerTypeName);
                SqlParameter p2 = new SqlParameter("CustomerTypeDescription", customerTypeDescription);
                SqlParameter p3 = new SqlParameter("CustomerTypePoints", customerTypePoints);
                SqlParameter p4 = new SqlParameter("addedBy", addedBy);
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
                    result[0] = "CustomerType " + customerTypeName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "CustomerType " + customerTypeName + " does not added successfully.";
                result[1] = "fail";
                result[2] = "Insertion Failed !";
                con.Close();
            }

            return result;

        }
        public string[] UpdateCustomerTypeData(string customerTypeName, string customerTypeDescription, int customerTypePoints, int id, string modifiedBy, string userName)
        {
           // string tableName = "CT_" + userName + "_CustomerType";
            string tableName = "CustomerType";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set CustomerTypeName =@CustomerTypeName,CustomerTypeDescription =@CustomerTypeDescription,CustomerTypePoints =@CustomerTypePoints ,LastModifiedOn=@lastModifiedOn ,LastModifiedBy = @lastModifiedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", id);
                SqlParameter p2 = new SqlParameter("CustomerTypeDescription", customerTypeDescription);
                SqlParameter p3 = new SqlParameter("CustomerTypePoints", customerTypePoints);
                SqlParameter p4 = new SqlParameter("CustomerTypeName", customerTypeName);
                SqlParameter p5 = new SqlParameter("lastModifiedBy", modifiedBy);
                SqlParameter p6 = new SqlParameter("lastModifiedOn", DateTime.Now);
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
                    result[0] = "CustomerType " + customerTypeName + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "CustomerType " + customerTypeName + " does not updated successfully.";
                result[1] = "fail";
                result[2] = "Updation Failed !";
                con.Close();
            }

            return result;

        }
        public string[] DeleteCustomerTypeData(int userTypeId, string deletedBy, string userName)
        {
           // string tableName = "CT_" + userName + "_CustomerType";
            string tableName = "CustomerType";
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
                    result[0] = "CustomerType with Id " + userTypeId + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "CustomerType  with Id " + userTypeId + " does not deleted successfully.";
                result[1] = "fail";
                result[2] = "Deletion Failed !";
                con.Close();
            }

            return result;

        }
        public CustomerType GetCustomerTypeDataByCustomerTypeCode(int userTypeId, string userName)
        {
          //  string tableName = "CT_" + userName + "_CustomerType";
            string tableName = "CustomerType";
            CustomerType customerType = null;
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

                    customerType = new CustomerType(int.Parse(dr["Id"].ToString()), dr["CustomerTypeName"].ToString(),
                     dr["CustomerTypeDescription"].ToString(),dr["CustomerTypePoints"].ToString(),   (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn,dr["UserInfoUserName"].ToString() );

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return customerType;

        }
        public List<CustomerType> GetCustomerTypeDataListForDropDown(string userName)
        {
          //  string tableName = "CT_" + userName + "_CustomerType";
            string tableName = "CustomerType";
            List<CustomerType> customerType = new List<CustomerType>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,CustomerTypeName from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";

                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    CustomerType tempCustomerType = new CustomerType(int.Parse(dr["Id"].ToString()), dr["CustomerTypeName"].ToString());
                    customerType.Add(tempCustomerType);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return customerType;
        }
        public List<CustomerType> GetCustomerTypeDataListForDropDownAllIncludedDeleted( string userName)
        {
            string tableName = "CustomerType";
            List<CustomerType> customerType = new List<CustomerType>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,CustomerTypeName from " + tableName + " where UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    CustomerType tempCustomerType = new CustomerType(int.Parse(dr["Id"].ToString()), dr["CustomerTypeName"].ToString());
                    customerType.Add(tempCustomerType);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return customerType;

        }
        public List<CustomerType> GetCustomerTypeDataList(string userName)
        {
            //string tableName = "CT_" + userName + "_CustomerType";
            string tableName = "CustomerType";
            List<CustomerType> customerType = new List<CustomerType>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from "+ tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
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

                    CustomerType tempCustomerType = new CustomerType(int.Parse(dr["Id"].ToString()), dr["CustomerTypeName"].ToString(),
                        dr["CustomerTypeDescription"].ToString(), dr["CustomerTypePoints"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, dr["UserInfoUserName"].ToString());
                    customerType.Add(tempCustomerType);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return customerType;

        }

    }
}