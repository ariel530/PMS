using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class DailyExpenseType
    {
        public int Id { get; set; }
        public string DailyExpenseTypeName { get; set; }
        public string DailyExpenseTypeDescription { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string UserInfoUserName { get; set; }

        public DailyExpenseType()
        {
        }

        public DailyExpenseType(int id, string dailyExpenseTypeName)
        {
            Id = id;
            DailyExpenseTypeName = dailyExpenseTypeName;
        }

        public DailyExpenseType(int id, string dailyExpenseTypeName, string dailyExpenseTypeDescription, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, string userInfoUserName)
        {
            Id = id;
            DailyExpenseTypeName = dailyExpenseTypeName;
            DailyExpenseTypeDescription = dailyExpenseTypeDescription;
            IsDeleted = isDeleted;
            DeletedBy = deletedBy;
            DeletedOn = deletedOn;
            AddedBy = addedBy;
            AddedOn = addedOn;
            LastModifiedBy = lastModifiedBy;
            LastModifiedOn = lastModifiedOn;
            UserInfoUserName = userInfoUserName;
        }
    }
}