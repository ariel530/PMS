using Newtonsoft.Json;
using PMS.DAL;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class CountryController : Controller
    {
        CountryDAL countryDAL;
        public CountryController()
        {
           countryDAL = new CountryDAL();
        }

        // GET: Country
        public ActionResult Index()
        {
          //  countryDAL.AddAllCountriesToDatabase(User.Identity.Name);
            return RedirectToAction("DisplayCountry");
        }

        [Authorize]
        public ActionResult AddCountry(string resultMessage = null, string resultMessageTitle = null, string resultStatus = null)
        {
            return View();
        }
        [Authorize]
        public ActionResult DisplayCountry(string resultMessage = null, string resultMessageTitle = null, string resultStatus = null)
        {
            List<Country> coutryData = countryDAL.GetCountryDataList();
            return View(coutryData);
        }
        [Authorize]
        public ActionResult UpdateCountry(string countryCode)
        {
            Country country = countryDAL.GetCountryDataByCountryCode(countryCode.ToUpper());
            if (country == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to update";
                TempData["ResultMessageTitle"] = "Updation Failed";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayCountry");
            }
            else
            {
                return View(country);
            }
        }
        [Authorize]
        public ActionResult InsertCountryData()
        {
            string countryCode = Request["countryCode"];

            string countryName = Request["countryName"];
            string[] res = countryDAL.InsertCountryData(countryCode.ToUpper(), countryName, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayCountry");
        }
        [Authorize]
        public ActionResult UpdateCountryData()
        {
            string countryCode = Request["countryCode"];
            string countryName = Request["countryName"];
            string[] res = countryDAL.UpdateCountryData(countryCode.ToUpper(), countryName, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayCountry");
        }
        [Authorize]
        public ActionResult DeleteCountryData(string countryCode)
        {
            string[] res = countryDAL.DeleteCountryData(countryCode.ToUpper(), User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayCountry");
        }


        [Authorize]
        public ActionResult ViewCountry(string countryCode)
        {
            Country country = countryDAL.GetCountryDataByCountryCode(countryCode.ToUpper());
            if (country == null)
            {
                TempData["ResultMessage"] = "Something went wrong. Unable to To View";
                TempData["ResultMessageTitle"] = "View";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayCountry");
            }
            else
            {
                return View(country);
            }
        }

        [Authorize]
        public JsonResult InsertCountryDataByAjax(string countryCode, string countryName)
        {
            string[] res = countryDAL.InsertCountryData(countryCode.ToUpper(), countryName, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];

            var insertionResult = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { InsertionResult = insertionResult, JsonRequestBehavior.AllowGet });
        }


    }
}