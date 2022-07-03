using Newtonsoft.Json;
using PMS.DAL;
using PMS.DynamicBindingModels;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers.Common
{
    [Authorize]
    public class DailyExpenseManagementController : Controller
    {
        CustomerInfoDAL customerInfoDAL;
        DailyExpenseTypeDAL dailyExpenseTypeDAL;
        DailyExpenseManagementDAL dailyExpenseManagementDAL;
        // GET: DailyExpenseManagement

        public DailyExpenseManagementController()
        {
            dailyExpenseTypeDAL = new DailyExpenseTypeDAL();
            customerInfoDAL = new CustomerInfoDAL();
            dailyExpenseManagementDAL = new DailyExpenseManagementDAL();
        }
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult AddDailyExpense()
        {
            DailyExpense_Customer_ExpenseType_ForInsertion  dailyExpense_Customer_ExpenseType_ForInsertion = new DailyExpense_Customer_ExpenseType_ForInsertion();
            dailyExpense_Customer_ExpenseType_ForInsertion.CustomerInfoData = customerInfoDAL.GetCustomerDataListForDropdown(User.Identity.Name);

            dailyExpense_Customer_ExpenseType_ForInsertion.DailyExpenseTypeData = dailyExpenseTypeDAL.GetDailyExpenseTypeDataListForDropDown(User.Identity.Name);
            if (!dailyExpense_Customer_ExpenseType_ForInsertion.DailyExpenseTypeData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform daily expense insertion. Add Daily Expense Type to proceed for Daily Expense insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddDailyExpenseType", "DailyExpenseType");
            }

            return View(dailyExpense_Customer_ExpenseType_ForInsertion);

        }

        public JsonResult InsertDailyExpenseData(FormCollection formCollection)
        {
            //formdata.append("expensedate", _("expensedate").value);
            //formdata.append("customername", _("customername").value);
            //formdata.append("customertype", _("customertype").value);
            //formdata.append("expensetype", _("expensetype").value);
            //formdata.append("totalrowcount", t.data().length);

            //for (var counter = 0; counter < t.data().length; counter++)
            //{

            //    formdata.append("reason_" + counter, t.row(counter).data()[1]);
            //    formdata.append("price_" + counter, t.row(counter).data()[2]);
            //    formdata.append("note_" + counter, t.row(counter).data()[3]);
                string date = formCollection.Get("expensedate");
                string customername = formCollection.Get("customername");
            customername = customername.Trim().ToUpper();
                string customertype = formCollection.Get("customertype");
                int expensetype = int.Parse( formCollection.Get("expensetype"));
                int totalrowcount =  int.Parse( formCollection.Get("totalrowcount"));
            string reason = "";
            double price = 0;
            string note = "";
            double total = 0;
            List<DailyExpenseManagementItemDetails> dailyExpenseManagementItemDetails = new List<DailyExpenseManagementItemDetails>();
            for(int i=0;i<totalrowcount;i++)
            {
                 reason = formCollection.Get("reason_"+i);
                 price = double.Parse( formCollection.Get("price_"+i).ToUpper().Replace("₪", String.Empty));
                 note = formCollection.Get("note_"+i);
             
                dailyExpenseManagementItemDetails.Add(new DailyExpenseManagementItemDetails()
                {
                    DailyExpenseItemReason = reason,
                    DailyExpenseItemPrice = price,
                    DailyExpenseItemNote = note
                }) ;
                total += price;
            }
            DailyExpenseManagementOverview dailyExpenseManagementOverview = new DailyExpenseManagementOverview()
            {
                DailyExpenseCustomerName = customername,
                DailyExpenseDate = DateTime.Parse(date),
                DailyExpenseTotalPrice = total,
                DailyExpenseTypeId = expensetype,
                DailyExpenseCustomerType = customertype

            };
            String[] res = dailyExpenseManagementDAL.InsertDailyExpenseManagementOverviewData(dailyExpenseManagementOverview,
                dailyExpenseManagementItemDetails, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];


            var uniquenessResult = JsonConvert.SerializeObject(res[1], Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { uniquenessResult = uniquenessResult, JsonRequestBehavior.AllowGet });
        }

        public ActionResult DisplayAllDailyExpenseData()
        {
            List<DailyExpenseManagementOverview_DailyExpenseType_ForTableDisplay> dailyExpenseManagementOverview_DailyExpenseType_ForTableDisplays = dailyExpenseManagementDAL.GetDailyExpenseOverviewDataList(User.Identity.Name);
            return View(dailyExpenseManagementOverview_DailyExpenseType_ForTableDisplays);

        }

        public ActionResult DeleteDailyExpenseInfoData(int id)
        {
            string[] res = dailyExpenseManagementDAL.DeleteDailyExpenseOverviewData(id, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayAllDailyExpenseData");
        }


        public ActionResult ViewDailyExpenseSpecificDetail(int id)
        {
            DailyExpenseManagementOverView_Item_ForView dailyExpenseManagementOverView = new DailyExpenseManagementOverView_Item_ForView();
            dailyExpenseManagementOverView.DailyExpenseOverview =  dailyExpenseManagementDAL.GetDailyExpenseOverviewDataListById(id);
            if (dailyExpenseManagementOverView.DailyExpenseOverview == null)
            {
                TempData["ResultMessage"] = "Unable to perform Daily Expense View. Add Daily expense Info Data to proceed for Daily Expense View..";
                TempData["ResultMessageTitle"] = "View Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("DisplayAllDailyExpenseData");
            }
            dailyExpenseManagementOverView.DailyExpenseItemDetailsData = dailyExpenseManagementDAL.GetDailyExpenseItemDetailsByOverViewId(id);

            return View(dailyExpenseManagementOverView);
        }

        public ActionResult DisplayAllDailyExpenseDataByAdvanceFilter()
        {
            DailyExpenseManagementOverView_ExpenseType_ForTablelView_AdvanceFilter advanceFilter = new DailyExpenseManagementOverView_ExpenseType_ForTablelView_AdvanceFilter();

            advanceFilter.CustomerInfoData = customerInfoDAL.GetCustomerDataListForDropdown(User.Identity.Name);
            advanceFilter.DailyExpenseTypeData = dailyExpenseTypeDAL.GetDailyExpenseTypeDataListForDropDown(User.Identity.Name);
            advanceFilter.DailyExpenseOverview = dailyExpenseManagementDAL.GetDailyExpenseOverviewDataList(User.Identity.Name);
            return View(advanceFilter);
        }

        
        public ActionResult DisplayDailyExpenseDataByAfterFilter()
        {
          
                string customername = Request["customername"];
            string customertype = Request["customertype"];
            string expensetype = Request["expensetype"];
            string datesymbol = Request["datesymbol"];
            string fromdate = Request["fromdate"];
            string daterange = Request["daterange"];
            string amountsymbol = Request["amountsymbol"];
            string fromamount = Request["fromamount"];
            string toamount = Request["toamount"];
            DailyExpenseManagementOverView_ExpenseType_ForTablelView_AdvanceFilter advanceFilter = new DailyExpenseManagementOverView_ExpenseType_ForTablelView_AdvanceFilter();
           
            advanceFilter.CustomerInfoData = customerInfoDAL.GetCustomerDataListForDropdown(User.Identity.Name);
            advanceFilter.DailyExpenseTypeData = dailyExpenseTypeDAL.GetDailyExpenseTypeDataListForDropDown(User.Identity.Name);
            advanceFilter.DailyExpenseOverview = dailyExpenseManagementDAL.GetDailyExpenseOverviewDataListByAdvanceFilter(
                customername, customertype, expensetype, datesymbol, fromdate, daterange, amountsymbol, fromamount, toamount, User.Identity.Name
                );

            return View(advanceFilter);
        }

    }
}