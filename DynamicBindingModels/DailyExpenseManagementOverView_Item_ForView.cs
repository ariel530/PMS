using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class DailyExpenseManagementOverView_Item_ForView
    {
        public DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay DailyExpenseOverview { get; set; }
        public List<DailyExpenseManagementItemDetails> DailyExpenseItemDetailsData { get; set; }
    }
}