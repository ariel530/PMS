using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class DailyExpenseManagementOverView_ExpenseType_ForTablelView_AdvanceFilter
    {
        public List<DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay> DailyExpenseOverview { get; set; }
        public List<CustomerInfo> CustomerInfoData { get; set; }
        public List<DailyExpenseType> DailyExpenseTypeData { get; set; }

    }
}