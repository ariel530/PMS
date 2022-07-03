using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using PMS.DAL;
using PMS.Models;
namespace PMS.MessagesHub
{
    public class MessageUserHub : Hub
    {
        public static HashSet<string> onlineUsersName = new HashSet<string>();

        public void UserCustomerMessage(string recieverUserName, string message)
        {
            bool isOnline = false;
            
            if(onlineUsersName.Contains(recieverUserName))
            {
                isOnline = true;
            }

            new CustomerUserMessageDAL().InsertCustomerUserMessageData(recieverUserName, message, isOnline, Context.User.Identity.Name, "user");
            DateTime currentDateTime = DateTime.Now;
            Clients.User(recieverUserName).addNewRecieverMessageToPage(Context.User.Identity.Name, recieverUserName, message, currentDateTime.ToString());
            Clients.User(Context.User.Identity.Name).addNewSenderMessageToPage(Context.User.Identity.Name, recieverUserName, message, currentDateTime.ToString(), isOnline);
                
        }


        public void MakeMessageAsRead(string recieverName, string senderUserName)
        {

            new CustomerUserMessageDAL().UpdateCustomerUserReadMessageData(recieverName, senderUserName);
            Clients.User(senderUserName).makeMessageRead(recieverName);

        }

        public void GetUserMessagesForClient(string userName)
        {
            bool isOnline = false;

            if (onlineUsersName.Contains(userName))
            {
                isOnline = true;
            }
            new CustomerUserMessageDAL().UpdateCustomerUserReadMessageData(Context.User.Identity.Name,userName);
            List<CustomerUserMessages> customerUserMessages = new CustomerUserMessageDAL().GetAllMessagesByRecieverName(userName, Context.User.Identity.Name);
            Clients.User(userName).makeMessageRead(Context.User.Identity.Name);
            Clients.User(Context.User.Identity.Name).addMessageForUser(customerUserMessages , isOnline);
        }

        public void SendTypingMessageRequest(string typerName)
        {
            Clients.User(typerName).AddTypingMessageRequest(Context.User.Identity.Name);

        }

        public void Hello()
        {
            Clients.All.hello();
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            onlineUsersName.Remove(Context.User.Identity.Name);
            Clients.AllExcept(Context.User.Identity.Name).goOffline(Context.User.Identity.Name);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnConnected()
        {
            new CustomerUserMessageDAL().UpdateCustomerUserDeiverMessageData(Context.User.Identity.Name);
            onlineUsersName.Add(Context.User.Identity.Name);
            Clients.AllExcept(Context.User.Identity.Name).goOnline(Context.User.Identity.Name);
            Clients.User(Context.User.Identity.Name).updateAllOnlineUserStatus(onlineUsersName.ToList());
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            onlineUsersName.Remove(Context.User.Identity.Name);
            Clients.AllExcept(Context.User.Identity.Name).goOffline(Context.User.Identity.Name);
            return base.OnReconnected();
        }





        //public static void ShowMessageNotications(List<MessagesNotification> messagesNotifications)
        //{
        //    IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessageUserHub>();
        //    context.Clients.All.displayMessagesNotification(messagesNotifications);
        //}
        public static void ShowMessageNotications()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessageUserHub>();
           // context.
            context.Clients.User("ASLAM").displayMessagesNotification();
        }




    }
}