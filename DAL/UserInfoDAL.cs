using PMS.DynamicBindingModels;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{

    public class UserInfoDAL
    {
        public string[] InsertUserData(UserInfo userInfo, string addedBy)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "insert into UserInfo (UserName,Email,Password,FirstName,LastName" +
                    ",UserType,CountryCode,PhoneNumber,MobileNumber" +
                    ",Address,ImagePath,AddedBy,AddedOn) values(@UserName,@Email," +
                    "@Password,@FirstName,@LastName,@UserType,@CountryCode" +
                    ",@PhoneNumber,@MobileNumber,@Address,@ImagePath,@addedBy,@addedOn)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserName", userInfo.UserName);
                SqlParameter p2 = new SqlParameter("Email", userInfo.Email);
                SqlParameter p3 = new SqlParameter("Password", userInfo.Password);
                SqlParameter p4 = new SqlParameter("FirstName", userInfo.FirstName);
                SqlParameter p5 = new SqlParameter("LastName", userInfo.LastName);
                SqlParameter p6 = new SqlParameter("UserType", userInfo.UserType);
                SqlParameter p7 = new SqlParameter("CountryCode", userInfo.CountryCode);
                SqlParameter p8 = new SqlParameter("PhoneNumber", userInfo.PhoneNumber);
                SqlParameter p9 = new SqlParameter("MobileNumber", userInfo.MobileNumber);
                SqlParameter p10 = new SqlParameter("Address", userInfo.Address);
                SqlParameter p11 = new SqlParameter("ImagePath", userInfo.ImagePath);
                SqlParameter p12 = new SqlParameter("addedBy", addedBy);
                SqlParameter p13 = new SqlParameter("addedOn", DateTime.Now);
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
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "User  with username " + userInfo.UserName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                    //string customerTypeTableName = GenerateDynamicCustomerTypeTableForUser(userInfo.UserName);
                    //string projectStatusTableName = GenerateDynamicProjectStatusTableForUser(userInfo.UserName);
                    //string projectPriorityTableName = GenerateDynamicProjectPriorityTableForUser(userInfo.UserName);
                    //string projectTypeTableName = GenerateDynamicProjectTypeTableForUser(userInfo.UserName);
                    //string customerInfoTableName = GenerateDynamicCustomerTableForUser(userInfo.UserName, customerTypeTableName, projectStatusTableName, result); ;
                    //result = GenerateDynamicCustomerProjectMapCountTableForUser(userInfo.UserName, result);
                    //string projectInfoTableName = GenerateDynamicProjectTableForUser(userInfo.UserName, customerInfoTableName, projectPriorityTableName, projectStatusTableName, projectTypeTableName);
                }
                else
                {
                    result[0] = "User  with username " + userInfo.UserName + " does not added successfully.";
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
        public string[] UpdateUserData(UserInfo userInfo, string modifiedBy)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "";
                SqlCommand cmd = null;
                if (userInfo.ImagePath != "")
                {
                    qry = "Update UserInfo SET  Password=@Password,FirstName=@FirstName,LastName=@LastName" +
",UserType=@UserType,CountryCode=@CountryCode,PhoneNumber=@PhoneNumber,MobileNumber=@MobileNumber" +
",Address=@Address,ImagePath=@ImagePath,LastModifiedBy=@LastModifiedBy,LastModifiedOn=@LastModifiedOn where UserName=@UserName";
                    cmd = new SqlCommand(qry, con);
                    SqlParameter p1 = new SqlParameter("UserName", userInfo.UserName);
                    SqlParameter p2 = new SqlParameter("Password", userInfo.Password);
                    SqlParameter p3 = new SqlParameter("FirstName", userInfo.FirstName);
                    SqlParameter p4 = new SqlParameter("LastName", userInfo.LastName);
                    SqlParameter p5 = new SqlParameter("UserType", userInfo.UserType);
                    SqlParameter p6 = new SqlParameter("CountryCode", userInfo.CountryCode);
                    SqlParameter p7 = new SqlParameter("PhoneNumber", userInfo.PhoneNumber);
                    SqlParameter p8 = new SqlParameter("MobileNumber", userInfo.MobileNumber);
                    SqlParameter p9 = new SqlParameter("Address", userInfo.Address);
                    SqlParameter p10 = new SqlParameter("ImagePath", userInfo.ImagePath);
                    SqlParameter p11 = new SqlParameter("LastModifiedBy", modifiedBy);
                    SqlParameter p12 = new SqlParameter("LastModifiedOn", DateTime.Now);
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
                }
                else
                {
                    qry = "Update UserInfo SET  Password=@Password,FirstName=@FirstName,LastName=@LastName" +
   ",UserType=@UserType,CountryCode=@CountryCode,PhoneNumber=@PhoneNumber,MobileNumber=@MobileNumber" +
   ",Address=@Address,LastModifiedBy=@LastModifiedBy,LastModifiedOn=@LastModifiedOn where UserName=@UserName";
                    cmd = new SqlCommand(qry, con);
                    SqlParameter p1 = new SqlParameter("UserName", userInfo.UserName);
                    SqlParameter p2 = new SqlParameter("Password", userInfo.Password);
                    SqlParameter p3 = new SqlParameter("FirstName", userInfo.FirstName);
                    SqlParameter p4 = new SqlParameter("LastName", userInfo.LastName);
                    SqlParameter p5 = new SqlParameter("UserType", userInfo.UserType);
                    SqlParameter p6 = new SqlParameter("CountryCode", userInfo.CountryCode);
                    SqlParameter p7 = new SqlParameter("PhoneNumber", userInfo.PhoneNumber);
                    SqlParameter p8 = new SqlParameter("MobileNumber", userInfo.MobileNumber);
                    SqlParameter p9 = new SqlParameter("Address", userInfo.Address);
                    SqlParameter p10 = new SqlParameter("LastModifiedBy", modifiedBy);
                    SqlParameter p11 = new SqlParameter("LastModifiedOn", DateTime.Now);
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
                }
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {

                    result[0] = "User  with username " + userInfo.UserName + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully !";
                }
                else
                {
                    result[0] = "User  with username " + userInfo.UserName + " does not updated successfully.";
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
        public string[] DeleteUserData(string userName, string deletedBy)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update UserInfo Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where UserName=@UserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserName", userName);
                SqlParameter p2 = new SqlParameter("deletedBy", deletedBy);
                SqlParameter p3 = new SqlParameter("deletedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "User with username " + userName + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }
                else
                {
                    result[0] = "User  with username " + userName + " does not deleted successfully.";
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
        public string[] CheckUserNameExists(string userName)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Select * from UserInfo where UserName=@UserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    result[0] = "User with username " + userName + " already exist.";
                    result[1] = "success";
                    result[2] = "UserName Not Unique !";
                }
                else
                {
                    result[0] = "User  with username " + userName + " does not exists.";
                    result[1] = "fail";
                    result[2] = "UserName  Unique !";
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Something went wrong while userName validation.";
                result[1] = "vfail";
                result[2] = "UserName Validation fail !";
                con.Close();
            }

            return result;
        }
        public string[] CheckEmailExists(string email)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Select * from UserInfo where Email=@Email";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Email", email);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    result[0] = "User with email " + email + " already exist.";
                    result[1] = "success";
                    result[2] = "Email Not Unique !";
                }
                else
                {
                    result[0] = "User  with email " + email + " does not exists.";
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
        public UserInfo GetUserDataByUserName(string userName)
        {
            UserInfo userInfo = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from UserInfo where UserName=@UserName and IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    userInfo = new UserInfo(dr["UserName"].ToString(), dr["Email"].ToString(), dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(),
int.Parse(dr["UserType"].ToString()), dr["CountryCode"].ToString(), dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(),
dr["Address"].ToString(), dr["ImagePath"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return userInfo;

        }
        public List<UserInfo> GetUserDataList()
        {
            List<UserInfo> UserInfoList = new List<UserInfo>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from UserInfo where IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    UserInfo tempUserInfo = new UserInfo(dr["UserName"].ToString(), dr["Email"].ToString(), dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(),
                    int.Parse(dr["UserType"].ToString()), dr["CountryCode"].ToString(), dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(),
                    dr["Address"].ToString(), dr["ImagePath"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);
                    UserInfoList.Add(tempUserInfo);

                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }

            return UserInfoList;

        }
        public List<User_Country_UserType_ForDIsplayUsersInfo> GetAllUserInfoForDisplay()
        {
            List<User_Country_UserType_ForDIsplayUsersInfo> UserInfoList = new List<User_Country_UserType_ForDIsplayUsersInfo>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select *,CountryName,UserTypeName from UserInfo,Country,UserType where UserInfo.IsDeleted=0 and UserInfo.CountryCode=Country.CountryCode and UserInfo.UserType = UserType.Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    UserInfo tempUserInfo = new UserInfo(dr["UserName"].ToString(), dr["Email"].ToString(), dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(),
                    int.Parse(dr["UserType"].ToString()), dr["CountryCode"].ToString(), dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(),
                    dr["Address"].ToString(), dr["ImagePath"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);

                    UserInfoList.Add(new User_Country_UserType_ForDIsplayUsersInfo(tempUserInfo, dr["CountryName"].ToString(), dr["UserTypeName"].ToString()));
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return UserInfoList;
        }
        private string[] GenerateDynamicCustomerProjectMapCountTableForUser(string userName, string[] result)
        {
            string tableName = "PCMC_" + userName + "_Country_MapCount";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "CREATE TABLE [dbo].[" + tableName + "](" +
                             "[CountryCode] [nvarchar](50) NOT NULL," +
                             "[ProjectsCount] [int] NOT NULL," +
                             "[CustomersCount] [int] NOT NULL," +
                             "[IsDeleted] [bit] NULL," +
                             "[DeletedOn] [datetime] NULL," +
                             "[DeletedBy] [nvarchar](200) NULL," +
                             "[AddedOn] [datetime] NULL," +
                             "[AddedBy] [nvarchar](200) NULL," +
                             "[LastModifiedOn] [datetime] NULL," +
                             "[LastModifiedBy] [nvarchar](200) NULL," +
                             "CONSTRAINT [PK_" + tableName + "] PRIMARY KEY CLUSTERED" +
                             "(" +
                             "[CountryCode] ASC" +
                             "))";
                string qry1 = "ALTER TABLE [dbo].[" + tableName + "] ADD  CONSTRAINT [DF_" + tableName + "_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]";
                string qry2 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_AddedBy] FOREIGN KEY([AddedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry3 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_AddedBy]";
                string qry4 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_DeletedBy] FOREIGN KEY([DeletedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry5 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_DeletedBy]";
                string qry6 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_LastModifiedBy] FOREIGN KEY([LastModifiedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry7 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_LastModifiedBy]";
                string qry8 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_Country_Code] FOREIGN KEY([CountryCode])"
                              + "REFERENCES [dbo].[Country] ([CountryCode])";
                string qry9 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_Country_Code]";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                cmd.CommandText = qry1;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry2;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry3;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry4;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry5;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry6;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry7;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry8;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry9;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                result[0] = "Unfortunately Some thing went Wrong.";
                result[1] = "fail";
                result[2] = "Unable to Create PCMC Table !";
                con.Close();
            }
            return result;
        }
        private string GenerateDynamicProjectStatusTableForUser(string userName)
        {
            string tableName = "PS_" + userName + "_ProjectStatus";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "CREATE TABLE [dbo].[" + tableName + "](" +
                             "[Id] [int] IDENTITY(1,1) NOT NULL," +
                             "[ProjectStatusName] [nvarchar](200) NOT NULL," +
                             "[ProjectStatusBackGroundColor] [nvarchar](200) NULL," +
                             "[ProjectStatusTextColor] [nvarchar](200) NULL," +
                             "[ProjectStatusDescription] [nvarchar](max) NULL," +
                             "[ProjectStatusShowInList] [bit] NULL," +
                             "[IsDeleted] [bit] NULL," +
                             "[DeletedOn] [datetime] NULL," +
                             "[DeletedBy] [nvarchar](200) NULL," +
                             "[AddedOn] [datetime] NULL," +
                             "[AddedBy] [nvarchar](200) NULL," +
                             "[LastModifiedOn] [datetime] NULL," +
                             "[LastModifiedBy] [nvarchar](200) NULL," +
                             "CONSTRAINT [PK_" + tableName + "] PRIMARY KEY CLUSTERED" +
                             "(" +
                             "[Id] ASC" +
                             "))";
                string qry1 = "ALTER TABLE [dbo].[" + tableName + "] ADD  CONSTRAINT [DF_" + tableName + "_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]";
                string qry2 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_AddedBy] FOREIGN KEY([AddedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry3 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_AddedBy]";
                string qry4 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_DeletedBy] FOREIGN KEY([DeletedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry5 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_DeletedBy]";
                string qry6 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_LastModifiedBy] FOREIGN KEY([LastModifiedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry7 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_LastModifiedBy]";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                cmd.CommandText = qry1;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry2;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry3;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry4;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry5;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry6;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry7;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return tableName;
        }
        private string GenerateDynamicCustomerTypeTableForUser(string userName)
        {
            string tableName = "CT_" + userName + "_CustomerType";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "CREATE TABLE [dbo].[" + tableName + "](" +
                             "[Id] [int] IDENTITY(1,1) NOT NULL," +
                             "[CustomerTypeName] [nvarchar](200) NOT NULL," +
                             "[CustomerTypeDescription] [nvarchar] (MAX)  NULL," +
                             "[CustomerTypePoints] [int]   NULL," +
                             "[IsDeleted] [bit] NULL," +
                             "[DeletedOn] [datetime] NULL," +
                             "[DeletedBy] [nvarchar](200) NULL," +
                             "[AddedOn] [datetime] NULL," +
                             "[AddedBy] [nvarchar](200) NULL," +
                             "[LastModifiedOn] [datetime] NULL," +
                             "[LastModifiedBy] [nvarchar](200) NULL," +
                             "CONSTRAINT [PK_" + tableName + "] PRIMARY KEY CLUSTERED" +
                             "(" +
                             "[Id] ASC" +
                             "))";
                string qry1 = "ALTER TABLE [dbo].[" + tableName + "] ADD  CONSTRAINT [DF_" + tableName + "_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]";
                string qry2 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_AddedBy] FOREIGN KEY([AddedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry3 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_AddedBy]";
                string qry4 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_DeletedBy] FOREIGN KEY([DeletedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry5 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_DeletedBy]";
                string qry6 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_LastModifiedBy] FOREIGN KEY([LastModifiedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry7 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_LastModifiedBy]";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                cmd.CommandText = qry1;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry2;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry3;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry4;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry5;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry6;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry7;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return tableName;
        }
        private string GenerateDynamicCustomerTableForUser(string userName, string customerTypeNameTableName, string projectStatusTableName, string[] result)
        {
            string tableName = "CI_" + userName + "_CustomerInfo";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "CREATE TABLE [dbo].[" + tableName + "](" +
                             "[UserName] [nvarchar](200) NOT NULL," +
                             "[Email] [nvarchar](200) NOT NULL," +
                             "[Password] [nvarchar](max) NOT NULL," +
                             "[FirstName] [nvarchar](200) NOT NULL," +
                             "[LastName] [nvarchar](200) NOT NULL," +
                             "[ReferFrom] [nvarchar](300) NOT NULL," +
                             "[CountryCode] [nvarchar](50) NOT NULL," +
                             "[CustomerType] [int] NOT NULL," +
                             "[PhoneNumber] [nvarchar](30) NULL," +
                             "[MobileNumber] [nvarchar](30) NULL," +
                             "[Address] [nvarchar](300) NULL," +
                             "[ImagePath] [nvarchar](max) NULL," +
                             "[IsDeleted] [bit] NULL," +
                             "[DeletedOn] [datetime] NULL," +
                             "[DeletedBy] [nvarchar](200) NULL," +
                             "[AddedOn] [datetime] NULL," +
                             "[AddedBy] [nvarchar](200) NULL," +
                             "[LastModifiedOn] [datetime] NULL," +
                             "[LastModifiedBy] [nvarchar](200) NULL," +
                             "CONSTRAINT [PK_" + tableName + "] PRIMARY KEY CLUSTERED" +
                             "(" +
                             "[UserName] ASC" +
                             ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" +
                              ") ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]";

                string qry1 = "ALTER TABLE [dbo].[" + tableName + "] ADD  CONSTRAINT [DF_" + tableName + "_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]";
                string qry2 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_AddedBy] FOREIGN KEY([AddedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry3 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_AddedBy]";
                string qry4 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_DeletedBy] FOREIGN KEY([DeletedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry5 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_DeletedBy]";
                string qry6 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_LastModifiedBy] FOREIGN KEY([LastModifiedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry7 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_LastModifiedBy]";
                string qry8 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_Country_CountryCode] FOREIGN KEY([CountryCode])" +
                              "REFERENCES [dbo].[Country] ([CountryCode])";
                string qry9 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_Country_CountryCode]";
                string qry10 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_CustomerType_Id] FOREIGN KEY([CustomerType])"
                               + "REFERENCES [dbo].[" + customerTypeNameTableName + "] ([Id])";
                string qry11 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_CustomerType_Id]";
                //string qry12 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_ProjectStatus_StatusId] FOREIGN KEY([ProjectStatus])"
                //                + "REFERENCES [dbo].[" + projectStatusTableName + "] ([Id])";
                //string qry13 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_ProjectStatus_StatusId]";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();

                int effectedRows = cmd.ExecuteNonQuery();
                cmd.CommandText = qry1;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry2;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry3;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry4;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry5;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry6;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry7;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry8;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry9;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry10;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry11;
                cmd.ExecuteNonQuery();
                //cmd.CommandText = qry12;
                //cmd.ExecuteNonQuery();
                //cmd.CommandText = qry13;
                //cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {

            }
            return tableName;
        }
        private string GenerateDynamicProjectPriorityTableForUser(string userName)
        {
            string tableName = "PP_" + userName + "_ProjectPriority";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "CREATE TABLE [dbo].[" + tableName + "](" +
                             "[Id] [int] IDENTITY(1,1) NOT NULL," +
                             "[ProjectPriorityName] [nvarchar](200) NOT NULL," +
                             "[ProjectPriorityBackGroundColor] [nvarchar](200) NULL," +
                             "[ProjectPriorityTextColor] [nvarchar](200) NULL," +
                             "[ProjectPriorityDescription] [nvarchar](max) NULL," +
                             "[ProjectPriorityPoints] [int] NOT NULL," +
                             "[IsDeleted] [bit] NULL," +
                             "[DeletedOn] [datetime] NULL," +
                             "[DeletedBy] [nvarchar](200) NULL," +
                             "[AddedOn] [datetime] NULL," +
                             "[AddedBy] [nvarchar](200) NULL," +
                             "[LastModifiedOn] [datetime] NULL," +
                             "[LastModifiedBy] [nvarchar](200) NULL," +
                             "CONSTRAINT [PK_" + tableName + "] PRIMARY KEY CLUSTERED" +
                             "(" +
                             "[Id] ASC" +
                             "))";
                string qry1 = "ALTER TABLE [dbo].[" + tableName + "] ADD  CONSTRAINT [DF_" + tableName + "_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]";
                string qry2 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_AddedBy] FOREIGN KEY([AddedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry3 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_AddedBy]";
                string qry4 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_DeletedBy] FOREIGN KEY([DeletedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry5 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_DeletedBy]";
                string qry6 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_LastModifiedBy] FOREIGN KEY([LastModifiedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry7 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_LastModifiedBy]";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                cmd.CommandText = qry1;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry2;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry3;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry4;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry5;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry6;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry7;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return tableName;
        }
        private string GenerateDynamicProjectTypeTableForUser(string userName)
        {
            string tableName = "PT_" + userName + "_ProjectType";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "CREATE TABLE [dbo].[" + tableName + "](" +
                             "[Id] [int] IDENTITY(1,1) NOT NULL," +
                             "[ProjectTypeName] [nvarchar](200) NOT NULL," +
                             "[ProjectTypeDescription] [nvarchar] (MAX)  NULL," +
                             "[IsDeleted] [bit] NULL," +
                             "[DeletedOn] [datetime] NULL," +
                             "[DeletedBy] [nvarchar](200) NULL," +
                             "[AddedOn] [datetime] NULL," +
                             "[AddedBy] [nvarchar](200) NULL," +
                             "[LastModifiedOn] [datetime] NULL," +
                             "[LastModifiedBy] [nvarchar](200) NULL," +
                             "CONSTRAINT [PK_" + tableName + "] PRIMARY KEY CLUSTERED" +
                             "(" +
                             "[Id] ASC" +
                             "))";
                string qry1 = "ALTER TABLE [dbo].[" + tableName + "] ADD  CONSTRAINT [DF_" + tableName + "_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]";
                string qry2 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_AddedBy] FOREIGN KEY([AddedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry3 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_AddedBy]";
                string qry4 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_DeletedBy] FOREIGN KEY([DeletedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry5 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_DeletedBy]";
                string qry6 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_UserInfo_LastModifiedBy] FOREIGN KEY([LastModifiedBy])" +
                              "REFERENCES[dbo].[UserInfo]([UserName])";
                string qry7 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_UserInfo_LastModifiedBy]";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                cmd.CommandText = qry1;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry2;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry3;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry4;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry5;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry6;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry7;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return tableName;
        }
        private string GenerateDynamicProjectTableForUser(string userName, string customerInfoTableName, string projectPriorityTableName, string projectStatusTableName, string projectTypeTableName)
        {
            string tableName = "PI_" + userName + "_ProjectInfo";
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "CREATE TABLE [dbo].[" + tableName + "](" +
                             "[Id] [int] IDENTITY(1,1) NOT NULL," +
                             "[ProjectName] [nvarchar](200) NOT NULL," +
                             "[ProjectDescription] [nvarchar](600) NULL," +
                             "[ProjectStatusId] [int] NOT NULL," +
                             "[ProjectClientCompany] [nvarchar](150) NULL," +
                             "[ProjectTypeId] [int]  NULL," +
                             "[ProjectPriorityId] [int]  NULL," +
                             "[ProjectSearchingKeywords] [nvarchar](max) NOT NULL," +
                             "[ProjectPath] [nvarchar](max) NULL," +
                             "[ProjectCustomerId] [nvarchar](200)  NULL," +
                             "[ProjectCountryCode] [nvarchar](50)  NULL," +
                             "[ProjectEstimatedBudget] [decimal](18, 3) NULL," +
                             "[ProjectTotalAmountSpent] [decimal](18, 3) NULL," +
                             "[ProjectEstimatedDuration] [int] NULL," +
                             "[ProjectReceivedDate] [date] NULL," +
                             "[ProjectDeliveredDate] [date] NULL," +
                             "[ProjectStartDate] [date] NULL," +
                             "[ProjectSubmitDate] [date] NULL," +
                             "[ProjectStartTime] [time](7) NULL," +
                             "[ProjectEndTime] [time](7) NULL," +
                             "[IsDeleted] [bit] NULL," +
                             "[DeletedOn] [datetime] NULL," +
                             "[DeletedBy] [nvarchar](200) NULL," +
                             "[AddedOn] [datetime] NULL," +
                             "[AddedBy] [nvarchar](200) NULL," +
                             "[LastModifiedOn] [datetime] NULL," +
                             "[LastModifiedBy] [nvarchar](200) NULL," +
                             "CONSTRAINT [PK_" + tableName + "] PRIMARY KEY CLUSTERED" +
                             "(" +
                             "[Id] ASC" +
                             "))";
                string qry1 = "ALTER TABLE [dbo].[" + tableName + "] ADD  CONSTRAINT [DF_" + tableName + "_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]";
                string qry2 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_" + customerInfoTableName + "_CustomerId] FOREIGN KEY([ProjectCustomerId])" +
                              "REFERENCES [dbo].[" + customerInfoTableName + "] ([UserName])";
                string qry3 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_" + customerInfoTableName + "_CustomerId]";
                string qry4 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_" + projectPriorityTableName + "_PriorityId] FOREIGN KEY([ProjectPriorityId])" +
                              "REFERENCES [dbo].[" + projectPriorityTableName + "] ([Id])";
                string qry5 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_" + projectPriorityTableName + "_PriorityId]";
                string qry6 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_" + projectStatusTableName + "_StatusId] FOREIGN KEY([ProjectStatusId])" +
                              "REFERENCES [dbo].[" + projectStatusTableName + "] ([Id])";
                string qry7 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_" + projectStatusTableName + "_StatusId]";
                string qry8 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_" + projectTypeTableName + "] FOREIGN KEY([ProjectPriorityId])" +
                              "REFERENCES [dbo].[" + projectTypeTableName + "] ([Id])";
                string qry9 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_" + projectTypeTableName + "]";
                string qry10 = "ALTER TABLE [dbo].[" + tableName + "]  WITH CHECK ADD  CONSTRAINT [FK_" + tableName + "_Country_CountryCode] FOREIGN KEY([CountryCode])" +
                               "REFERENCES [dbo].[Country] ([CountryCode])";
                string qry11 = "ALTER TABLE [dbo].[" + tableName + "] CHECK CONSTRAINT [FK_" + tableName + "_Country_CountryCode]";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                cmd.CommandText = qry1;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry2;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry3;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry4;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry5;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry6;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry7;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry8;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry9;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry10;
                cmd.ExecuteNonQuery();
                cmd.CommandText = qry11;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return tableName;
        }

     

        public void removeAllTables()
        {
            List<UserInfo> users = GetUserDataList();
            SqlConnection con = Utility.DBConnection.GetConnection();
            con.Open();
            foreach (UserInfo temp in users)
            {
                try
                {
                    string qry = "delete from CI_" + temp.UserName + "_CustomerInfo";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int effectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
                try
                {
                    string qry = "delete from CI_" + temp.UserName + "_CustomerInfo";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int effectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
                try
                {
                    string qry = "delete from PCMC_" + temp.UserName + "_Country_MapCount";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int effectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
                try
                {
                    string qry = "delete from PS_" + temp.UserName + "_ProjectStatus";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int effectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
                try
                {
                    string qry = "delete from CT_" + temp.UserName + "_CustomerType";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int effectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }



                try
                {
                    string qry = "delete from PI_" + temp.UserName + "_ProjectInfo";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int effectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }



                try
                {
                    string qry = "drop table CI_" + temp.UserName + "_CustomerInfo";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int effectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
                try
                {
                    string qry = "drop table PCMC_" + temp.UserName + "_Country_MapCount";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int effectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
                try
                {
                    string qry = "drop table PS_" + temp.UserName + "_ProjectStatus";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int effectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }
                try
                {
                    string qry = "drop table CT_" + temp.UserName + "_CustomerType";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int effectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }



                try
                {
                    string qry = "drop table PI_" + temp.UserName + "_ProjectInfo";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int effectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }

                try
                {
                    string qry = "drop table PT_" + temp.UserName + "_ProjectType";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int effectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }

                try
                {
                    string qry = "drop table PP_" + temp.UserName + "_ProjectPriority";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    int effectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                }

            }
            con.Close();

        }
        public UserInfo GetUserInfoDetail(string userName, string password)
        {
            UserInfo adminInfo = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from UserInfo where (UserName=@UserName or Email=@Email) and Password=@Password";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserName", userName);
                SqlParameter p2 = new SqlParameter("Email", userName);
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

                    adminInfo = new UserInfo(dr["UserName"].ToString(), dr["Email"].ToString(), dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(), int.Parse(dr["UserType"].ToString()),
                        dr["CountryCode"].ToString(), dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(), dr["Address"].ToString(), dr["ImagePath"].ToString(), bool.Parse(dr["IsDeleted"].ToString())
                         , dr["DeletedBy"].ToString(), deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);
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