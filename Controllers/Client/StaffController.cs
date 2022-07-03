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

namespace PMS.Controllers.Client
{
    [Authorize]
    public class StaffController : Controller
    {
        CountryDAL countryDAL;
        StaffCategoryDAL staffCategoryDAL;
        StaffDesignationDAL staffDesignationDAL;
        GenderDAL genderDAL;
        StaffInfoDAL staffInfoDAL;
        EducationRecordDAL educationRecordDAL;
        public StaffController()
        {
            countryDAL = new CountryDAL();
            staffCategoryDAL = new StaffCategoryDAL();
            staffDesignationDAL = new StaffDesignationDAL();
            genderDAL = new GenderDAL();
            staffInfoDAL = new StaffInfoDAL();
            educationRecordDAL = new EducationRecordDAL();
        }
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddStaffInfo()
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            Staff_Country_Category_Designation_Gender_ForAddUpdate staffInfo = new Staff_Country_Category_Designation_Gender_ForAddUpdate();
            staffInfo.CountryData = countryDAL.GetCountryDataListForDropDown();
            if (!staffInfo.CountryData.Any())
            {
                return RedirectToAction("Error_505_ForUser", "Error");
            }
            staffInfo.StaffCategoryData = staffCategoryDAL.GetStaffCategoryDataListForDropDown(companyId);
            if (!staffInfo.StaffCategoryData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform staff insertion. Add Staff category to proceed for Staff insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddStaffCategory", "StaffCategory");
            }
            staffInfo.StaffDesignationData = staffDesignationDAL.GetStaffDesignationDataListForDropDown(companyId);
            if (!staffInfo.StaffDesignationData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform staff insertion. Add Staff designation to proceed for Staff insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddStaffDesignation", "StaffDesignation");
            }
            staffInfo.GendersData = genderDAL.GetGenderDataListForDropDown(companyId);
            if (!staffInfo.GendersData.Any())
            {
                TempData["ResultMessage"] = "Unable to perform staff insertion. Add gender data to proceed for Staff insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";

                return RedirectToAction("AddGender", "Gender");
            }







            return View(staffInfo);

        }


        public JsonResult checkUserNameUniqueByAjax(string userName)
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());


            string[] res = staffInfoDAL.CheckUserNameExists(userName.ToUpper(), companyId);


            var uniquenessResult = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { uniquenessResult = uniquenessResult, JsonRequestBehavior.AllowGet });
        }
        public JsonResult checkEmailUniqueByAjax(string email)
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());

            string[] res = staffInfoDAL.CheckEmailExists(email, companyId);


            var uniquenessResult = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { uniquenessResult = uniquenessResult, JsonRequestBehavior.AllowGet });
        }
        public JsonResult checkStaffCardNumberUniqueByAjax(string cardnumber)
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());

            string[] res = staffInfoDAL.CheckCardNumberExists(cardnumber, companyId);


            var uniquenessResult = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { uniquenessResult = uniquenessResult, JsonRequestBehavior.AllowGet });
        }



        public JsonResult InsetStaffDataByAjax(FormCollection formCollection)
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            string userName = Request["username"].ToUpper();
            string firstName = Request["firstname"];
            string lastName = Request["lastname"];
            string email = Request["email"];
            string password = Request["password"];
            string mobile = Request["mobile"];
            string phone = Request["phone"];
            string address = Request["address"];
            string country = Request["country"];
            string referFrom = Request["ReferFrom"];
            //   int userType = int.Parse(Request["staffType"]);
            int userType = 2;
            int staffDesignationId = int.Parse(Request["staffdesignation"]);
            int staffCategoryId = int.Parse(Request["staffcategory"]);
            string cnic = Request["cnic"];
            string passport = Request["passport"];
            string fathername = Request["fathername"];
            int gender = int.Parse(Request["gender"]);
            DateTime dateofbirth = DateTime.Parse(Request["age"]);
            string cardnumber = Request["cardnumber"];
            float salary = float.Parse(Request["salary"].ToUpper().Replace("₪", String.Empty));
            List<EducationRecord> educationRecords = new List<EducationRecord>();
            int educationRecordsCount = int.Parse(Request["educationrecord"]);
            for(int i=1;i<= educationRecordsCount; i++)
            {
                string tempDegree = "degreename_" + i;
                string tempYear = "degreeyear_" + i;
                educationRecords.Add(new EducationRecord(userName, Request[tempDegree],int.Parse( Request[tempYear]),User.Identity.Name, companyId));
            }


            string addedBy = User.Identity.Name;
            string staffImage = "";

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
                                staffImage = userName + "/" + name.ToUpper() + "_" + userName + "_" + DateTime.Now.ToString().Replace(":", String.Empty).Replace("/", String.Empty).Replace(" ", String.Empty) + "_" + ext; //appending the name with id  
                                                                                                                                                                                                                               // store the file inside ~/project folder(Img)  
                                var path = Path.Combine(Server.MapPath("~/StaffImages"), staffImage);
                                Directory.CreateDirectory(Server.MapPath("~/StaffImages/" + userName));
                                file.SaveAs(path);
                                //var path = "";
                                //try
                                //{
                                //    path = Path.Combine(Server.MapPath("~/StaffImages"), staffImage);
                                //    staffImage += " Path " + path;
                                //}
                                //catch (Exception ex)
                                //{
                                //    staffImage += " PathError " + ex.Message;

                                //}
                                //// store the file inside ~/project folder(Img)  
                                //try
                                //{
                                //    DirectoryInfo isMake = Directory.CreateDirectory(Server.MapPath("~/StaffImages/" + userName));
                                //    staffImage += "  DirectoryInfo " + isMake.Exists + " " + isMake.FullName;

                                //}
                                //catch (Exception ex)
                                //{
                                //    staffImage += "  Directory " + ex.Message;
                                //}


                            }
                        }
                    }
                }
            }

            StaffInfo staffInfo = new StaffInfo(userName, email, password, firstName, lastName, fathername, userType, referFrom, gender, cnic, dateofbirth,
                country, phone, mobile, address, staffImage, User.Identity.Name, null, companyId);
            StaffDetail staffDetail = new StaffDetail(userName, passport, cardnumber, salary, staffCategoryId, staffDesignationId, User.Identity.Name, companyId) ;
            string[] result = staffInfoDAL.InsertStaffData(staffInfo,staffDetail,educationRecords);
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


        public ActionResult DisplayStaff()
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            List<Staff_ForTableDisplay> staffList = staffInfoDAL.GetAllStaffDataFromDisplay(companyId);
            return View(staffList);
        }

        public ActionResult ViewStaff(string id)
        {
            int companyId = int.Parse(Session["CompanyId"].ToString());
            Staff_Enducation_ForSpecificView staff_Enducation_ForSpecific = staffInfoDAL.GetSpecificStaffDataForViewByUserName(id,companyId);
            staff_Enducation_ForSpecific.EducationRecordsData = educationRecordDAL.GetEducationRecordDataListByUserName(id, companyId);
            return View(staff_Enducation_ForSpecific);

        }



    }

}