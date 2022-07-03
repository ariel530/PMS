using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PMS.MessagesHub
{
    public class ChatHub : Hub
    {
        public void send(string recieverUserName,string message)
        {
            
            Clients.User(recieverUserName).addNewRecieverMessageToPage(recieverUserName, message,DateTime.Now);
            Clients.User(Context.User.Identity.Name).addNewSenderMessageToPage(Context.User.Identity.Name, message, DateTime.Now);
        }
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}