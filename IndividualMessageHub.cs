using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PMS
{
    public class IndividualMessageHub : Hub
    {
        public void SendCustomerUserMessage(string recieverUserName,string message)
        {
            Clients.User(recieverUserName).addNewMessageToPage(recieverUserName, message);
            Clients.User(Context.User.Identity.Name).addNewMessageToPage(recieverUserName, message);

        }
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}