using PMS.DynamicBindingModels;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PMS.DAL
{
    public class CustomerUserMessageDAL
    {
        public bool InsertCustomerUserMessageData(string recieverName, string message,bool isOnline , string addedBy,string loginType)
        {
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {


                string qry = "";
                if (isOnline)
                {
                    qry = "insert into Customer_User_Messages (SenderUserName,RecieverUserName,ForGroupByQueryForUser,ForGroupByQueryForCustomer,Message,IsDelivered,DeliveredOn,AddedBy,AddedOn) values(@SenderUserName,@RecieverUserName,@ForGroupByQueryForUser,@ForGroupByQueryForCustomer,@Message,@IsDelivered,@DeliveredOn,@addedBy,@addedOn)";
                }
                else
                {
                    qry = "insert into Customer_User_Messages (SenderUserName,RecieverUserName,ForGroupByQueryForUser,ForGroupByQueryForCustomer,Message,AddedBy,AddedOn) values(@SenderUserName,@RecieverUserName,@ForGroupByQueryForUser,@ForGroupByQueryForCustomer,@Message,@addedBy,@addedOn)";

                }
                string forGroupByQueryForCustomer = "";
                string forGroupByQueryForUser = "";
                if(loginType.CompareTo("user")==0)
                {
                    forGroupByQueryForCustomer = addedBy;
                    forGroupByQueryForUser = recieverName;
                }
                else
                {
                    forGroupByQueryForCustomer =recieverName ;
                    forGroupByQueryForUser = addedBy;

                }


                SqlCommand cmd = new SqlCommand(qry, con);

                string dataForGroupBy = addedBy+"_"+recieverName;
                if(recieverName.CompareTo(addedBy)<=0)
                {
                    dataForGroupBy = recieverName + "_" + addedBy;
                }

                SqlParameter p1 = new SqlParameter("SenderUserName", addedBy);
                SqlParameter p2 = new SqlParameter("RecieverUserName", recieverName);
                SqlParameter p3 = new SqlParameter("Message", message);
                SqlParameter p4 = new SqlParameter("addedBy", addedBy);
                SqlParameter p5 = new SqlParameter("addedOn", DateTime.Now);
                SqlParameter p6 = new SqlParameter("ForGroupByQueryForUser", dataForGroupBy);
                SqlParameter p7 = new SqlParameter("ForGroupByQueryForCustomer", dataForGroupBy);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                if (isOnline)
                {
                    SqlParameter p8 = new SqlParameter("IsDelivered", isOnline);
                    SqlParameter p9 = new SqlParameter("DeliveredOn", DateTime.Now);
                    cmd.Parameters.Add(p8);
                    cmd.Parameters.Add(p9);
                }
               
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    con.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
            con.Close();

            return false;

        }

        public bool UpdateCustomerUserReadMessageData(string recieverName,string senderName)
        {
           SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update Customer_User_Messages Set IsRead=@IsRead , ReadOn = @ReadOn where SenderUserName =@SenderUserName and RecieverUserName = @RecieverUserName and IsRead = @NotRead";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("SenderUserName", senderName);
                SqlParameter p2 = new SqlParameter("RecieverUserName", recieverName);
                SqlParameter p3 = new SqlParameter("IsRead", true);
                SqlParameter p4 = new SqlParameter("ReadOn", DateTime.Now);
                SqlParameter p5 = new SqlParameter("NotRead", false);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
   
                con.Open();
                int effectedRows = cmd.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    con.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
            con.Close();

            return false;


        }



        public bool UpdateCustomerUserDeiverMessageData(string recieverName)
        {
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "Update Customer_User_Messages Set IsDelivered=@IsDelivered , DeliveredOn = @DeliveredOn where RecieverUserName = @RecieverUserName and IsDelivered = @NotDelivered";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("RecieverUserName", recieverName);
                SqlParameter p2 = new SqlParameter("IsDelivered", true);
                SqlParameter p3 = new SqlParameter("DeliveredOn", DateTime.Now);
                SqlParameter p4 = new SqlParameter("NotDelivered", false);
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
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
            con.Close();

            return false;


        }

        public List<Customer_User_Messages_Lists> GetCustomer_User_MessagesList(string parentUserName)
        {
            List<Customer_User_Messages_Lists> customer_User_Messages_Lists = new List<Customer_User_Messages_Lists>();
            //string customerTableName = "CI_"+parentUserName+"_CustomerInfo";
            string customerTableName = "CustomerInfo";
            SqlConnection con = Utility.DBConnection.GetConnection();

            try
            {
                string qry = "SELECT UserName as 'UserName', ImagePath as 'ImagePath', Customer_User_Messages.Message as 'LastMessage'" 
                            + " ,Customer_User_Messages.AddedOn as 'SendOn',Customer_User_Messages.IsRead as 'IsRead',"
                            + " Customer_User_Messages.IsDelivered as 'IsDelivered',Customer_User_Messages.AddedBy as 'SendBy',"
                            + " (select count(Customer_User_Messages.IsRead)"
                            + " from Customer_User_Messages"
                            + " where IsRead = 'false' and Customer_User_Messages.SenderUserName = UserName and Customer_User_Messages.RecieverUserName = @RecieverName) as 'UnReadMessages'"
                            + " FROM "+ customerTableName + " "
                            + " LEFT JOIN Customer_User_Messages ON "
                            + " (select iif(UserName < @ParentUserNameConcat1, CONCAT(UserName,'_',@ParentUserNameConcat2), CONCAT(@ParentUserNameConcat3,'_',UserName)))"
                            + " = Customer_User_Messages.ForGroupByQueryForCustomer"
                            + " and Customer_User_Messages.AddedOn in (select max(Customer_User_Messages.AddedOn) from Customer_User_Messages"
                            + " group by Customer_User_Messages.ForGroupByQueryForUser)"
                            + " where UserInfoUserName=@UserInfoUserName  "
                            + " order by Customer_User_Messages.AddedOn desc ";
                SqlCommand cmd = new SqlCommand(qry, con);
                //having Customer_User_Messages.RecieverUserName<> @ParentUserName
                SqlParameter p1 = new SqlParameter("ParentUserName", parentUserName);
                SqlParameter p2 = new SqlParameter("RecieverName", parentUserName);
                SqlParameter p3 = new SqlParameter("ParentUserNameConcat1", parentUserName);
                SqlParameter p4 = new SqlParameter("ParentUserNameConcat2", parentUserName);
                SqlParameter p5 = new SqlParameter("ParentUserNameConcat3", parentUserName);
                SqlParameter p6 = new SqlParameter("UserInfoUserName", parentUserName);
                
                cmd.Parameters.Add(p1); 
                cmd.Parameters.Add(p2); 
                cmd.Parameters.Add(p3); 
                cmd.Parameters.Add(p4); 
                cmd.Parameters.Add(p5); 
                cmd.Parameters.Add(p6); 
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    DateTime? sendOn = dr["SendOn"].ToString() == "" ? null : (DateTime?)dr["SendOn"];

                    bool isRead = dr["IsRead"].ToString() == "" ? false : (bool)dr["IsRead"];
                    bool isDelivered = dr["IsDelivered"].ToString() == "" ? false : (bool)dr["IsDelivered"];
                    Customer_User_Messages_Lists temp = new Customer_User_Messages_Lists(dr["UserName"].ToString(), dr["LastMessage"].ToString(), sendOn, dr["ImagePath"].ToString(), int.Parse(dr["UnReadMessages"].ToString()), isRead,isDelivered, dr["SendBy"].ToString());
                    customer_User_Messages_Lists.Add(temp);
                }
            }
            catch(Exception ex)
            {

            }
            con.Close();
            return customer_User_Messages_Lists;
        }


        public List<Customer_User_Messages_Lists> GetCustomer_User_MessagesListForCustomer(string parentUserName, string customerName)
        {
            List<Customer_User_Messages_Lists> customer_User_Messages_Lists = new List<Customer_User_Messages_Lists>();
            //string customerTableName = "CI_" + parentUserName + "_CustomerInfo";
            string customerTableName = "CustomerInfo";
            SqlConnection con = Utility.DBConnection.GetConnection();

            try
            {
                string qry = "SELECT UserName as 'UserName', ImagePath as 'ImagePath', Customer_User_Messages.Message as 'LastMessage'"
                            + " ,Customer_User_Messages.AddedOn as 'SendOn',Customer_User_Messages.IsRead as 'IsRead',"
                            + " Customer_User_Messages.IsDelivered as 'IsDelivered',Customer_User_Messages.AddedBy as 'SendBy',"
                            + " (select count(Customer_User_Messages.IsRead)"
                            + " from Customer_User_Messages"
                            + " where IsRead = 'false' and Customer_User_Messages.SenderUserName = UserName and Customer_User_Messages.RecieverUserName = @RecieverName) as 'UnReadMessages'"
                            + " FROM UserInfo "
                            + " LEFT JOIN Customer_User_Messages ON "
                            + " (select iif(UserName < @ParentUserNameConcat1, CONCAT(UserName,'_',@ParentUserNameConcat2), CONCAT(@ParentUserNameConcat3,'_',UserName)))"
                            + " = Customer_User_Messages.ForGroupByQueryForCustomer"
                            + " and Customer_User_Messages.AddedOn in (select max(Customer_User_Messages.AddedOn) from Customer_User_Messages"
                            + " group by Customer_User_Messages.ForGroupByQueryForUser)"
                            + " where UserName=@ParentUserName2"
                            + " order by Customer_User_Messages.AddedOn desc ";
                SqlCommand cmd = new SqlCommand(qry, con);
                //having Customer_User_Messages.RecieverUserName<> @ParentUserName
                SqlParameter p1 = new SqlParameter("ParentUserName", parentUserName);
                SqlParameter p2 = new SqlParameter("RecieverName", parentUserName);
                SqlParameter p3 = new SqlParameter("ParentUserNameConcat1", customerName);
                SqlParameter p4 = new SqlParameter("ParentUserNameConcat2", customerName);
                SqlParameter p5 = new SqlParameter("ParentUserNameConcat3", customerName);
                SqlParameter p6 = new SqlParameter("ParentUserName2", parentUserName);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DateTime? sendOn = dr["SendOn"].ToString() == "" ? null : (DateTime?)dr["SendOn"];

                    bool isRead = dr["IsRead"].ToString() == "" ? false : (bool)dr["IsRead"];
                    bool isDelivered = dr["IsDelivered"].ToString() == "" ? false : (bool)dr["IsDelivered"];
                    Customer_User_Messages_Lists temp = new Customer_User_Messages_Lists(dr["UserName"].ToString(), dr["LastMessage"].ToString(), sendOn, dr["ImagePath"].ToString(), int.Parse(dr["UnReadMessages"].ToString()), isRead, isDelivered, dr["SendBy"].ToString());
                    customer_User_Messages_Lists.Add(temp);
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return customer_User_Messages_Lists;
        }


        //public List<Customer_User_Messages_Lists> GetCustomer_User_MessagesListForCustomer(string parentUserName,string customerName)
        //{
        //    List<Customer_User_Messages_Lists> customer_User_Messages_Lists = new List<Customer_User_Messages_Lists>();
        //    SqlConnection con = Utility.DBConnection.GetConnection();

        //    try
        //    {
        //        string qry = "Select UserName,ImagePath, (Select TOP 1 Customer_User_Messages.Message from Customer_User_Messages "
        //                    + " where Customer_User_Messages.ForGroupByQueryForCustomer = @ParentUserName1 and Customer_User_Messages.ForGroupByQueryForUser = @UserName1 order by  Customer_User_Messages.AddedOn desc) as 'LastMessage', "
        //                    + " (Select TOP 1 Customer_User_Messages.AddedOn from Customer_User_Messages"
        //                    + " where  Customer_User_Messages.ForGroupByQueryForCustomer = @ParentUserName2 and Customer_User_Messages.ForGroupByQueryForUser = @UserName2 order by  Customer_User_Messages.AddedOn desc) as 'SendOn',"
        //                    + " (select count(Customer_User_Messages.IsRead)"
        //                    + " from Customer_User_Messages"
        //                    + " where IsRead = 'false' and Customer_User_Messages.SenderUserName = UserName and Customer_User_Messages.RecieverUserName = @CustomerName) as 'UnReadMessages'"
        //                    + " from UserInfo";





        //        SqlCommand cmd = new SqlCommand(qry, con);
        //        //having Customer_User_Messages.RecieverUserName<> @ParentUserName
        //        SqlParameter p1 = new SqlParameter("ParentUserName1", parentUserName);
        //        SqlParameter p2 = new SqlParameter("ParentUserName2", parentUserName);
        //        SqlParameter p3 = new SqlParameter("UserName1", customerName);
        //        SqlParameter p4 = new SqlParameter("UserName2", customerName);
        //        SqlParameter p5 = new SqlParameter("CustomerName", customerName);
        //        cmd.Parameters.Add(p1);
        //        cmd.Parameters.Add(p2);
        //        cmd.Parameters.Add(p3);
        //        cmd.Parameters.Add(p4);
        //        cmd.Parameters.Add(p5);
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            DateTime? sendOn = dr["SendOn"].ToString() == "" ? null : (DateTime?)dr["SendOn"];

        //            Customer_User_Messages_Lists temp = new Customer_User_Messages_Lists(dr["UserName"].ToString(), dr["LastMessage"].ToString(), sendOn, dr["ImagePath"].ToString(), int.Parse(dr["UnReadMessages"].ToString()));
        //            customer_User_Messages_Lists.Add(temp);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    con.Close();
        //    return customer_User_Messages_Lists;
        //}
        public List<CustomerUserMessages> GetAllMessagesByRecieverName(string recieverName ,string senderName)
        {
            List<CustomerUserMessages> customerUserMessages = new List<CustomerUserMessages>();
            SqlConnection con = Utility.DBConnection.GetConnection();
            try
            {
                string qry = "select SenderUserName,RecieverUserName,Message,AddedOn,IsDelivered,IsRead from Customer_User_Messages where IsDeleted=0 and (RecieverUserName=@RecieverUserName and SenderUserName=@SenderUserName) or (RecieverUserName=@RecieverUserName1 and SenderUserName=@SenderUserName1)";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlParameter p1 = new SqlParameter("RecieverUserName", recieverName);
                SqlParameter p2 = new SqlParameter("SenderUserName", senderName);
                SqlParameter p3 = new SqlParameter("RecieverUserName1", senderName);
                SqlParameter p4 = new SqlParameter("SenderUserName1", recieverName);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CustomerUserMessages temp = new CustomerUserMessages(dr["SenderUserName"].ToString(), dr["RecieverUserName"].ToString(), dr["Message"].ToString(), (DateTime?)dr["AddedOn"] , (bool)dr["IsDelivered"],(bool)dr["IsRead"]);
                    customerUserMessages.Add(temp);
                }
            }
            catch (Exception ex)
            {

            }
            con.Close();
            return customerUserMessages;
        }

        

    }


}