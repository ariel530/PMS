using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class UserTypeDAL
    {
        public string[] InsertUserTypeData(string userTypeName, string addedBy)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "insert into UserType (UserTypeName,AddedBy,AddedOn) values(@UserTypeName,@addedBy,@addedOn)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserTypeName", userTypeName);
                SqlParameter p2 = new SqlParameter("addedBy", addedBy);
                SqlParameter p3 = new SqlParameter("addedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "UserType " + userTypeName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "UserType " + userTypeName + " does not added successfully.";
                result[1] = "fail";
                result[2] = "Insertion Failed !";
                con.Close();
            }

            return result;

        }



        public string[] UpdateUserTypeData(string userTypeName, int id, string modifiedBy)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update UserType Set UserTypeName =@UserTypeName ,LastModifiedOn=@lastModifiedOn ,LastModifiedBy = @lastModifiedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", id);
                SqlParameter p2 = new SqlParameter("UserTypeName", userTypeName);
                SqlParameter p3 = new SqlParameter("lastModifiedBy", modifiedBy);
                SqlParameter p4 = new SqlParameter("lastModifiedOn", DateTime.Now);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "UserType " + userTypeName +  " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "UserType " + userTypeName +  " does not updated successfully.";
                result[1] = "fail";
                result[2] = "Updation Failed !";
                con.Close();
            }

            return result;

        }



        public string[] DeleteUserTypeData(int userTypeId, string deletedBy)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update UserType Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where Id=@Id";
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
                    result[0] = "UserType with Id " + userTypeId + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "UserType  with Id " + userTypeId + " does not deleted successfully.";
                result[1] = "fail";
                result[2] = "Deletion Failed !";
                con.Close();
            }

            return result;

        }


        public UserType GetUserTypeDataByUserTypeCode(int userTypeId)
        {
            UserType UserType = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from UserType where Id=@Id and IsDeleted=0";
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

                    UserType = new UserType(int.Parse(dr["Id"].ToString()), dr["UserTypeName"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return UserType;

        }


        public List<UserType> GetUserTypeDataListForDropDown()
        {
            List<UserType> UserType = new List<UserType>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,UserTypeName from UserType where IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
            

                    UserType tempUserType = new UserType(int.Parse(dr["Id"].ToString()), dr["UserTypeName"].ToString());
                    UserType.Add(tempUserType);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return UserType;

        }

        public List<UserType> GetUserTypeDataListForDropDownAllIncludedDeleted()
        {
            List<UserType> UserType = new List<UserType>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,UserTypeName from UserType";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    UserType tempUserType = new UserType(int.Parse(dr["Id"].ToString()), dr["UserTypeName"].ToString());
                    UserType.Add(tempUserType);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return UserType;

        }





        public List<UserType> GetUserTypeDataList()
        {
            List<UserType> UserType = new List<UserType>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from UserType where IsDeleted=0";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    UserType tempUserType   = new UserType(int.Parse(dr["Id"].ToString()), dr["UserTypeName"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);
                    UserType.Add(tempUserType);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return UserType;

        }

    }
}