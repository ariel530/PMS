using PMS.DynamicBindingModels;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class StaffInfoDAL
    {
        public string[] InsertStaffData(StaffInfo staffInfo, StaffDetail staffDetail, List<EducationRecord> educationRecords)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            SqlTransaction sqlTransaction = null;
            try
            {
                DateTime dateTime = DateTime.Now;
                con.Open();
                sqlTransaction = con.BeginTransaction();
                AddStaffInfo(staffInfo, dateTime, con,sqlTransaction);
                AddStaffDetail(staffDetail, dateTime, con,sqlTransaction);
                AddEducationRecord(educationRecords, dateTime, con,sqlTransaction);
                sqlTransaction.Commit();
                result[0] = "Staff  with username " + staffInfo.UserName + " updated successfully.";
                result[1] = "success";
                result[2] = "Updated Successfully !";

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback(); 
                result[0] = "Unfortunately Some thing went Wrong.";
                result[1] = "fail";
                result[2] = "Unable to Insertion !";

            }
            finally
            {
                con.Close();
            }

            return result;

        }

        public void AddStaffInfo(StaffInfo staffInfo, DateTime addedDateTime ,SqlConnection con , SqlTransaction sqlTransaction)
        {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_UserInfoForStaff_Insertion";
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = staffInfo.UserName;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = staffInfo.Email;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = staffInfo.Password;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = staffInfo.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = staffInfo.LastName;
                cmd.Parameters.Add("@UserType", SqlDbType.Int).Value = staffInfo.UsersType;
                cmd.Parameters.Add("@CountryCode", SqlDbType.NVarChar).Value = staffInfo.CountryCode;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = staffInfo.PhoneNumber;
                cmd.Parameters.Add("@MobileNumber", SqlDbType.NVarChar).Value = staffInfo.MobileNumber;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = staffInfo.Address;
                cmd.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value = staffInfo.ImagePath;
                cmd.Parameters.Add("@AddedOn", SqlDbType.DateTime).Value = addedDateTime;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = staffInfo.AddedBy;
                cmd.Parameters.Add("@FatherName", SqlDbType.NVarChar).Value = staffInfo.FatherName;
                cmd.Parameters.Add("@Gender", SqlDbType.Int).Value = staffInfo.Gender;
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = staffInfo.DateOfBirth;
                cmd.Parameters.Add("@CNICNumber", SqlDbType.NVarChar).Value = staffInfo.CNICNumber;
                cmd.Parameters.Add("@ReferFrom", SqlDbType.NVarChar).Value = staffInfo.ReferFrom;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = staffInfo.CompanyId;

                cmd.Connection = con;
            cmd.Transaction = sqlTransaction;
                int effectedRows = cmd.ExecuteNonQuery();
               
           
          

        }
        public void AddStaffDetail(StaffDetail staffDetail, DateTime addedDateTimed,SqlConnection con, SqlTransaction sqlTransaction)
        {
            //string tableName="CI_" + userName + "_StaffInfo";
            string tableName = "StaffDetail";
         
            string qry = "insert into " + tableName + " (StaffInfoId,StaffPassportNumber," +
                "StaffCardNumber,StaffSalary" +
                ",StaffCategoryId,StaffDesignationId,AddedBy,AddedOn,CompanyId) values(@StaffInfoId," +
                "@StaffPassportNumber,@StaffCardNumber,@StaffSalary,@StaffCategoryId,@StaffDesignationId" +
                ",@addedBy,@addedOn,@CompanyId)";
            SqlCommand cmd = new SqlCommand(qry, con,sqlTransaction);
            SqlParameter p1 = new SqlParameter("StaffInfoId", staffDetail.StaffInfoId);
            SqlParameter p3 = new SqlParameter("StaffPassportNumber", staffDetail.StaffPassportNumber);
            SqlParameter p4 = new SqlParameter("StaffCardNumber", staffDetail.StaffCardNumber);
            SqlParameter p5 = new SqlParameter("StaffSalary", staffDetail.StaffSalary);
            SqlParameter p6 = new SqlParameter("StaffCategoryId", staffDetail.StaffCategoryId);
            SqlParameter p7 = new SqlParameter("StaffDesignationId", staffDetail.StaffDesignationId);
            SqlParameter p8 = new SqlParameter("AddedBy", staffDetail.AddedBy);
            SqlParameter p9 = new SqlParameter("AddedOn", addedDateTimed);
            SqlParameter p10 = new SqlParameter("CompanyId", staffDetail.CompanyId);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);
            cmd.Parameters.Add(p7);
            cmd.Parameters.Add(p8);
            cmd.Parameters.Add(p9);
            cmd.Parameters.Add(p10);
           
            int effectedRows = cmd.ExecuteNonQuery();



        }
    public void AddEducationRecord(List<EducationRecord> educationRecords, DateTime addedDateTimed ,SqlConnection con, SqlTransaction sqlTransaction)
        {
            //string tableName="CI_" + userName + "_StaffInfo";
            string tableName = "EducationRecord";
            foreach (EducationRecord educationRecord in educationRecords)
            {
                string qry = "insert into " + tableName + " (UserId,Degree," +
                    "Year,AddedBy,AddedOn,CompanyId) values(@UserId,@Degree," +
                    "@Year,@AddedBy,@AddedOn,@CompanyId)";
                SqlCommand cmd = new SqlCommand(qry, con,sqlTransaction);
                SqlParameter p1 = new SqlParameter("UserId", educationRecord.UserId);
                SqlParameter p2 = new SqlParameter("Degree", educationRecord.Degree);
                SqlParameter p3 = new SqlParameter("Year", educationRecord.Year);
                SqlParameter p4 = new SqlParameter("AddedBy", educationRecord.AddedBy);
                SqlParameter p5= new SqlParameter("AddedOn", addedDateTimed);
                SqlParameter p6 = new SqlParameter("CompanyId", educationRecord.CompanyId);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
            
                int effectedRows = cmd.ExecuteNonQuery();
            }
       


        }

