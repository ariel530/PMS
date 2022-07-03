using Newtonsoft.Json;
using PMS.DAL;
using PMS.DynamicBindingModels;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers.Admin
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer

        CountryDAL countryDAL;
        CustomerTypeDAL customerTypeDAL;
        CustomerInfoDAL customerInfoDAL;
        public CustomerController()
        {
            countryDAL = new CountryDAL();
            customerTypeDAL = new CustomerTypeDAL();
            customerInfoDAL = new CustomerInfoDAL();
        }
        // GET: Customer
        public ActionResult Index()
        {
           // customerInfoDAL.removeAllTables();
            return RedirectToAction("DisplayCustomer");
        }
        public ActionResult AddCustomer()
        {
            Customer_Country_CustomerType_ForAddUpdate customer_Country_CustomerType_AddUpdate = new Customer_Country_CustomerType_ForAddUpdate();
            customer_Country_CustomerType_AddUpdate.CountryData = countryDAL.GetCountryDataListForDropDown();
            if ( !customer_Country_CustomerType_AddUpdate.CountryData.Any())
            {
                return RedirectToAction("Error_505_ForUser", "Error");
            }
            customer_Country_CustomerType_AddUpdate.CustomerTypeData = customerTypeDAL.GetCustomerTypeDataListForDropDown(User.Identity.Name);
            if (!customer_Country_CustomerType_AddUpdate.CustomerTypeData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform user insertion. Add Customer Type to proceed for Customer insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddCustomerType", "CustomerType");
            }

            return View(customer_Country_CustomerType_AddUpdate);

        }
        public ActionResult UpdateCustomer(string id)
        {
            Customer_Country_CustomerType_ForAddUpdate customer_Country_CustomerType_AddUpdate = new Customer_Country_CustomerType_ForAddUpdate();
            customer_Country_CustomerType_AddUpdate.CountryData = countryDAL.GetCountryDataListForDropDown();
            if ( !customer_Country_CustomerType_AddUpdate.CountryData.Any())
            {
                return RedirectToAction("Error_505_ForUser", "Error");

            }
            customer_Country_CustomerType_AddUpdate.CustomerTypeData = customerTypeDAL.GetCustomerTypeDataListForDropDown(User.Identity.Name);
            if (!customer_Country_CustomerType_AddUpdate.CustomerTypeData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform Customer insertion. Add Country to proceed for Customer insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddCustomerType", "CustomerType");
            }
            customer_Country_CustomerType_AddUpdate.CustomerInfoData = customerInfoDAL.GetCustomerDataByUserName(id,User.Identity.Name);
            if (customer_Country_CustomerType_AddUpdate.CustomerInfoData == null)
            {
                TempData["ResultMessage"] = "Some thing went wrong while fetching data...";
                TempData["ResultMessageTitle"] = "Updation Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("DisplayCustomer");

            }
            return View(customer_Country_CustomerType_AddUpdate);
        }
        public ActionResult DisplayCustomer(string resultMessage = null, string resultMessageTitle = null, string resultStatus = null)
        {
       
            List<Customer_Country_CustomerType_ForDIsplayCustomersInfo> customerInfo = customerInfoDAL.GetAllCustomerInfoForDisplay(User.Identity.Name);
            return View(customerInfo);
        }
        public ActionResult DeleteCustomer(string customername)
        {

            string[] res = customerInfoDAL.DeleteCustomerData(customername, User.Identity.Name, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayCustomer");

        }




        
        public JsonResult checkUserNameUniqueByAjax(string userName)
        {

            string[] res = customerInfoDAL.CheckUserNameExists(userName.ToUpper(),User.Identity.Name);


            var uniquenessResult = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { uniquenessResult = uniquenessResult, JsonRequestBehavior.AllowGet });
        }
        public JsonResult checkEmailUniqueByAjax(string email)
        {

            string[] res = customerInfoDAL.CheckEmailExists(email,User.Identity.Name);


            var uniquenessResult = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { uniquenessResult = uniquenessResult, JsonRequestBehavior.AllowGet });
        }
        public JsonResult InsetCustomerDataByAjax(FormCollection formCollection)
        {
            string userName = Request["userName"].ToUpper();
            string firstName = Request["firstName"];
            string lastName = Request["lastName"];
            string email = Request["email"];
            string password = Request["password"];
            string mobile = Request["mobile"];
            string phone = Request["phone"];
            string address = Request["address"];
            string country = Request["country"];
            string referFrom = Request["ReferFrom"];
            int customerType = int.Parse(Request["customerType"]);
            string customerImage = "";

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    if (file != null || file.FileName.CompareTo("") == 0)
                    {
                        var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", ".jpeg" };

                        var fileName = file.FileName; //getting only file name(ex-ganesh.jpg) 

                        {
                            var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg) 

                            if (allowedExtensions.Contains(ext)) //check what type of extension  
                            {
                                string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                                customerImage = userName + "/" + name.ToUpper() + "_" + userName + "_" + DateTime.Now.ToString().Replace(":", String.Empty).Replace("/", String.Empty).Replace(" ", String.Empty) + "_" + ext; //appending the name with id  
                                                                                                                                                                                                                           // store the file inside ~/project folder(Img)  
                                var path = Path.Combine(Server.MapPath("~/CustomerImages"), customerImage);
                                Directory.CreateDirectory(Server.MapPath("~/CustomerImages/" + userName));
                                file.SaveAs(path);
                                //var path = "";
                                //try
                                //{
                                //    path = Path.Combine(Server.MapPath("~/CustomerImages"), customerImage);
                                //    customerImage += " Path " + path;
                                //}
                                //catch (Exception ex)
                                //{
                                //    customerImage += " PathError " + ex.Message;

                                //}
                                //// store the file inside ~/project folder(Img)  
                                //try
                                //{
                                //    DirectoryInfo isMake = Directory.CreateDirectory(Server.MapPath("~/CustomerImages/" + userName));
                                //    customerImage += "  DirectoryInfo " + isMake.Exists + " " + isMake.FullName;

                                //}
                                //catch (Exception ex)
                                //{
                                //    customerImage += "  Directory " + ex.Message;
                                //}

                            }
                        }
                    }
                }
            }

            CustomerInfo customerInfo = new CustomerInfo(userName, email, password, firstName, lastName, customerType, referFrom, country, phone, mobile, address, customerImage, false, "", null, "", null, "", null,User.Identity.Name);
           
            string[] result = customerInfoDAL.InsertCustomerData(customerInfo, User.Identity.Name,User.Identity.Name);
            if (result[1] == "success")
            {
                TempData["ResultMessage"] = result[0];
                TempData["ResultMessageTitle"] = result[2];
                TempData["ResultStatus"] = result[1];
            }
            //string[] res = countryDAL.InsertCountryData(countryCode.ToUpper(), countryName, Customer.Identity.Name);


            var insertionResult = JsonConvert.SerializeObject(result, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { InsertionResult = insertionResult, JsonRequestBehavior.AllowGet });
        }
        public JsonResult UpdateCustomerDataByAjax(FormCollection formCollection)
        {
           
            string userName = Request["userName"].ToUpper();
            string firstName = Request["firstName"];
            string lastName = Request["lastName"];
            string email = Request["email"];
            string password = Request["password"];
            string mobile = Request["mobile"];
            string phone = Request["phone"];
            string address = Request["address"];
            string country = Request["country"];
            int customerType = int.Parse(Request["customerType"]);
            string referFrom = Request["referFrom"];
            string customerImage = "";
            string previousCountryCode = Request["previousCountryCode"];
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                    if (file != null || file.FileName.CompareTo("") == 0)
                    {
                        var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };

                        var fileName = file.FileName; //getting only file name(ex-ganesh.jpg) 

                        {
                            var ext = Path.GetExtension(file.FileName); //getting the extension(ex-.jpg) 

                            if (allowedExtensions.Contains(ext)) //check what type of extension  
                            {
                                string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                                customerImage = userName + "/" + name.ToUpper() + "_" + userName + "_" + DateTime.Now.ToString().Replace(":", String.Empty).Replace("/", String.Empty).Replace(" ", String.Empty) + "_" + ext; //appending the name with id  
                                                                                                                                                                                                                           // store the file inside ~/project folder(Img)  
                                var path = Path.Combine(Server.MapPath("~/CustomerImages"), customerImage);
                                Directory.CreateDirectory(Server.MapPath("~/CustomerImages/" + userName));
                                file.SaveAs(path);

                            }
                        }
                    }
                }
            }

            CustomerInfo customerInfo = new CustomerInfo(userName, email, password, firstName, lastName, customerType, referFrom, country, phone, mobile, address, customerImage, false, "", null, "", null, "", null,User.Identity.Name);
            string[] result = customerInfoDAL.UpdateCustomerData(customerInfo, previousCountryCode, User.Identity.Name,User.Identity.Name);
            if (result[1] == "success")
            {
                TempData["ResultMessage"] = result[0];
                TempData["ResultMessageTitle"] = result[2];
                TempData["ResultStatus"] = result[1];
            }
            //string[] res = countryDAL.InsertCountryData(countryCode.ToUpper(), countryName, Customer.Identity.Name);


            var updataionResult = JsonConvert.SerializeObject(result, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { updataionResult = updataionResult, JsonRequestBehavior.AllowGet });
        }
        //public ActionResult ViewCustomer(string id)
        //{
        //    Customer_Country_CustomerType_ForAddUpdate customer_Country_CustomerType_AddUpdate = new Customer_Country_CustomerType_ForAddUpdate();
        //    customer_Country_CustomerType_AddUpdate.CountryData = countryDAL.GetCountryDataListForDropDownAllIncludedDeleted();
        //    if ( !customer_Country_CustomerType_AddUpdate.CountryData.Any())
        //    {
        //        return RedirectToAction("AddCountry", "Country", new { resultMessage = "Add Country to View Customer..", resultMessageTitle = "Updation Failed !", resultStatus = "fail" });
        //    }
        //    customer_Country_CustomerType_AddUpdate.CustomerTypeData = customerTypeDAL.GetCustomerTypeDataListForDropDownAllIncludedDeleted();
        //    if (!customer_Country_CustomerType_AddUpdate.CustomerTypeData.Any())
        //    {
        //        return RedirectToAction("AddCustomerType", "CustomerType", new { resultMessage = "Add Customer Type to View Customer..", resultMessageTitle = "Updation Failed !", resultStatus = "fail" });
        //    }
        //    customer_Country_CustomerType_AddUpdate.CustomerInfoData = customerInfoDAL.GetCustomerDataByCustomerName(id);
        //    if (customer_Country_CustomerType_AddUpdate.CustomerInfoData == null)
        //    {
        //        return RedirectToAction("DisplayCustomer", new { resultMessage = "Some thing went wrong while fetching data...", resultMessageTitle = "Updation Failed !", resultStatus = "fail" });

        //    }

        //    return View(customer_Country_CustomerType_AddUpdate);
        //}
        public JsonResult GetCustomersForMapCount()
        {
            List<CustomersProjectsMapCount> customersProjectsMapCounts = customerInfoDAL.GetCustomerCountsForMap(User.Identity.Name);
            
            //string[] res = countryDAL.InsertCountryData(countryCode.ToUpper(), countryName, Customer.Identity.Name);


            //var CustomerProjectsOnMap = JsonConvert.SerializeObject(customersProjectsMapCounts, Formatting.None, new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //});


            return Json(customersProjectsMapCounts, JsonRequestBehavior.AllowGet );
        }
        public ActionResult ViewCustomer(string id)
        {
            Customer_Country_CustomerType_ForAddUpdate customer_Country_CustomerType_AddUpdate = new Customer_Country_CustomerType_ForAddUpdate();
            customer_Country_CustomerType_AddUpdate.CountryData = countryDAL.GetCountryDataListForDropDown();
            if (!customer_Country_CustomerType_AddUpdate.CountryData.Any())
            {
                return RedirectToAction("Error_505_ForUser", "Error");
            }
            customer_Country_CustomerType_AddUpdate.CustomerTypeData = customerTypeDAL.GetCustomerTypeDataListForDropDown(User.Identity.Name);
            if (!customer_Country_CustomerType_AddUpdate.CustomerTypeData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform Customer View. Add Customer Type to proceed for Customer view..";
                TempData["ResultMessageTitle"] = "View Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddCustomerType", "CustomerType");
            }
            customer_Country_CustomerType_AddUpdate.CustomerInfoData = customerInfoDAL.GetCustomerDataByUserName(id, User.Identity.Name);
            if (customer_Country_CustomerType_AddUpdate.CustomerInfoData == null)
            {
                TempData["ResultMessage"] = "Some thing went wrong while fetching data...";
                TempData["ResultMessageTitle"] = "View Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("DisplayCustomer");

            }
            return View(customer_Country_CustomerType_AddUpdate);

        }
        public ActionResult MapCustomer()
        {
            return View();
        }
        public ActionResult MapCustomerCustomization()
        {
            return View();
        }


    }
}