using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class DailyExpense_Customer_ExpenseType_ForInsertion
    {
        public List<CustomerInfo> CustomerInfoData { get; set; }
        public List<DailyExpenseType> DailyExpenseTypeData { get; set; }
    }
}