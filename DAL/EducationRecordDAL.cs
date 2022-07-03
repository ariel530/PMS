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
    public class EducationRecordDAL
    {
        public List<EducationRecord> GetEducationRecordDataListByUserName(string username,int companyId)
        {
            // string tableName = "PT_" + userName + "_StaffDesignation";
            string tableName = "EducationRecord";
            List<EducationRecord> educationRecords = new List<EducationRecord>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select degree,year from " + tableName + " where IsDeleted=0 and CompanyId=@CompanyId and UserId=@UserId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("CompanyId", companyId);
                SqlParameter p2 = new SqlParameter("UserId", username);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EducationRecord educationRecord = new EducationRecord(dr["degree"].ToString(), int.Parse( dr["year"].ToString()));
                    educationRecords.Add(educationRecord);
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return educationRecords;

        }
    }
}