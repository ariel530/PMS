using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMS.Models;
using System.Data.SqlClient;
using PMS.MessagesHub;

namespace PMS.DAL
{
    public class NotificationsDAL
    {
        public List<MessagesNotification> GetMessagesNotification(string currentUserName)
        {
            //string currentUserName = (string)HttpContext.Current.Session["UserName"];
            string tableName = "CI_" + currentUserName + "_CustomerInfo";
            List<MessagesNotification> messagesNotification = new List<MessagesNotification>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "SELECT  top 5 Customer_User_Messages.Id,SenderUserName,Message,Customer_User_Messages.IsDeleted,Customer_User_Messages.AddedBy,Customer_User_Messages.AddedOn"
                             + " , " + tableName + ".ImagePath FROM Customer_User_Messages, " + tableName
                             + " where   Customer_User_Messages.IsRead=0 and RecieverUserName=@RecieverUserName  and Customer_User_Messages.SenderUserName = " + tableName + ".UserName "
                             + "  order by id desc";


//                string qry = "SELECT  top 5 Customer_User_Messages.Id,SenderUserName,Message FROM Customer_User_Messages";

                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("RecieverUserName", currentUserName);
                cmd.Parameters.Add(p1); 
               // cmd.Notification = null;
              //  SqlDependency messagesNotificationDependency = new SqlDependency(cmd);
              //  messagesNotificationDependency.OnChange += new OnChangeEventHandler(newMessageNotification);
                con.Open();
               // cmd.ExecuteReader();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? addedOn = dr["AddedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];

                    MessagesNotification tempMessagesNotification = new MessagesNotification(int.Parse(dr["Id"].ToString()), dr["SenderUserName"].ToString(),
                        dr["Message"].ToString(), (bool)dr["IsDeleted"], dr["AddedBy"].ToString()
                   , addedOn, dr["ImagePath"].ToString());
                    messagesNotification.Add(tempMessagesNotification);
                    //MessagesNotification tempMessagesNotification = new MessagesNotification()
                    //{
                    //    Id = int.Parse(dr["Id"].ToString()),

                    //    Message = dr["Message"].ToString()
                    //};
                }
                dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return messagesNotification;

        }

        public int GetUnReadMessagesCount(string currentUserName)
        {
            //string currentUserName = (string)HttpContext.Current.Session["UserName"];
            string tableName = "CI_" + currentUserName + "_CustomerInfo";
            int totalRows = 0;
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "SELECT  count(Customer_User_Messages.Id)" +
                                " from Customer_User_Messages "
                             + " where   Customer_User_Messages.IsRead=0 and RecieverUserName=@RecieverUserName  ";
                           


                //                string qry = "SELECT  top 5 Customer_User_Messages.Id,SenderUserName,Message FROM Customer_User_Messages";

                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("RecieverUserName", currentUserName);
                cmd.Parameters.Add(p1);
                // cmd.Notification = null;
                //  SqlDependency messagesNotificationDependency = new SqlDependency(cmd);
                //  messagesNotificationDependency.OnChange += new OnChangeEventHandler(newMessageNotification);
                con.Open();
                // cmd.ExecuteReader();
                totalRows =(int) cmd.ExecuteScalar();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

            return totalRows;

        }


        public void GetMessagesNotification()
        {
            //string currentUserName = (string)HttpContext.Current.Session["UserName"];
            //string tableName = "CI_" + currentUserName + "_CustomerInfo";
            //List<MessagesNotification> messagesNotification = new List<MessagesNotification>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                //string qry = "SELECT  top 5 Customer_User_Messages.Id,SenderUserName,Message,Customer_User_Messages.IsDeleted,Customer_User_Messages.AddedBy,Customer_User_Messages.AddedOn"
                //             + " , " + tableName + ".ImagePath FROM Customer_User_Messages, " + tableName 
                //             + " where   Customer_User_Messages.IsRead=1 and RecieverUserName=@RecieverUserName  and Customer_User_Messages.SenderUserName = " + tableName+".UserName "
                //             + "  order by id desc";


                string qry = "SELECT  top 5 Customer_User_Messages.Id,SenderUserName,Message FROM Customer_User_Messages";

                SqlCommand cmd = new SqlCommand(qry, con);
                //SqlParameter p1 = new SqlParameter("RecieverUserName", currentUserName);
                //cmd.Parameters.Add(p1); ;
                cmd.Notification = null;
                SqlDependency messagesNotificationDependency = new SqlDependency(cmd);
                messagesNotificationDependency.OnChange += new OnChangeEventHandler(newMessageNotification);
                con.Open();
                cmd.ExecuteReader();
                //SqlDataReader dr = cmd.ExecuteReader();
                //while (dr.Read())
                //{
                //    // DateTime? addedOn = dr["AddedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];

                //    // MessagesNotification tempMessagesNotification = new MessagesNotification(int.Parse(dr["Id"].ToString()), dr["SenderUserName"].ToString(),
                //    //     dr["Message"].ToString(), (bool)dr["IsDeleted"], dr["AddedBy"].ToString()
                //    //, addedOn, dr["ImagePath"].ToString());
                //    // messagesNotification.Add(tempMessagesNotification);
                //    MessagesNotification tempMessagesNotification = new MessagesNotification()
                //    {
                //        Id = int.Parse(dr["Id"].ToString()),

                //        Message = dr["Message"].ToString()
                //    };
                //}
                //dr.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }

        }

        private void newMessageNotification(object sender, SqlNotificationEventArgs e)
        {
           //// string currentUserName = (string)HttpContext.Current.Session["UserName"];
           // string currentUserName = Utility.DBConnection.userName;
           // string tableName = "CI_" + currentUserName + "_CustomerInfo";

           // List<MessagesNotification> messagesNotification = new List<MessagesNotification>();
           // SqlConnection con = Utility.DBConnection.GetConnection();
           // try
           // {
           //     string qry = "SELECT  top 5 Customer_User_Messages.Id,SenderUserName,Message,Customer_User_Messages.IsDeleted,Customer_User_Messages.AddedBy,Customer_User_Messages.AddedOn"
           //                  + " , " + tableName + ".ImagePath FROM Customer_User_Messages, " + tableName
           //                  + " where   Customer_User_Messages.IsRead=1 and RecieverUserName=@RecieverUserName  and Customer_User_Messages.SenderUserName = " + tableName + ".UserName "
           //                  + "  order by id desc";


               
           //     SqlCommand cmd = new SqlCommand(qry, con);
           //     //SqlParameter p1 = new SqlParameter("RecieverUserName", currentUserName);
           //     //cmd.Parameters.Add(p1); ;
           //     con.Open();
           //     cmd.ExecuteReader();
           //     SqlDataReader dr = cmd.ExecuteReader();
           //     while (dr.Read())
           //     {
           //         DateTime? addedOn = dr["AddedOn"].ToString() == "" ? null : (DateTime?)dr["addedOn"];

           //         MessagesNotification tempMessagesNotification = new MessagesNotification(int.Parse(dr["Id"].ToString()), dr["SenderUserName"].ToString(),
           //             dr["Message"].ToString(), (bool)dr["IsDeleted"], dr["AddedBy"].ToString()
           //        , addedOn, dr["ImagePath"].ToString());
           //         messagesNotification.Add(tempMessagesNotification);

           //     }
           //     dr.Close();
           //     con.Close();

           // }
           // catch (Exception ex)
           // {
           //     con.Close();
           // }


//            MessageUserHub.ShowMessageNotications(messagesNotification);
            MessageUserHub.ShowMessageNotications();

//            GetMessagesNotification();

        }
    }
}