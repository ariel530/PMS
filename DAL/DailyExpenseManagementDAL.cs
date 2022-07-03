using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.IO;
using System.Data;
using PMS.DynamicBindingModels;

namespace PMS.DAL
{
    public class DailyExpenseManagementDAL
    {
        public string[] InsertDailyExpenseManagementOverviewData(DailyExpenseManagementOverview dailyExpenseManagementOverview,List<DailyExpenseManagementItemDetails> dailyExpenseManagementItemDetails,  string addedBy)
        {
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                DateTime addedDateTime = DateTime.Now;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_DailyExpenseManagementOveriew_Insertion";
                cmd.Parameters.Add("@DailyExpenseDate", SqlDbType.Date).Value = dailyExpenseManagementOverview.DailyExpenseDate;
                cmd.Parameters.Add("@DailyExpenseCustomerName", SqlDbType.NVarChar).Value = dailyExpenseManagementOverview.DailyExpenseCustomerName;
                cmd.Parameters.Add("@DailyExpenseCustomerType", SqlDbType.NVarChar).Value = dailyExpenseManagementOverview.DailyExpenseCustomerType;
                cmd.Parameters.Add("@DailyExpenseTypeId", SqlDbType.Int).Value = dailyExpenseManagementOverview.DailyExpenseTypeId;
                cmd.Parameters.Add("@DailyExpenseTotalPrice", SqlDbType.Float).Value = dailyExpenseManagementOverview.DailyExpenseTotalPrice;
                cmd.Parameters.Add("@AddedOn", SqlDbType.DateTime).Value = addedDateTime;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = addedBy;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection = con;
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                int id = int.Parse(cmd.Parameters["@Id"].Value.ToString());
              
                con.Close();
                result = InsertDailyExpenseManagementItemDetailsData(dailyExpenseManagementItemDetails, id, addedBy, addedDateTime, dailyExpenseManagementOverview.DailyExpenseCustomerName);

            }
            catch (Exception ex)
            {
                result[0] = "Daily Expense Management For Customer " + dailyExpenseManagementOverview.DailyExpenseCustomerName + " does not added successfully.";
                result[1] = "fail";
                result[2] = "Insertion Failed !";
                con.Close();
            }