//        public string[] UpdateStaffData(StaffInfo staffInfo, string previousCountryCode, string userName, string modifiedBy)
//        {
//            //string tableName = "CI_" + userName + "_StaffInfo";
//            string tableName = "UserInfo";
//            string[] result = new string[3];
//            SqlConnection con = Utility.DBConnection.GetConnection();
//            try
//            {
//                string qry = "";
//                SqlCommand cmd = null;
//                if (staffInfo.ImagePath != "")
//                {
//                    qry = "Update " + tableName + " SET  Password=@Password,FirstName=@FirstName,LastName=@LastName" +
//",StaffType=@StaffType,CountryCode=@CountryCode,ReferFrom=@ReferFrom,PhoneNumber=@PhoneNumber,MobileNumber=@MobileNumber" +
//",Address=@Address,ImagePath=@ImagePath,LastModifiedBy=@LastModifiedBy,LastModifiedOn=@LastModifiedOn where UserName=@UserName and UserInfoUserName=@UserInfoUserName";
//                    cmd = new SqlCommand(qry, con);
//                    SqlParameter p1 = new SqlParameter("UserName", staffInfo.UserName);
//                    SqlParameter p2 = new SqlParameter("Password", staffInfo.Password);
//                    SqlParameter p3 = new SqlParameter("FirstName", staffInfo.FirstName);
//                    SqlParameter p4 = new SqlParameter("LastName", staffInfo.LastName);
//                    SqlParameter p5 = new SqlParameter("StaffType", staffInfo.StaffType);
//                    SqlParameter p6 = new SqlParameter("CountryCode", staffInfo.CountryCode);
//                    SqlParameter p7 = new SqlParameter("PhoneNumber", staffInfo.PhoneNumber);
//                    SqlParameter p8 = new SqlParameter("MobileNumber", staffInfo.MobileNumber);
//                    SqlParameter p9 = new SqlParameter("Address", staffInfo.Address);
//                    SqlParameter p10 = new SqlParameter("ImagePath", staffInfo.ImagePath);
//                    SqlParameter p11 = new SqlParameter("LastModifiedBy", modifiedBy);
//                    SqlParameter p12 = new SqlParameter("LastModifiedOn", DateTime.Now);
//                    SqlParameter p13 = new SqlParameter("ReferFrom", staffInfo.ReferFrom);
//                    SqlParameter p14 = new SqlParameter("UserInfoUserName", userName);
//                    cmd.Parameters.Add(p1);
//                    cmd.Parameters.Add(p2);
//                    cmd.Parameters.Add(p3);
//                    cmd.Parameters.Add(p4);
//                    cmd.Parameters.Add(p5);
//                    cmd.Parameters.Add(p6);
//                    cmd.Parameters.Add(p7);
//                    cmd.Parameters.Add(p8);
//                    cmd.Parameters.Add(p9);
//                    cmd.Parameters.Add(p10);
//                    cmd.Parameters.Add(p11);
//                    cmd.Parameters.Add(p12);
//                    cmd.Parameters.Add(p13);
//                    cmd.Parameters.Add(p14);
//                }
//                else
//                {
//                    qry = "Update " + tableName + " SET  Password=@Password,FirstName=@FirstName,LastName=@LastName" +
//   ",StaffType=@StaffType,CountryCode=@CountryCode,PhoneNumber=@PhoneNumber,ReferFrom=@ReferFrom,MobileNumber=@MobileNumber" +
//   ",Address=@Address,LastModifiedBy=@LastModifiedBy,LastModifiedOn=@LastModifiedOn where UserName=@UserName and UserInfoUserName=@UserInfoUserName";
//                    cmd = new SqlCommand(qry, con);
//                    SqlParameter p1 = new SqlParameter("UserName", staffInfo.UserName);
//                    SqlParameter p2 = new SqlParameter("Password", staffInfo.Password);
//                    SqlParameter p3 = new SqlParameter("FirstName", staffInfo.FirstName);
//                    SqlParameter p4 = new SqlParameter("LastName", staffInfo.LastName);
//                    SqlParameter p5 = new SqlParameter("StaffType", staffInfo.StaffType);
//                    SqlParameter p6 = new SqlParameter("CountryCode", staffInfo.CountryCode);
//                    SqlParameter p7 = new SqlParameter("PhoneNumber", staffInfo.PhoneNumber);
//                    SqlParameter p8 = new SqlParameter("MobileNumber", staffInfo.MobileNumber);
//                    SqlParameter p9 = new SqlParameter("Address", staffInfo.Address);
//                    SqlParameter p10 = new SqlParameter("LastModifiedBy", modifiedBy);
//                    SqlParameter p11 = new SqlParameter("LastModifiedOn", DateTime.Now);
//                    SqlParameter p12 = new SqlParameter("ReferFrom", staffInfo.ReferFrom);
//                    SqlParameter p13 = new SqlParameter("UserInfoUserName", userName);
//                    cmd.Parameters.Add(p1);
//                    cmd.Parameters.Add(p2);
//                    cmd.Parameters.Add(p3);
//                    cmd.Parameters.Add(p4);
//                    cmd.Parameters.Add(p5);
//                    cmd.Parameters.Add(p6);
//                    cmd.Parameters.Add(p7);
//                    cmd.Parameters.Add(p8);
//                    cmd.Parameters.Add(p9);
//                    cmd.Parameters.Add(p10);
//                    cmd.Parameters.Add(p11);
//                    cmd.Parameters.Add(p12);
//                    cmd.Parameters.Add(p13);
//                }
//                con.Open();
//                int effectedRows = cmd.ExecuteNonQuery();
//                if (effectedRows > 0)
//                {

