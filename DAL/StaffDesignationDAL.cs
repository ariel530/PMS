using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class StaffDesignationDAL
    {
        public string[] InsertStaffDesignationData(string staffDesignationName, string staffDesignationDescription, int staffDesignationRank, string addedBy, int companyId)
        {
            //string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {

                string qry = "insert into " + tableName + " (StaffDesignationName,StaffDesignationDescription,StaffDesignationRank,AddedBy,AddedOn,CompanyId) values(@StaffDesignationName,@StaffDesignationDescription,@StaffDesignationRank,@addedBy,@addedOn,@CompanyId)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("StaffDesignationName", staffDesignationName);
                SqlParameter p2 = new SqlParameter("StaffDesignationDescription", staffDesignationDescription);
                SqlParameter p3 = new SqlParameter("StaffDesignationRank", staffDesignationRank);
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
                    result[0] = "StaffDesignation " + staffDesignationName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "StaffDesignation " + staffDesignationName + " does not added successfully.";
                result[1] = "fail";
                result[2] = "Insertion Failed !";
                con.Close();
            }

            return result;

        }
        public string[] UpdateStaffDesignationData(string staffDesignationName, string staffDesignationDescription, int staffDesignationRank, int id, string modifiedBy, string userName)
        {
            // string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update " + tableName + " Set StaffDesignationName =@StaffDesignationName,StaffDesignationDescription =@StaffDesignationDescription ,StaffDesignationRank=@StaffDesignationRank     ,LastModifiedOn=@lastModifiedOn ,LastModifiedBy = @lastModifiedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", id);
                SqlParameter p2 = new SqlParameter("StaffDesignationDescription", staffDesignationDescription);
                SqlParameter p3 = new SqlParameter("StaffDesignationName", staffDesignationName);
                SqlParameter p4 = new SqlParameter("lastModifiedBy", modifiedBy);
                SqlParameter p5 = new SqlParameter("lastModifiedOn", DateTime.Now);
                SqlParameter p6 = new SqlParameter("StaffDesignationRank", staffDesignationRank);
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
                    result[0] = "StaffDesignation " + staffDesignationName + " updated successfully.";
                    result[1] = "success";
                    result[2] = "Updated Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "StaffDesignation " + staffDesignationName + " does not updated successfully.";
                result[1] = "fail";
                result[2] = "Updation Failed !";
                con.Close();
            }

            return result;

        }
        public string[] DeleteStaffDesignationData(int userTypeId, string deletedBy, string userName)
        {
            // string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
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
                    result[0] = "StaffDesignation with Id " + userTypeId + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "StaffDesignation  with Id " + userTypeId + " does not deleted successfully.";
                result[1] = "fail";
                result[2] = "Deletion Failed !";
                con.Close();
            }

            return result;

        }
        public StaffDesignation GetStaffDesignationDataByStaffDesignationCode(int userTypeId, string userName)
        {
            // string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            StaffDesignation staffDesignation = null;
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

                    staffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString(),
             int.Parse(dr["StaffDesignationRank"].ToString()),        dr["StaffDesignationDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, int.Parse(dr["CompanyId"].ToString()));

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;

        }
        public List<StaffDesignation> GetStaffDesignationDataListForDropDown(string userName)
        {
            //  string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            List<StaffDesignation> staffDesignation = new List<StaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,StaffDesignationName from " + tableName + " where IsDeleted=0 and UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    StaffDesignation tempStaffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString());
                    staffDesignation.Add(tempStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;
        }
        public List<StaffDesignation> GetStaffDesignationDataListForDropDown(int companyId)
        {
            //  string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            List<StaffDesignation> staffDesignation = new List<StaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,StaffDesignationName from " + tableName + " where IsDeleted=0 and CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    StaffDesignation tempStaffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString());
                    staffDesignation.Add(tempStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;
        }
        public List<StaffDesignation> GetStaffDesignationDataListForDropDownAllIncludedDeleted(string userName)
        {
            //string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            List<StaffDesignation> staffDesignation = new List<StaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,StaffDesignationName from " + tableName + " where UserInfoUserName=@UserInfoUserName";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("UserInfoUserName", userName);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    StaffDesignation tempStaffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString());
                    staffDesignation.Add(tempStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;

        }
        public List<StaffDesignation> GetStaffDesignationDataListForDropDownAllIncludedDeleted(int companyId)
        {
            //string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            List<StaffDesignation> staffDesignation = new List<StaffDesignation>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select Id,StaffDesignationName from " + tableName + " where CompanyId=@CompanyId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    StaffDesignation tempStaffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString());
                    staffDesignation.Add(tempStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;

        }
        public List<StaffDesignation> GetStaffDesignationDataList(string userName)
        {
            // string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            List<StaffDesignation> staffDesignation = new List<StaffDesignation>();
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

                    StaffDesignation tempStaffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString(),
                int.Parse(dr["StaffDesignationRank"].ToString()), dr["StaffDesignationDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, int.Parse(dr["CompanyId"].ToString()));
                    staffDesignation.Add(tempStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;

        }
        public List<StaffDesignation> GetStaffDesignationDataList(int companyId)
        {
            // string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "StaffDesignation";
            List<StaffDesignation> staffDesignation = new List<StaffDesignation>();
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

                    StaffDesignation tempStaffDesignation = new StaffDesignation(int.Parse(dr["Id"].ToString()), dr["StaffDesignationName"].ToString(),
                  int.Parse(dr["StaffDesignationRank"].ToString()), dr["StaffDesignationDescription"].ToString(), (bool)dr["IsDeleted"], dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn, int.Parse(dr["CompanyId"].ToString()));
                    staffDesignation.Add(tempStaffDesignation);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return staffDesignation;

        }


        public Tuple<int, string> GetStaffDesignationInfoByStaffId(string staffId, int companyId)
        {
            //  string tableName = "PT_" + userName + "_StaffCategory";
            Tuple<int, string> staffList = null;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = " select StaffDesignation.Id,  StaffDesignation.StaffDesignationName"
 + " from StaffDesignation , StaffDetail "

   + "  where StaffDetail.IsDeleted = 0  "
 + "    and  StaffDetail.StaffInfoId =@StaffId "
 + "    and StaffDetail.StaffDesignationId = StaffDesignation.Id "
+ "and StaffDetail.CompanyId = @CompanyId  ";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                SqlParameter p2 = new SqlParameter("StaffId", staffId);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    staffList=(new Tuple<int, string>(int.Parse( dr["Id"].ToString()), dr["StaffDesignationName"].ToString()));
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



    }
}