using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class DailyExpenseManagementOverview
    {
        public int Id { get; set; }
        public DateTime DailyExpenseDate { get; set; }
        public string DailyExpenseCustomerName { get; set; }
        public string DailyExpenseCustomerType { get; set; }
        public int DailyExpenseTypeId { get; set; }
        public double DailyExpenseTotalPrice { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public DailyExpenseManagementOverview()
        {
        }

        public DailyExpenseManagementOverview(int id, DateTime dailyExpenseDate, string dailyExpenseCustomerName, string dailyExpenseCustomerType, int dailyExpenseTypeId, double dailyExpenseTotalPrice, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn)
        {
            Id = id;
            DailyExpenseDate = dailyExpenseDate;
            DailyExpenseCustomerName = dailyExpenseCustomerName;
            DailyExpenseCustomerType = dailyExpenseCustomerType;
            DailyExpenseTypeId = dailyExpenseTypeId;
            DailyExpenseTotalPrice = dailyExpenseTotalPrice;
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