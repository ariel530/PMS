using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class DailyExpenseManagementItemDetails
    {
        public int Id { get; set; }
        public string DailyExpenseItemReason { get; set; }
        public double DailyExpenseItemPrice { get; set; }
        public string DailyExpenseItemNote { get; set; }
        public int DailyExpenseOverviewId { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public DailyExpenseManagementItemDetails()
        {
        }

        public DailyExpenseManagementItemDetails(int id, string dailyExpenseItemReason, double dailyExpenseItemPrice, string dailyExpenseItemNote, int dailyExpenseOverviewId, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn)
        {
            Id = id;
            DailyExpenseItemReason = dailyExpenseItemReason;
            DailyExpenseItemPrice = dailyExpenseItemPrice;
            DailyExpenseItemNote = dailyExpenseItemNote;
            DailyExpenseOverviewId = dailyExpenseOverviewId;
            IsDeleted = isDeleted;
            DeletedBy = deletedBy;
            DeletedOn = deletedOn;
            AddedBy = addedBy;
            AddedOn = addedOn;
            LastModifiedBy = lastModifiedBy;
            LastModifiedOn = lastModifiedOn;
        }
    }
}