using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class MessagesNotification
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string ImagePath { get; set; }

        public MessagesNotification()
        {

        }
        public MessagesNotification(int id, string userName, string message, bool isDeleted, string addedBy, DateTime? addedOn, string imagePath)
        {
            Id = id;
            UserName = userName;
            Message = message;
            IsDeleted = isDeleted;
            AddedBy = addedBy;
            AddedOn = addedOn;
            ImagePath = imagePath;
        }
    }
}