using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay
    {
        public int Id { get; set; }
        public DateTime DailyExpenseDate { get; set; }
        public string DailyExpenseCustomerName { get; set; }
        public string DailyExpenseCustomerType { get; set; }
        public string DailyExpenseTypeName { get; set; }
        public double DailyExpenseTotalPrice { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay()
        {
        }

        public DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay(int id, DateTime dailyExpenseDate, string dailyExpenseCustomerName, string dailyExpenseCustomerType, string dailyExpenseTypeName, double dailyExpenseTotalPrice, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn)
        {
            Id = id;
            DailyExpenseDate = dailyExpenseDate;
            DailyExpenseCustomerName = dailyExpenseCustomerName;
            DailyExpenseCustomerType = dailyExpenseCustomerType;
            DailyExpenseTypeName = dailyExpenseTypeName;
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