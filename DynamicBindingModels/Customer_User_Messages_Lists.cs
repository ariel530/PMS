using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class Customer_User_Messages_Lists
    {
        public string UserName { get; set; }
        public string LastMessage { get; set; }
        public DateTime? SendOn { get; set; }
        public string ImagePath { get; set; }
        public int UnReadMessages { get; set; }
       public bool IsRead { get; set; }
        public bool IsDelivered { get; set; }
        public string SendBy { get; set; }
        

        public Customer_User_Messages_Lists()
        {

        }

        public Customer_User_Messages_Lists(string userName, string lastMessage, DateTime? sendOn, string imagePath, int unReadMessages)
        {
            UserName = userName;
            LastMessage = lastMessage;
            SendOn = sendOn;
            ImagePath = imagePath;
            UnReadMessages = unReadMessages;
        }

        public Customer_User_Messages_Lists(string userName, string lastMessage, DateTime? sendOn, string imagePath, int unReadMessages, bool isRead, bool isDelivered, string sendBy) : this(userName, lastMessage, sendOn, imagePath, unReadMessages)
        {
            IsRead = isRead;
            IsDelivered = isDelivered;
            SendBy = sendBy;
        }
    }
}