            return result;

        }
        public string[] InsertDailyExpenseManagementItemDetailsData(List<DailyExpenseManagementItemDetails> dailyExpenseManagementItemDetails, int dailyExpenseOveriewId, string addedBy, DateTime addedDatetime,string addedCustomerName)
        {
            //  string tableName = "CT_" + userName + "_CustomerType";
            string tableName = "DailyExpenseManagementItemDetails";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {

                string qry = "insert into " + tableName + " (DailyExpenseItemReason,DailyExpenseItemPrice,DailyExpenseItemNote,AddedBy,AddedOn,DailyExpenseOverviewId) " +
                                                    "values(@DailyExpenseItemReason,@DailyExpenseItemPrice,@DailyExpenseItemNote,@addedBy,@addedOn,@DailyExpenseOverviewId)";
                int effectedRows = 0;
                con.Open();
                foreach (DailyExpenseManagementItemDetails temp in dailyExpenseManagementItemDetails)
                {

                    SqlCommand cmd = new SqlCommand(qry, con);
                    SqlParameter p1 = new SqlParameter("DailyExpenseItemReason", temp.DailyExpenseItemReason);
                    SqlParameter p2 = new SqlParameter("DailyExpenseItemPrice", temp.DailyExpenseItemPrice);
                    SqlParameter p3 = new SqlParameter("DailyExpenseItemNote", temp.DailyExpenseItemNote);
                    SqlParameter p4 = new SqlParameter("addedBy", addedBy);
                    SqlParameter p5 = new SqlParameter("addedOn", addedDatetime);
                    SqlParameter p6 = new SqlParameter("DailyExpenseOverviewId", dailyExpenseOveriewId);
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);
                    cmd.Parameters.Add(p4);
                    cmd.Parameters.Add(p5);
                    cmd.Parameters.Add(p6);

                    effectedRows = cmd.ExecuteNonQuery();
                }
                if (effectedRows > 0)
                {
                    result[0] = "Daily Expense For Customer" + addedCustomerName + " added successfully.";
                    result[1] = "success";
                    result[2] = "Inserted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Daily Expense For Customer" + addedCustomerName + " does not added successfully.";
                result[1] = "fail";
                result[2] = "Insertion Failed !";
                con.Close();
            }

            return result;

        }
        public List<DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay> GetDailyExpenseOverviewDataList(string userName)
        {
            //string tableName = "CT_" + userName + "_CustomerType";
            string tableName1 = "DailyExpenseManagementOverview";
            string tableName2 = "DailyExpenseType";
            List<DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay> dailyExpenseManagementDetail = new List<DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * , DailyExpenseTypeName from " + tableName1 + " , "+tableName2+ "  where " + tableName1 + ".IsDeleted=0 and " + tableName1 + ".AddedBy=@Username and  " + tableName1+ ".DailyExpenseTypeId = "+tableName2+".Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlParameter p1 = new SqlParameter("Username", userName);
                cmd.Parameters.Add(p1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay dailyExpenseManagementOverview = new DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay(
                       int.Parse(dr["Id"].ToString()), DateTime.Parse(dr["DailyExpenseDate"].ToString()),
                       dr["DailyExpenseCustomerName"].ToString(), dr["DailyExpenseCustomerType"].ToString(),
                       dr["DailyExpenseTypeName"].ToString(), double.Parse(dr["DailyExpenseTotalPrice"].ToString()),
                     bool.Parse(dr["IsDeleted"].ToString()), dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);
                    dailyExpenseManagementDetail.Add(dailyExpenseManagementOverview);


                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return dailyExpenseManagementDetail;

        }
        public string[] DeleteDailyExpenseOverviewData(int dailyExpenseOverViewId, string deletedBy)
        {
            // string tableName = "CT_" + userName + "_CustomerType";
            string tableName = "DailyExpenseManagementOverview";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            DateTime deletedDateTime = DateTime.Now;
            try
            {
                string qry = "Update " + tableName + " Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where Id=@Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("Id", dailyExpenseOverViewId);
                SqlParameter p2 = new SqlParameter("deletedBy", deletedBy);
                SqlParameter p3 = new SqlParameter("deletedOn", deletedDateTime);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
               
                con.Close();
                result = DeleteDailyExpenseItemsDetailDataByOverviewId(dailyExpenseOverViewId, deletedBy);
            }
            catch (Exception ex)
            {
                result[0] = "Daily Expense  with Id " + dailyExpenseOverViewId + " does not deleted successfully.";
                result[1] = "fail";
                result[2] = "Deletion Failed !";
                con.Close();
            }

            return result;

        }
        public string[] DeleteDailyExpenseItemsDetailDataByOverviewId(int dailyExpenseOverViewId, string deletedBy)
        {
            // string tableName = "CT_" + userName + "_CustomerType";
            string tableName = "DailyExpenseManagementItemDetails";
            string[] result = new string[3];
            SqlConnection con = Utility.DBConnection.GetConnection();
            DateTime deletedDateTime = DateTime.Now;
            try
            {
                string qry = "Update " + tableName + " Set isDeleted =1 ,DeletedOn=@deletedOn ,DeletedBy = @deletedBy where DailyExpenseOverviewId=@DailyExpenseOverviewId";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("DailyExpenseOverviewId", dailyExpenseOverViewId);
                SqlParameter p2 = new SqlParameter("deletedBy", deletedBy);
                SqlParameter p3 = new SqlParameter("deletedOn", deletedDateTime);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    result[0] = "Daily Expense with Id " + dailyExpenseOverViewId + " deleted successfully.";
                    result[1] = "success";
                    result[2] = "Deleted Successfully !";
                }

                con.Close();

            }
            catch (Exception ex)
            {
                result[0] = "Daily Expense  with Id " + dailyExpenseOverViewId + " does not deleted successfully.";
                result[1] = "fail";
                result[2] = "Deletion Failed !";
                con.Close();
            }

            return result;

        }


