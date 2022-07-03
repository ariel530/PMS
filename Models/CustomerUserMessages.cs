using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class CustomerUserMessages
    {
        public Int64 Id { get; set; }
        public string SenderUserName { get; set; }
        public string RecieverUserName { get; set; }
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime? DeliveredOn { get; set; }
        public bool  IsRead { get; set; }
        public DateTime? ReadOn { get; set; }

        public  string AddedOnDateInString { get; set; }
        public CustomerUserMessages()
        {
        }

        public CustomerUserMessages(string senderUserName, string recieverUserName, string message, DateTime? addedOn, bool isDelivered, bool isRead)
        {
            SenderUserName = senderUserName;
            RecieverUserName = recieverUserName;
            Message = message;
            AddedOn = addedOn;
            IsDelivered = isDelivered;
            IsRead = isRead;
            AddedOnDateInString = addedOn.ToString();
        }

        public CustomerUserMessages(long id, string senderUserName, string recieverUserName,string message, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, bool isDelivered, DateTime? deliveredOn, bool isRead, DateTime? readOn)
        {
            Id = id;
            SenderUserName = senderUserName;
            RecieverUserName = recieverUserName;
            Message = message;
            IsDeleted = isDeleted;
            DeletedBy = deletedBy;
            DeletedOn = deletedOn;
            AddedBy = addedBy;
            AddedOn = addedOn;
            LastModifiedBy = lastModifiedBy;
            LastModifiedOn = lastModifiedOn;
            IsDelivered = isDelivered;
            DeliveredOn = deliveredOn;
            IsRead = isRead;
            ReadOn = readOn;
            AddedOnDateInString = addedOn.ToString();
        }
    }
}