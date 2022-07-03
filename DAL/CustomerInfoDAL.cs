using PMS.DynamicBindingModels;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class CustomerInfoDAL
    {
        public string[] InsertCustomerData(CustomerInfo customerInfo,string userName, string addedBy)
        {
            //string tableName="CI_" + userName + "_CustomerInfo";
            string tableName="CustomerInfo";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "insert into " + tableName + " (UserName,Email,Password,FirstName,LastName" +
                    ",CustomerType,CountryCode,ReferFrom,PhoneNumber,MobileNumber" +
                    ",Address,ImagePath,AddedBy,AddedOn,UserInfoUserName) values(@UserName,@Email," +
                    "@Password,@FirstName,@LastName,@CustomerType,@CountryCode,@ReferFrom" +
                    ",@PhoneNumber,@MobileNumber,@Address,@ImagePath,@addedBy,@addedOn,@UserInfoUserName)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserName", customerInfo.UserName);
                SqlParameter p2 = new SqlParameter("Email", customerInfo.Email);
                SqlParameter p3 = new SqlParameter("Password", customerInfo.Password);
                SqlParameter p4 = new SqlParameter("FirstName", customerInfo.FirstName);
                SqlParameter p5 = new SqlParameter("LastName", customerInfo.LastName);
                SqlParameter p6 = new SqlParameter("CustomerType", customerInfo.CustomerType);
                SqlParameter p7 = new SqlParameter("CountryCode", customerInfo.CountryCode);
                SqlParameter p8 = new SqlParameter("ReferFrom", customerInfo.ReferFrom);
                SqlParameter p9 = new SqlParameter("PhoneNumber", customerInfo.PhoneNumber);
                SqlParameter p10 = new SqlParameter("MobileNumber", customerInfo.MobileNumber);
                SqlParameter p11 = new SqlParameter("Address", customerInfo.Address);
                SqlParameter p12 = new SqlParameter("ImagePath", customerInfo.ImagePath);
                SqlParameter p13 = new SqlParameter("addedBy", addedBy);
                SqlParameter p14 = new SqlParameter("addedOn", DateTime.Now);
                SqlParameter p15 = new SqlParameter("UserInfoUserName", userName);
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
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    UpdateCoustomerInMapCount(customerInfo.CountryCode,"", userName);
                    result[0] = "Customer  with username " + customerInfo.UserName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                }
                else
                {
                    result[0] = "Customer  with username " + customerInfo.UserName + " does not added successfully.";
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
        public string[] UpdateCustomerData(CustomerInfo customerInfo,string previousCountryCode, string userName, string modifiedBy)
        {
            //string tableName = "CI_" + userName + "_CustomerInfo";
            string tableName = "CustomerInfo";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "";
                SqlCommand cmd = null;
                if (customerInfo.ImagePath != "")
                {
                    qry = "Update " + tableName + " SET  Password=@Password,FirstName=@FirstName,LastName=@LastName" +
",CustomerType=@CustomerType,CountryCode=@CountryCode,ReferFrom=@ReferFrom,PhoneNumber=@PhoneNumber,MobileNumber=@MobileNumber" +
",Address=@Address,ImagePath=@ImagePath,LastModifiedBy=@LastModifiedBy,LastModifiedOn=@LastModifiedOn where UserName=@UserName and UserInfoUserName=@UserInfoUserName";
                    cmd = new SqlCommand(qry, con);
                    SqlParameter p1 = new SqlParameter("UserName", customerInfo.UserName);
                    SqlParameter p2 = new SqlParameter("Password", customerInfo.Password);
                    SqlParameter p3 = new SqlParameter("FirstName", customerInfo.FirstName);
                    SqlParameter p4 = new SqlParameter("LastName", customerInfo.LastName);
                    SqlParameter p5 = new SqlParameter("CustomerType", customerInfo.CustomerType);
                    SqlParameter p6 = new SqlParameter("CountryCode", customerInfo.CountryCode);
                    SqlParameter p7 = new SqlParameter("PhoneNumber", customerInfo.PhoneNumber);
                    SqlParameter p8 = new SqlParameter("MobileNumber", customerInfo.MobileNumber);
                    SqlParameter p9 = new SqlParameter("Address", customerInfo.Address);
                    SqlParameter p10 = new SqlParameter("ImagePath", customerInfo.ImagePath);
                    SqlParameter p11 = new SqlParameter("LastModifiedBy", modifiedBy);
                    SqlParameter p12 = new SqlParameter("LastModifiedOn", DateTime.Now);
                    SqlParameter p13 = new SqlParameter("ReferFrom", customerInfo.ReferFrom);
                    SqlParameter p14 = new SqlParameter("UserInfoUserName", userName);
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
                }
                else
                {
                    qry = "Update " + tableName + " SET  Password=@Password,FirstName=@FirstName,LastName=@LastName" +
   ",CustomerType=@CustomerType,CountryCode=@CountryCode,PhoneNumber=@PhoneNumber,ReferFrom=@ReferFrom,MobileNumber=@MobileNumber" +
   ",Address=@Address,LastModifiedBy=@LastModifiedBy,LastModifiedOn=@LastModifiedOn where UserName=@UserName and UserInfoUserName=@UserInfoUserName";
                    cmd = new SqlCommand(qry, con);
                    SqlParameter p1 = new SqlParameter("UserName", customerInfo.UserName);
                    SqlParameter p2 = new SqlParameter("Password", customerInfo.Password);
                    SqlParameter p3 = new SqlParameter("FirstName", customerInfo.FirstName);
                    SqlParameter p4 = new SqlParameter("LastName", customerInfo.LastName);
                    SqlParameter p5 = new SqlParameter("CustomerType", customerInfo.CustomerType);
                    SqlParameter p6 = new SqlParameter("CountryCode", customerInfo.CountryCode);
                    SqlParameter p7 = new SqlParameter("PhoneNumber", customerInfo.PhoneNumber);
                    SqlParameter p8 = new SqlParameter("MobileNumber", customerInfo.MobileNumber);
                    SqlParameter p9 = new SqlParameter("Address", customerInfo.Address);
                    SqlParameter p10 = new SqlParameter("LastModifiedBy", modifiedBy);
                    SqlParameter p11 = new SqlParameter("LastModifiedOn", DateTime.Now);
                    SqlParameter p12 = new SqlParameter("ReferFrom", customerInfo.ReferFrom);
                    SqlParameter p13 = new SqlParameter("UserInfoUserName", userName);
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
                }
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {

                    if (customerInfo.CountryCode.CompareTo(previousCountryCode) != 0)
                    {
                        UpdateCoustomerInMapCount(customerInfo.CountryCode, previousCountryCode, userName);
                    }
                    result[0] = "Customer  with username " + customerInfo.UserName + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully !";

                }
                else
                {
                    result[0] = "Customer  with username " + customerInfo.UserName + " does not updated successfully.";
                    result[1] = "fail";
                    result[2] = "Updation Failed !";
                }
                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Unfortunately Some thing went Wrong.";
                result[1] = "fail";
                result[2] = "Unable to Update !";
                con.Close();
            }

            return result;

        }
        public string[] DeleteCustomerData(string customerName, string userName, string deletedBy)
        {
           // string tableName = "CI_" + userName + "_CustomerInfo";
            string tableName = "CustomerInfo";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where UserName=@UserName and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserName", customerName);
                SqlParameter p2 = new SqlParameter("deletedBy", deletedBy);
                SqlParameter p3 = new SqlParameter("deletedOn", DateTime.Now);
                SqlParameter p4 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "Customer with username " + customerName + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }
                else
                {
                    result[0] = "Customer  with username " + customerName + " does not deleted successfully.";
                    result[1] = "fail";
                    result[2] = "Deletion Failed !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Unfortunately Some thing went Wrong.";
                result[1] = "fail";
                result[2] = "Unable to Delete !";

                con.Close();
            }

            return result;

        }

        public string[] CheckUserNameExists(string customerName, string userName)
        {
            string tableName = "CustomerInfo";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Select * from " + tableName + " where UserName=@UserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserName", customerName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    result[0] = "Customer with username " + customerName + " already exist.";
                    result[1] = "success";
                    result[2] = "UserName Not Unique !";
                }
                else
                {
                    result[0] = "Customer  with username " + customerName + " does not exists.";
                    result[1] = "fail";
                    result[2] = "UserName  Unique !";
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Something went wrong while customerName validation.";
                result[1] = "vfail";
                result[2] = "UserName Validation fail !";
                con.Close();
            }

            return result;
        }
        public string[] CheckEmailExists(string email, string userName)
        {
            string tableName = "CustomerInfo";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Select * from " + tableName + " where Email=@Email";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Email", email);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    result[0] = "Customer with email " + email + " already exist.";
                    result[1] = "success";
                    result[2] = "Email Not Unique !";
                }
                else
                {
                    result[0] = "Customer  with email " + email + " does not exists.";
                    result[1] = "fail";
                    result[2] = "Email  Unique !";
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Something went wrong while email validation.";
                result[1] = "vfail";
                result[2] = "Email Validation fail !";
                con.Close();
            }


            return result;
        }
        public CustomerInfo GetCustomerDataByUserName(string customerName, string userName)
        {
            //string tableName = "CI_" + userName + "_CustomerInfo";
            string tableName = "CustomerInfo";
            CustomerInfo customerInfo = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where UserName=@UserName and IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserName", customerName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    customerInfo = new CustomerInfo(dr["UserName"].ToString(),  dr["Email"].ToString(), dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(),
int.Parse(dr["CustomerType"].ToString()), dr["ReferFrom"].ToString(), dr["CountryCode"].ToString(), dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(),
dr["Address"].ToString(), dr["ImagePath"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn,dr["UserInfoUserName"].ToString());

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return customerInfo;

        }
        public List<CustomerInfo> GetCustomerDataList(string userName)
        {
           // string tableName = "CI_" + userName + "_CustomerInfo";
            string tableName = "CustomerInfo";
            List<CustomerInfo> CustomerInfoList = new List<CustomerInfo>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    CustomerInfo tempCustomerInfo = new CustomerInfo(dr["UserName"].ToString(), dr["Email"].ToString(), dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(),
                    int.Parse(dr["CustomerType"].ToString()), dr["ReferFrom"].ToString(), dr["CountryCode"].ToString(), dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(),
                    dr["Address"].ToString(), dr["ImagePath"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn,dr["UserInfoUserName"].ToString());
                    CustomerInfoList.Add(tempCustomerInfo);

                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }

            return CustomerInfoList;

        }
        public List<Customer_Country_CustomerType_ForDIsplayCustomersInfo> GetAllCustomerInfoForDisplay(string userName)
        {
           // string tableName = "CI_" + userName + "_CustomerInfo";
            string tableName = "CustomerInfo";
           // string customerTypeTableName = "CT_" + userName + "_CustomerType";
            string customerTypeTableName = "CustomerType";
            List<Customer_Country_CustomerType_ForDIsplayCustomersInfo> CustomerInfoList = new List<Customer_Country_CustomerType_ForDIsplayCustomersInfo>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select *,CountryName,CustomerTypeName from " + tableName + ",Country," + customerTypeTableName + " where " + tableName + ".IsDeleted=0 and " + tableName + ".CountryCode=Country.CountryCode and " + tableName + ".CustomerType = "+ customerTypeTableName + ".Id and  "+tableName+ ".UserInfoUserName = @UserInfoUserName";
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

                    CustomerInfo tempCustomerInfo = new CustomerInfo(dr["UserName"].ToString(), dr["Email"].ToString(), dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(),
                    int.Parse(dr["CustomerType"].ToString()), dr["ReferFrom"].ToString(),  dr["CountryCode"].ToString(), dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(),
                    dr["Address"].ToString(), dr["ImagePath"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn,dr["UserInfoUserName"].ToString());

                    CustomerInfoList.Add(new Customer_Country_CustomerType_ForDIsplayCustomersInfo(tempCustomerInfo, dr["CountryName"].ToString(), dr["CustomerTypeName"].ToString()));
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return CustomerInfoList;
        }


        public bool InsertCoustomerInMapCountByOne(string countryCode, string userName)
        {
           // string tableName = "PCMC_" + userName + "_Country_MapCount";
            string tableName = "User_Country_MapCount";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                int projectsCount = 0;
                int countryCount = 1;
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

        public bool UpdateCoustomerInMapCount(string countryCode, string previousCountryCode,  string userName  )
        {
            //string tableName = "PCMC_" + userName + "_Country_MapCount";
            string tableName = "User_Country_MapCount";
            if(previousCountryCode!="")
            {
                decreamentCoustomerInMapCount(previousCountryCode, userName);
            }
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
               

                string qry = "Update " + tableName + " Set CustomersCount=CustomersCount+1 " +
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
                    InsertCoustomerInMapCountByOne(countryCode, userName);
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

        public bool decreamentCoustomerInMapCount( string previousCountryCode, string userName)
        {
         //   string tableName = "PCMC_" + userName + "_Country_MapCount";
            string tableName = "User_Country_MapCount";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {


                string qry = "Update " + tableName + " Set CustomersCount=CustomersCount-1 " +
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

        public List<CustomersProjectsMapCount> GetCustomerCountsForMap(string userName)
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
                while(dr.Read())
                {
                    CustomersProjectsMapCount customersProjectsMapCount = new CustomersProjectsMapCount(dr["CountryCode"].ToString(), dr["CountryName"].ToString(), int.Parse(dr["CustomersCount"].ToString()),0);
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

        public List<CustomerInfo> GetCustomerDataListForDropdown(string userName)
        {
            string tableName = "CustomerInfo";
            List<CustomerInfo> CustomerInfoList = new List<CustomerInfo>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select UserName from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CustomerInfo tempCustomerInfo = new CustomerInfo(dr["UserName"].ToString());
                    CustomerInfoList.Add(tempCustomerInfo);

                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }

            return CustomerInfoList;

        }

        public int TotalCustomersCount(string userName)
        {
            //string tableName = "CI_" + userName + "_CustomerInfo";
            string tableName = "CustomerInfo";
            int count = 0;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Count(UserName) from " + tableName + " where " + tableName + ".IsDeleted=0 ";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                count =(int) cmd.ExecuteScalar();
               
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return count;
        }



        public CustomerInfo GetCustomerInfoDetail(string customerName, string password, string userName)
        {
            //string tableName = "CI_" + userName + "_CustomerInfo";
            string tableName = "CustomerInfo";
            CustomerInfo adminInfo = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from " + tableName + " where (UserName=@UserName or Email=@Email) and Password=@Password ";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserName", customerName);
                SqlParameter p2 = new SqlParameter("Email", customerName);
                SqlParameter p3 = new SqlParameter("Password", password);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    adminInfo = new CustomerInfo(dr["UserName"].ToString(), dr["Email"].ToString(), dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(), int.Parse(dr["CustomerType"].ToString()), dr["ReferFrom"].ToString(),
                        dr["CountryCode"].ToString(), dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(), dr["Address"].ToString(), dr["ImagePath"].ToString(), bool.Parse(dr["IsDeleted"].ToString())
                         , dr["DeletedBy"].ToString(), deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn,dr["UserInfoUserName"].ToString());
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return adminInfo;
        }

    }
}