         public DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay GetDailyExpenseOverviewDataListById(int overViewId)
        {
            //string tableName = "CT_" + userName + "_CustomerType";
            string tableName1 = "DailyExpenseManagementOverview";
            string tableName2 = "DailyExpenseType";
            DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay dailyExpenseManagementDetail = new DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * , DailyExpenseTypeName from " + tableName1 + " , "+tableName2+ "  where " + tableName1 + ".IsDeleted=0 and " + tableName1 + ".Id=@OverViewId and  " + tableName1+ ".DailyExpenseTypeId = "+tableName2+".Id";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlParameter p1 = new SqlParameter("OverViewId", overViewId);
                cmd.Parameters.Add(p1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                     dailyExpenseManagementDetail = new DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay(
                       int.Parse(dr["Id"].ToString()), DateTime.Parse(dr["DailyExpenseDate"].ToString()),
                       dr["DailyExpenseCustomerName"].ToString(), dr["DailyExpenseCustomerType"].ToString(),
                       dr["DailyExpenseTypeName"].ToString(), double.Parse(dr["DailyExpenseTotalPrice"].ToString()),
                     bool.Parse(dr["IsDeleted"].ToString()), dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);
                  

                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return dailyExpenseManagementDetail;

        }

        public List<DailyExpenseManagementItemDetails> GetDailyExpenseItemDetailsByOverViewId(int overViewId)
        {
            //string tableName = "CT_" + userName + "_CustomerType";
            string tableName1 = "DailyExpenseManagementItemDetails";
            List<DailyExpenseManagementItemDetails> dailyExpenseManagementItemDetails = new List<DailyExpenseManagementItemDetails>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select *  from " + tableName1 + "   where IsDeleted=0 and DailyExpenseOverviewId=@DailyExpenseOverviewId ";
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                SqlParameter p1 = new SqlParameter("DailyExpenseOverviewId", overViewId);
                cmd.Parameters.Add(p1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    DailyExpenseManagementItemDetails tempDailyExpenseManagementItemDetails = new DailyExpenseManagementItemDetails(
                       int.Parse(dr["Id"].ToString()),
                       dr["DailyExpenseItemReason"].ToString(), double.Parse(dr["DailyExpenseItemPrice"].ToString()),
                       dr["DailyExpenseItemNote"].ToString(),
                     int.Parse(  dr["DailyExpenseOverviewId"].ToString()), 
                     bool.Parse(dr["IsDeleted"].ToString()), dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);
                    dailyExpenseManagementItemDetails.Add(tempDailyExpenseManagementItemDetails);


                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return dailyExpenseManagementItemDetails;

        }
       
  public List<DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay> GetDailyExpenseOverviewDataListByAdvanceFilter(
           string customername, string customertype, string expensetype, string datesymbol, string fromdate, string daterange,
        string amountsymbol, string fromamount, string toamount,  string userName)
        {
            //string tableName = "CT_" + userName + "_CustomerType";
            string tableName1 = "DailyExpenseManagementOverview";
            string tableName2 = "DailyExpenseType";
            List<DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay> dailyExpenseManagementDetail = new List<DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select * , DailyExpenseTypeName from " + tableName1 + " , " + tableName2 + "  where " + tableName1 + ".IsDeleted=0 and " + tableName1 + ".AddedBy=@Username and  " + tableName1 + ".DailyExpenseTypeId = " + tableName2 + ".Id ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (customername.Trim().CompareTo("--")!=0)
                {
                    qry += " and DailyExpenseCustomerName = @DailyExpenseCustomerName ";
                    cmd.Parameters.AddWithValue("DailyExpenseCustomerName", customername.ToUpper());
                }
                if(customertype.CompareTo("")!=0)
                {
                    qry += " and DailyExpenseCustomerType = @DailyExpenseCustomerType ";
                    cmd.Parameters.AddWithValue("DailyExpenseCustomerType", customertype);
                }
                if(expensetype.CompareTo("")!=0)
                {
                    qry += " and DailyExpenseTypeId = @DailyExpenseType ";
                    cmd.Parameters.AddWithValue("DailyExpenseType", int.Parse(expensetype));
                }

                if (fromdate.CompareTo("") != 0)
                {
                    DateTime tempFromDate = DateTime.Parse(fromdate);
                    qry += " and DailyExpenseDate "+datesymbol+" @DailyExpenseDate ";

                    //cmd.Parameters.AddWithValue("datesymbol", datesymbol);
                    cmd.Parameters.AddWithValue("DailyExpenseDate", tempFromDate);
                }
                else
                {
                    DateTime startDateRange = DateTime.Parse(daterange.Split('-')[0]);
                    DateTime endDateRange = DateTime.Parse(daterange.Split('-')[1]);
                    if (startDateRange != endDateRange)
                    {
                        qry += " and DailyExpenseDate >= @startExpenseDate and  DailyExpenseDate<= @endExpenseDate";
                        cmd.Parameters.AddWithValue("startExpenseDate", startDateRange);
                        cmd.Parameters.AddWithValue("endExpenseDate", endDateRange);
                    }
                }

                if (fromamount.CompareTo("") != 0)
                {
                    double tempFromAmount = double.Parse(fromamount.ToUpper().Replace("RS", String.Empty));
                    double tempToAmount = 0;
                    if (toamount.CompareTo("") != 0)
                    {
                        tempToAmount = double.Parse(toamount.ToUpper().Replace("RS", String.Empty));
                        qry += " and DailyExpenseTotalPrice >= @tempFromAmount and  DailyExpenseTotalPrice<= @tempToAmount";
                        if (tempFromAmount <= tempToAmount)
                        {
                            cmd.Parameters.AddWithValue("tempFromAmount", tempFromAmount);
                            cmd.Parameters.AddWithValue("tempToAmount", tempToAmount);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("tempFromAmount", tempToAmount);
                            cmd.Parameters.AddWithValue("tempToAmount", tempFromAmount);
                        }
                    }
                    else
                    {
                        qry += " and DailyExpenseTotalPrice "+amountsymbol +" @tempFromAmount ";

                        //cmd.Parameters.AddWithValue("amountsymbol", amountsymbol);
                        cmd.Parameters.AddWithValue("tempFromAmount", tempFromAmount);
                    }
                }
                else if (toamount.CompareTo("") != 0)
                {
                    double tempToAmount = double.Parse(toamount.ToUpper().Replace("RS", String.Empty));

                    qry += " and DailyExpenseTotalPrice <=  @tempToAmount ";
                    cmd.Parameters.AddWithValue("tempFromAmount", tempToAmount);
                }

                cmd.CommandText = qry;

                 con.Open();
                SqlParameter p1 = new SqlParameter("Username", userName);
                cmd.Parameters.Add(p1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? deletedOn = dr["DeletedOn"].ToString() == "" ? null : (DateTime?)dr["DeletedOn"];
                    DateTime? addedOn = dr["addedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];
                    DateTime? lastModifiedOn = dr["lastModifiedOn"].ToString() == "" ? null : (DateTime?)dr["lastModifiedOn"];

                    DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay dailyExpenseManagementOverview = new DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay(
                       int.Parse(dr["Id"].ToString()), DateTime.Parse(dr["DailyExpenseDate"].ToString()),
                       dr["DailyExpenseCustomerName"].ToString(), dr["DailyExpenseCustomerType"].ToString(),
                       dr["DailyExpenseTypeName"].ToString(), double.Parse(dr["DailyExpenseTotalPrice"].ToString()),
                     bool.Parse(dr["IsDeleted"].ToString()), dr["DeletedBy"].ToString()
                   , deletedOn, dr["AddedBy"].ToString(), addedOn, dr["LastModifiedBy"].ToString(), lastModifiedOn);
                    dailyExpenseManagementDetail.Add(dailyExpenseManagementOverview);


                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return dailyExpenseManagementDetail;

        }


    }
}