//                    if (staffInfo.CountryCode.CompareTo(previousCountryCode) != 0)
//                    {
//                        UpdateCoustomerInMapCount(staffInfo.CountryCode, previousCountryCode, userName);
//                    }
//                    result[0] = "Staff  with username " + staffInfo.UserName + " updated successfully.";
//                    result[1] = "success";
//                    result[2] = "Updated Successfully !";

//                }
//                else
//                {
//                    result[0] = "Staff  with username " + staffInfo.UserName + " does not updated successfully.";
//                    result[1] = "fail";
//                    result[2] = "Updation Failed !";
//                }
//                con.Close();

//            }
//            catch (Exception ex)
//            {
//                result[0] = "Unfortunately Some thing went Wrong.";
//                result[1] = "fail";
//                result[2] = "Unable to Update !";
//                con.Close();
//            }

//            return result;

//        }
//        public string[] DeleteStaffData(string staffName, string userName, string deletedBy)
//        {
//            // string tableName = "CI_" + userName + "_StaffInfo";
//            string tableName = "UserInfo";
//            string[] result = new string[3];
//            SqlConnection con = Utility.DBConnection.GetConnection();
//            try
//            {
//                string qry = "Update " + tableName + " Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where UserName=@UserName and UserInfoUserName=@UserInfoUserName";
//                SqlCommand cmd = new SqlCommand(qry, con);
//                SqlParameter p1 = new SqlParameter("UserName", staffName);
//                SqlParameter p2 = new SqlParameter("deletedBy", deletedBy);
//                SqlParameter p3 = new SqlParameter("deletedOn", DateTime.Now);
//                SqlParameter p4 = new SqlParameter("UserInfoUserName", userName);
//                cmd.Parameters.Add(p1);
//                cmd.Parameters.Add(p2);
//                cmd.Parameters.Add(p3);
//                cmd.Parameters.Add(p4);
//                con.Open();
//                int effectedRows = cmd.ExecuteNonQuery();
//                if (effectedRows > 0)
//                {
//                    result[0] = "Staff with username " + staffName + " deleted successfully.";
//                    result[1] = "success";
//                    result[2] = "Deleted Successfully !";
//                }
//                else
//                {
//                    result[0] = "Staff  with username " + staffName + " does not deleted successfully.";
//                    result[1] = "fail";
//                    result[2] = "Deletion Failed !";
//                }

//                con.Close();

