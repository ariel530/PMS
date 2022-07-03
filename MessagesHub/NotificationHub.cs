using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PMS.MessagesHub
{
    public class NotificationHub : Hub
    {
        public  void ShowMessageNotications()
        {
            Clients.All.displayMessagesNotification();
        }
    }
}