using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class AdminInfoDAL
    {
        public bool CheckValidEmailAdminLoginCredentials(string userName, string password)
        {
            bool isValid = false;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from AdminInfo where ( UserName=? or Email=? ) and Password=?";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    isValid = true;
                    dr.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            return isValid;
        }


        public AdminInfo GetAdminInfoDetail(string userName,string password)
        {
            AdminInfo adminInfo = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * from AdminInfo where ( UserName=@UserName or Email=@Email ) and Password=@Password";
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
                    
                    adminInfo = new AdminInfo(dr["UserName"].ToString(), dr["Email"].ToString(), dr["Password"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(), dr["UserType"].ToString(),
                        dr["CountryCode"].ToString(), dr["ImagePath"].ToString(), dr["PhoneNumber"].ToString(), dr["MobileNumber"].ToString(), dr["Address"].ToString(), bool.Parse(dr["IsDeleted"].ToString())
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