//            }
//            catch (Exception ex)
//            {
//                result[0] = "Unfortunately Some thing went Wrong.";
//                result[1] = "fail";
//                result[2] = "Unable to Delete !";

//                con.Close();
//            }

//            return result;

//        }

        public string[] CheckUserNameExists(string staffName, int companyId)
        {
            string tableName = "UserInfo";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Select UserName from " + tableName + " where UserName=@UserName and CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserName", staffName);
                SqlParameter p2 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    result[0] = "Staff with username " + staffName + " already exist.";
                    result[1] = "success";
                    result[2] = "UserName Not Unique !";
                }
                else
                {
                    result[0] = "Staff  with username " + staffName + " does not exists.";
                    result[1] = "fail";
                    result[2] = "UserName  Unique !";
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Something went wrong while staffName validation.";
                result[1] = "vfail";
                result[2] = "UserName Validation fail !";
                con.Close();
            }

            return result;
        }
        public string[] CheckEmailExists(string email, int companyId)
        {
            string tableName = "UserInfo";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Select * from " + tableName + " where Email=@Email and CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Email", email);
                SqlParameter p2 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    result[0] = "Staff with email " + email + " already exist.";
                    result[1] = "success";
                    result[2] = "Email Not Unique !";
                }
                else
                {
                    result[0] = "Staff  with email " + email + " does not exists.";
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
        public string[] CheckCardNumberExists(string staffCardNumber, int companyId)
        {
            string tableName = "StaffDetail";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Select * from " + tableName + " where StaffCardNumber=@StaffCardNumber and CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("StaffCardNumber", staffCardNumber);
                SqlParameter p2 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    result[0] = "Staff with staff card number " + staffCardNumber + " already exist.";
                    result[1] = "success";
                    result[2] = "Email Not Unique !";
                }
                else
                {
                    result[0] = "Staff  with staff card number  " + staffCardNumber + " does not exists.";
                    result[1] = "fail";
                    result[2] = "Email  Unique !";
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Something went wrong while staff card number  validation.";
                result[1] = "vfail";
                result[2] = "Staff card number  Validation fail !";
                con.Close();
            }


            return result;
        }


        public List<Staff_ForTableDisplay> GetAllStaffDataFromDisplay(int companyId)
        {
            //  string tableName = "PT_" + userName + "_StaffCategory";
             List<Staff_ForTableDisplay> staffList = new List<Staff_ForTableDisplay>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry =   " select UserInfo.Email,UserInfo.UserName,StaffDetail.StaffCardNumber,UserInfo.Password,  "
 +   " StaffCategory.StaffCategoryName, StaffDesignation.StaffDesignationName,  "
 +   " Gender.GenderName,  "
 +   "  Country.CountryName,UserInfo.MobileNumber,  "
 +   " UserInfo.ImagePath,UserInfo.AddedOn,UserInfo.AddedBy,UserInfo.LastModifiedOn,UserInfo.LastModifiedBy  "
 +   " from UserInfo  "
 +   " Left join Gender on  "
 +   "   UserInfo.Gender = Gender.Id   "
 +   "   Left join Country on  "
 +   "   UserInfo.CountryCode = Country.CountryCode  "
+   "  Left join StaffDetail on  "
+   "  UserInfo.Username = staffdetail.staffInfoId  "
+   "    Left join StaffCategory on  "
+   "    StaffDetail.StaffCategoryId = StaffCategory.Id  "
    +   "Left join StaffDesignation on  "
   +   " StaffDetail.StaffDesignationId = StaffDesignation.Id  "
   +   "  where UserInfo.UserType = 2  "
 +   "    and UserInfo.IsDeleted = 0  "
+   "and UserInfo.CompanyId = @CompanyId  ";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    Staff_ForTableDisplay staff_ForTableDisplay = new Staff_ForTableDisplay(dr["UserName"].ToString(), dr["Email"].ToString()
                        , dr["StaffCardNumber"].ToString(), dr["Password"].ToString(), dr["StaffCategoryName"].ToString(), dr["StaffDesignationName"].ToString(),
                        dr["GenderName"].ToString(), dr["CountryName"].ToString(), dr["MobileNumber"].ToString(), dr["ImagePath"].ToString()
                        , dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);

                    staffList.Add(staff_ForTableDisplay);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffList;
        }

        public List<Tuple<String,String>> GetAllStaffDataByCategoryId(int staffCategoryId, int companyId)
        {
            //  string tableName = "PT_" + userName + "_StaffCategory";
            List<Tuple<String, String>> staffList = new List<Tuple<String, String>>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = " select UserInfo.UserName "
 + " from UserInfo , StaffDetail "

   + "  where UserInfo.UserType = 2  "
 + "    and UserInfo.IsDeleted = 0  "
 + "    and UserInfo.IsDeleted = 0  "
 + "    and UserInfo.UserName = StaffDetail.StaffInfoId  "
 + "    and StaffDetail.StaffCategoryId = @StaffCategoryId "
+ "and UserInfo.CompanyId = @CompanyId  ";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                SqlParameter p2 = new SqlParameter("StaffCategoryId", staffCategoryId);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   

                    staffList.Add(new Tuple<string,string>(dr["UserName"].ToString(), dr["UserName"].ToString()));
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffList;
        }






        public Staff_Enducation_ForSpecificView GetSpecificStaffDataForViewByUserName(string username, int companyId)
        {
            //  string tableName = "PT_" + userName + "_StaffCategory";
            Staff_Enducation_ForSpecificView staffInfoData =null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry =   "   select  "
+   "   UserInfo.UserName,UserInfo.Email,UserInfo.Password,UserInfo.FirstName,  "
+   "   UserInfo.LastName,UserInfo.UserType,  Country.CountryName,  "
+   "   UserInfo.PhoneNumber,UserInfo.MobileNumber,  "
+   "   UserInfo.Address,UserInfo.ImagePath,  "
+   "   UserInfo.FatherName,Gender.GenderName,  "
+   "   UserInfo.DateOfBirth,UserInfo.CNICNumber,  "
+   "   UserInfo.ReferFrom,UserInfo.CompanyId,  "
 +   "  StaffDetail.StaffPassportNumber,StaffDetail.StaffCardNumber,  "
 +   "  StaffDetail.StaffSalary, StaffCategory.StaffCategoryName,  "
 +   "  StaffDesignation.StaffDesignationName  "
 +   " from UserInfo  "
 +   " Left join Gender on  "
 +   "   UserInfo.Gender = Gender.Id  "
 +   "   Left join Country on  "
 +   "   UserInfo.CountryCode = Country.CountryCode  "
+   "  Left join StaffDetail on  "
+   "  UserInfo.Username = staffdetail.staffInfoId  "
+   "    Left join StaffCategory on  "
+   "    StaffDetail.StaffCategoryId = StaffCategory.Id  "
    +   "Left join StaffDesignation on  "
   +   " StaffDetail.StaffDesignationId = StaffDesignation.Id  "
   +   "  where UserInfo.UserType = 2  "
 +   "    and UserInfo.IsDeleted = 0  "
+   "and UserInfo.CompanyId = @CompanyId  "
+   "and UserInfo.UserName=@UserName  ";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                SqlParameter p2 = new SqlParameter("UserName", username);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                  
                     staffInfoData = new Staff_Enducation_ForSpecificView(dr["UserName"].ToString(), dr["Email"].ToString(),
                         dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(), dr["FatherName"].ToString(),
                        2, dr["ReferFrom"].ToString(), dr["GenderName"].ToString(), dr["CNICNumber"].ToString(),
                        DateTime.Parse(dr["DateOfBirth"].ToString()), dr["CountryName"].ToString(),
                        dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(), dr["Address"].ToString(), dr["ImagePath"].ToString(),
                        dr["StaffPassportNumber"].ToString(), dr["StaffCardNumber"].ToString(),
                        float.Parse(dr["StaffSalary"].ToString()), dr["StaffCategoryName"].ToString(), dr["StaffDesignationName"].ToString());
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffInfoData;
        }

        



        public int TotalStaffCount(int companyId)
        {
            //string tableName = "CI_" + userName + "_CustomerInfo";
            string tableName = "UserInfo";
            int count = 0;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Count(UserName) from " + tableName + " where " + tableName + ".IsDeleted=0 and CompanyId=@CompanyId  and UserType=2";
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("CompanyId", companyId);
                con.Open();
                count = (int)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {

            }
            con.Close();
            return count;
        }





        //        public StaffInfo GetStaffDataByUserName(string staffName, string userName)
        //        {
        //            //string tableName = "CI_" + userName + "_StaffInfo";
        //            string tableName = "UserInfo";
        //            StaffInfo staffInfo = null;
        //            SqlConnection con = Utility.DBConnection.GetConnection();
        //            try
        //            {
        //                string qry = "select * from " + tableName + " where UserName=@UserName and IsDeleted=0";
        //                SqlCommand cmd = new SqlCommand(qry, con);
        //                SqlParameter p1 = new SqlParameter("UserName", staffName);
        //                cmd.Parameters.Add(p1);
        //                con.Open();
        //                SqlDataReader dr = cmd.ExecuteReader();
        //                while (dr.Read())
        //                {
        //                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
        //                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
        //                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

        //                    staffInfo = new StaffInfo(dr["UserName"].ToString(), dr["Email"].ToString(), dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(),
        //int.Parse(dr["StaffType"].ToString()), dr["ReferFrom"].ToString(), dr["CountryCode"].ToString(), dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(),
        //dr["Address"].ToString(), dr["ImagePath"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
        //                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, dr["UserInfoUserName"].ToString());

        //                }
        //                dr.Close();
        //                con.Close();

        //            }
        //            catch (Exception ex)
        //            {
        //                con.Close();
        //            }

        //            return staffInfo;

        //        }
        //        public List<StaffInfo> GetStaffDataList(string userName)
        //        {
        //            // string tableName = "CI_" + userName + "_StaffInfo";
        //            string tableName = "UserInfo";
        //            List<StaffInfo> StaffInfoList = new List<StaffInfo>();
        //            SqlConnection con = Utility.DBConnection.GetConnection();
        //            try
        //            {
        //                string qry = "select * from " + tableName + " where IsDeleted=0";
        //                SqlCommand cmd = new SqlCommand(qry, con);
        //                con.Open();
        //                SqlDataReader dr = cmd.ExecuteReader();
        //                while (dr.Read())
        //                {
        //                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
        //                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
        //                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

        //                    StaffInfo tempStaffInfo = new StaffInfo(dr["UserName"].ToString(), dr["Email"].ToString(), dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(),
        //                    int.Parse(dr["StaffType"].ToString()), dr["ReferFrom"].ToString(), dr["CountryCode"].ToString(), dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(),
        //                    dr["Address"].ToString(), dr["ImagePath"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
        //                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, dr["UserInfoUserName"].ToString());
        //                    StaffInfoList.Add(tempStaffInfo);

        //                }
        //                dr.Close();
        //                con.Close();
        //            }
        //            catch (Exception ex)
        //            {
        //                con.Close();
        //            }

        //            return StaffInfoList;

        //        }
        //        public List<Staff_Country_StaffType_ForDIsplayStaffsInfo> GetAllStaffInfoForDisplay(string userName)
        //        {
        //            // string tableName = "CI_" + userName + "_StaffInfo";
        //            string tableName = "UserInfo";
        //            // string staffTypeTableName = "CT_" + userName + "_StaffType";
        //            string staffTypeTableName = "StaffType";
        //            List<Staff_Country_StaffType_ForDIsplayStaffsInfo> StaffInfoList = new List<Staff_Country_StaffType_ForDIsplayStaffsInfo>();
        //            SqlConnection con = Utility.DBConnection.GetConnection();
        //            try
        //            {
        //                string qry = "select *,CountryName,StaffTypeName from " + tableName + ",Country," + staffTypeTableName + " where " + tableName + ".IsDeleted=0 and " + tableName + ".CountryCode=Country.CountryCode and " + tableName + ".StaffType = " + staffTypeTableName + ".Id and  " + tableName + ".UserInfoUserName = @UserInfoUserName";
        //                SqlCommand cmd = new SqlCommand(qry, con);
        //                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
        //                cmd.Parameters.Add(p1);
        //                con.Open();
        //                SqlDataReader dr = cmd.ExecuteReader();
        //                while (dr.Read())
        //                {
        //                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
        //                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
        //                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

        //                    StaffInfo tempStaffInfo = new StaffInfo(dr["UserName"].ToString(), dr["Email"].ToString(), dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(),
        //                    int.Parse(dr["StaffType"].ToString()), dr["ReferFrom"].ToString(), dr["CountryCode"].ToString(), dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(),
        //                    dr["Address"].ToString(), dr["ImagePath"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
        //                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, dr["UserInfoUserName"].ToString());

        //                    StaffInfoList.Add(new Staff_Country_StaffType_ForDIsplayStaffsInfo(tempStaffInfo, dr["CountryName"].ToString(), dr["StaffTypeName"].ToString()));
        //                }
        //                dr.Close();
        //                con.Close();

        //            }
        //            catch (Exception ex)
        //            {
        //                con.Close();
        //            }

        //            return StaffInfoList;
        //        }


        //        public bool InsertCoustomerInMapCountByOne(string countryCode, string userName)
        //        {
        //            // string tableName = "PCMC_" + userName + "_Country_MapCount";
        //            string tableName = "User_Country_MapCount";
        //            SqlConnection con = Utility.DBConnection.GetConnection();
        //            try
        //            {
        //                int projectsCount = 0;
        //                int countryCount = 1;
        //                string qry = "insert into " + tableName + " (CountryCode,ProjectsCount,StaffsCount," +
        //                    "AddedBy,AddedOn,UserInfoUserName) values(@CountryCode,@ProjectsCount,@StaffsCount,@addedBy,@addedOn,@UserInfoUserName)";
        //                SqlCommand cmd = new SqlCommand(qry, con);
        //                SqlParameter p1 = new SqlParameter("CountryCode", countryCode);
        //                SqlParameter p2 = new SqlParameter("ProjectsCount", projectsCount);
        //                SqlParameter p3 = new SqlParameter("StaffsCount", countryCount);
        //                SqlParameter p4 = new SqlParameter("addedBy", userName);
        //                SqlParameter p5 = new SqlParameter("addedOn", DateTime.Now);
        //                SqlParameter p6 = new SqlParameter("UserInfoUserName", userName);
        //                cmd.Parameters.Add(p1);
        //                cmd.Parameters.Add(p2);
        //                cmd.Parameters.Add(p3);
        //                cmd.Parameters.Add(p4);
        //                cmd.Parameters.Add(p5);
        //                cmd.Parameters.Add(p6);
        //                con.Open();
        //                int effectedRows = cmd.ExecuteNonQuery();
        //                if (effectedRows > 0)
        //                {
        //                    con.Close();
        //                    return true;
        //                }
        //                else
        //                {
        //                    con.Close();
        //                    return false;
        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                con.Close();
        //                return false;

        //            }
        //        }

        //        public bool UpdateCoustomerInMapCount(string countryCode, string previousCountryCode, string userName)
        //        {
        //            //string tableName = "PCMC_" + userName + "_Country_MapCount";
        //            string tableName = "User_Country_MapCount";
        //            if (previousCountryCode != "")
        //            {
        //                decreamentCoustomerInMapCount(previousCountryCode, userName);
        //            }
        //            SqlConnection con = Utility.DBConnection.GetConnection();
        //            try
        //            {


        //                string qry = "Update " + tableName + " Set StaffsCount=StaffsCount+1 " +
        //                    ",LastModifiedBy=@LastModifiedBy, LastModifiedOn=@LastModifiedOn where CountryCode=@CountryCode and UserInfoUserName=@UserInfoUserName";
        //                SqlCommand cmd = new SqlCommand(qry, con);
        //                SqlParameter p1 = new SqlParameter("CountryCode", countryCode);
        //                SqlParameter p2 = new SqlParameter("LastModifiedBy", userName);
        //                SqlParameter p3 = new SqlParameter("LastModifiedOn", DateTime.Now);
        //                SqlParameter p4 = new SqlParameter("UserInfoUserName", userName);
        //                cmd.Parameters.Add(p1);
        //                cmd.Parameters.Add(p2);
        //                cmd.Parameters.Add(p3);
        //                cmd.Parameters.Add(p4);
        //                con.Open();
        //                int effectedRows = cmd.ExecuteNonQuery();
        //                if (effectedRows > 0)
        //                {
        //                    con.Close();
        //                    return true;
        //                }
        //                else
        //                {
        //                    InsertCoustomerInMapCountByOne(countryCode, userName);
        //                    con.Close();
        //                    return false;
        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                con.Close();
        //                return false;

        //            }

        //        }

        //        public bool decreamentCoustomerInMapCount(string previousCountryCode, string userName)
        //        {
        //            //   string tableName = "PCMC_" + userName + "_Country_MapCount";
        //            string tableName = "User_Country_MapCount";
        //            SqlConnection con = Utility.DBConnection.GetConnection();
        //            try
        //            {


        //                string qry = "Update " + tableName + " Set StaffsCount=StaffsCount-1 " +
        //                    ",LastModifiedBy=@LastModifiedBy, LastModifiedOn=@LastModifiedOn where CountryCode=@CountryCode and UserInfoUserName=@UserInfoUserName";
        //                SqlCommand cmd = new SqlCommand(qry, con);
        //                SqlParameter p1 = new SqlParameter("CountryCode", previousCountryCode);
        //                SqlParameter p2 = new SqlParameter("LastModifiedBy", userName);
        //                SqlParameter p3 = new SqlParameter("LastModifiedOn", DateTime.Now);
        //                SqlParameter p4 = new SqlParameter("UserInfoUserName", userName);
        //                cmd.Parameters.Add(p1);
        //                cmd.Parameters.Add(p2);
        //                cmd.Parameters.Add(p3);
        //                cmd.Parameters.Add(p4);
        //                con.Open();
        //                int effectedRows = cmd.ExecuteNonQuery();
        //                if (effectedRows > 0)
        //                {
        //                    con.Close();
        //                    return true;
        //                }
        //                return false;

        //            }
        //            catch (Exception ex)
        //            {
        //                con.Close();
        //                return false;

        //            }

        //        }

        //        public List<StaffsProjectsMapCount> GetStaffCountsForMap(string userName)
        //        {
        //            List<StaffsProjectsMapCount> mapCounts = new List<StaffsProjectsMapCount>();
        //            // string tableName = "PCMC_" + userName + "_Country_MapCount";
        //            string tableName = "User_Country_MapCount";
        //            SqlConnection con = Utility.DBConnection.GetConnection();
        //            try
        //            {


        //                string qry = "Select  Country.CountryCode, CountryName,StaffsCount from " + tableName + ",Country where StaffsCount > 0 and " + tableName + ".CountryCode=Country.CountryCode and UserInfoUserName=@UserInfoUserName";
        //                SqlCommand cmd = new SqlCommand(qry, con);
        //                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
        //                cmd.Parameters.Add(p1);
        //                con.Open();
        //                SqlDataReader dr = cmd.ExecuteReader();
        //                while (dr.Read())
        //                {
        //                    StaffsProjectsMapCount staffsProjectsMapCount = new StaffsProjectsMapCount(dr["CountryCode"].ToString(), dr["CountryName"].ToString(), int.Parse(dr["StaffsCount"].ToString()), 0);
        //                    mapCounts.Add(staffsProjectsMapCount);

        //                }
        //                dr.Close();
        //                con.Close();

        //            }
        //            catch (Exception ex)
        //            {
        //                con.Close();

        //            }

        //            return mapCounts;
        //        }

        //        public List<StaffInfo> GetStaffDataListForDropdown(string userName)
        //        {
        //            string tableName = "UserInfo";
        //            List<StaffInfo> StaffInfoList = new List<StaffInfo>();
        //            SqlConnection con = Utility.DBConnection.GetConnection();
        //            try
        //            {
        //                string qry = "select UserName from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
        //                SqlCommand cmd = new SqlCommand(qry, con);
        //                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
        //                cmd.Parameters.Add(p1);
        //                con.Open();
        //                SqlDataReader dr = cmd.ExecuteReader();
        //                while (dr.Read())
        //                {
        //                    StaffInfo tempStaffInfo = new StaffInfo(dr["UserName"].ToString());
        //                    StaffInfoList.Add(tempStaffInfo);

        //                }
        //                dr.Close();
        //                con.Close();
        //            }
        //            catch (Exception ex)
        //            {
        //                con.Close();
        //            }

        //            return StaffInfoList;

        //        }

        //        public int TotalStaffsCount(string userName)
        //        {
        //            //string tableName = "CI_" + userName + "_StaffInfo";
        //            string tableName = "UserInfo";
        //            int count = 0;
        //            SqlConnection con = Utility.DBConnection.GetConnection();
        //            try
        //            {
        //                string qry = "select Count(UserName) from " + tableName + " where " + tableName + ".IsDeleted=0 ";
        //                SqlCommand cmd = new SqlCommand(qry, con);
        //                con.Open();
        //                count = (int)cmd.ExecuteScalar();

        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //            con.Close();
        //            return count;
        //        }



        //        public StaffInfo GetStaffInfoDetail(string staffName, string password, string userName)
        //        {
        //            //string tableName = "CI_" + userName + "_StaffInfo";
        //            string tableName = "UserInfo";
        //            StaffInfo adminInfo = null;
        //            SqlConnection con = Utility.DBConnection.GetConnection();
        //            try
        //            {
        //                string qry = "select * from " + tableName + " where (UserName=@UserName or Email=@Email) and Password=@Password ";
        //                SqlCommand cmd = new SqlCommand(qry, con);
        //                SqlParameter p1 = new SqlParameter("UserName", staffName);
        //                SqlParameter p2 = new SqlParameter("Email", staffName);
        //                SqlParameter p3 = new SqlParameter("Password", password);
        //                cmd.Parameters.Add(p1);
        //                cmd.Parameters.Add(p2);
        //                cmd.Parameters.Add(p3);
        //                con.Open();
        //                SqlDataReader dr = cmd.ExecuteReader();

        //                while (dr.Read())
        //                {
        //                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
        //                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
        //                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

        //                    adminInfo = new StaffInfo(dr["UserName"].ToString(), dr["Email"].ToString(), dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(), int.Parse(dr["StaffType"].ToString()), dr["ReferFrom"].ToString(),
        //                        dr["CountryCode"].ToString(), dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(), dr["Address"].ToString(), dr["ImagePath"].ToString(), bool.Parse(dr["IsDeleted"].ToString())
        //                         , dr["DeletedBy"].ToString(), deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, dr["UserInfoUserName"].ToString());
        //                }
        //                dr.Close();
        //                con.Close();

        //            }
        //            catch (Exception ex)
        //            {
        //                con.Close();
        //            }

        //            return adminInfo;
        //        }

    }
}