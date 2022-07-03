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

namespace PMS.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {

        CountryDAL countryDAL;
        UserTypeDAL userTypeDAL;
        UserInfoDAL userInfoDAL;
        public UsersController()
        {
            countryDAL = new CountryDAL();
            userTypeDAL = new UserTypeDAL();
            userInfoDAL = new UserInfoDAL();
        }
        // GET: Users
        public ActionResult Index()
        {
         //  userInfoDAL.removeAllTables();
            return RedirectToAction("DisplayUsers");
        }
        public ActionResult AddUsers()
        {
            User_Country_UserType_AddUpdate user_Country_UserType_AddUpdate = new User_Country_UserType_AddUpdate();
            user_Country_UserType_AddUpdate.country = countryDAL.GetCountryDataListForDropDown();
            if (!user_Country_UserType_AddUpdate.country.Any())
            {
                TempData["ResultMessage"] = "Unable to perform user insertion. Add Country to proceed for user insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("AddCountry");
            }
            user_Country_UserType_AddUpdate.userType = userTypeDAL.GetUserTypeDataListForDropDown();
            if (!user_Country_UserType_AddUpdate.userType.Any())
            {
                TempData["ResultMessage"] = "Unable to perform user insertion. Add User Type to proceed for user insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("AddUserType", "UserType");
            }

            return View(user_Country_UserType_AddUpdate);

        }
        public ActionResult UpdateUsers(string id)
        {
            User_Country_UserType_AddUpdate user_Country_UserType_AddUpdate = new User_Country_UserType_AddUpdate();
            user_Country_UserType_AddUpdate.country = countryDAL.GetCountryDataListForDropDown();
            if (!user_Country_UserType_AddUpdate.country.Any())
            {
                TempData["ResultMessage"] = "Unable to perform user insertion. Add Country to proceed for user insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("AddCountry", "Country", new { resultMessage = "Unable to perform user updation. Add Country to proceed for user updation..", resultMessageTitle = "Updation Failed !", resultStatus = "fail" });
            }
            user_Country_UserType_AddUpdate.userType = userTypeDAL.GetUserTypeDataListForDropDownAllIncludedDeleted();
            if (!user_Country_UserType_AddUpdate.userType.Any())
            {
                TempData["ResultMessage"] = "Unable to perform user insertion. Add User Type to proceed for user insertion..";
                TempData["ResultMessageTitle"] = "Insertion Failed !";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("AddUserType", "UserType", new { resultMessage = "Unable to perform user updation. Add User type to proceed for user updation..", resultMessageTitle = "Updation Failed !", resultStatus = "fail" });
            }
            user_Country_UserType_AddUpdate.UserInfoData = userInfoDAL.GetUserDataByUserName(id);
            if (user_Country_UserType_AddUpdate.UserInfoData == null)
            {
                TempData["ResultMessage"] = "Some thing went wrong while fetching data...";
                TempData["ResultMessageTitle"] = "Updation Failed !";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayUsers");

            }
            return View(user_Country_UserType_AddUpdate);
        }
        public ActionResult DisplayUsers(string resultMessage = null, string resultMessageTitle = null, string resultStatus = null)
        {
            ViewData["ResultMessage"] = resultMessage;
            ViewData["ResultMessageTitle"] = resultMessageTitle;
            ViewData["ResultStatus"] = resultStatus;
            List<User_Country_UserType_ForDIsplayUsersInfo> userInfo = userInfoDAL.GetAllUserInfoForDisplay();
            return View(userInfo);
        }

        public ActionResult DeleteUsers(string username)
        {

            string[] res = userInfoDAL.DeleteUserData(username, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];
            return RedirectToAction("DisplayUsers");

        }


        public JsonResult checkUserNameUniqueByAjax(string userName)
        {

            string[] res = userInfoDAL.CheckUserNameExists(userName.ToUpper());
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];

            var uniquenessResult = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { uniquenessResult = uniquenessResult, JsonRequestBehavior.AllowGet });
        }
        public JsonResult checkEmailUniqueByAjax(string email)
        {

            string[] res = userInfoDAL.CheckEmailExists(email);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];

            var uniquenessResult = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { uniquenessResult = uniquenessResult, JsonRequestBehavior.AllowGet });
        }
        public JsonResult InsetUserDataByAjax(FormCollection formCollection)
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
            int userType = int.Parse(Request["userType"]);
            string userImage = "";

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
                                userImage = userName + "/" + name.ToUpper() + "_" + userName + "_" + DateTime.Now.ToString().Replace(":", String.Empty).Replace("/", String.Empty).Replace(" ", String.Empty) + "_" + ext; //appending the name with id  
                                                                                                                                                                                                                           // store the file inside ~/project folder(Img)  
                                var path = Path.Combine(Server.MapPath("~/UserImages"), userImage);
                                Directory.CreateDirectory(Server.MapPath("~/UserImages/" + userName));
                                file.SaveAs(path);

                            }
                        }
                    }
                }
            }

            UserInfo userInfo = new UserInfo(userName, email, password, firstName, lastName, userType, country, phone, mobile, address, userImage, false, "", null, "", null, "", null);
            string[] res = userInfoDAL.InsertUserData(userInfo, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];

            //string[] res = countryDAL.InsertCountryData(countryCode.ToUpper(), countryName, User.Identity.Name);


            var insertionResult = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { InsertionResult = insertionResult, JsonRequestBehavior.AllowGet });
        }
        public JsonResult UpdateUserDataByAjax(FormCollection formCollection)
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
            int userType = int.Parse(Request["userType"]);
            string userImage = "";

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
                                userImage = userName + "/" + name.ToUpper() + "_" + userName + "_" + DateTime.Now.ToString().Replace(":", String.Empty).Replace("/", String.Empty).Replace(" ", String.Empty) + "_" + ext; //appending the name with id  
                                                                                                                                                                                                                           // store the file inside ~/project folder(Img)  
                                var path = Path.Combine(Server.MapPath("~/UserImages"), userImage);
                                Directory.CreateDirectory(Server.MapPath("~/UserImages/" + userName));
                                file.SaveAs(path);

                            }
                        }
                    }
                }
            }

            UserInfo userInfo = new UserInfo(userName, email, password, firstName, lastName, userType, country, phone, mobile, address, userImage, false, "", null, "", null, "", null);
            string[] res = userInfoDAL.UpdateUserData(userInfo, User.Identity.Name);
            TempData["ResultMessage"] = res[0];
            TempData["ResultMessageTitle"] = res[2];
            TempData["ResultStatus"] = res[1];

            //string[] res = countryDAL.InsertCountryData(countryCode.ToUpper(), countryName, User.Identity.Name);


            var updataionResult = JsonConvert.SerializeObject(res, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });


            return Json(new { updataionResult = updataionResult, JsonRequestBehavior.AllowGet });
        }
        public ActionResult ViewUser(string id)
        {
            User_Country_UserType_AddUpdate user_Country_UserType_AddUpdate = new User_Country_UserType_AddUpdate();
            user_Country_UserType_AddUpdate.country = countryDAL.GetCountryDataListForDropDownAllIncludedDeleted();
            if (!user_Country_UserType_AddUpdate.country.Any())
            {
                TempData["ResultMessage"] = "Add Country to View User..";
                TempData["ResultMessageTitle"] = "Updation Failed !";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("AddCountry", "Country");
            }
            user_Country_UserType_AddUpdate.userType = userTypeDAL.GetUserTypeDataListForDropDownAllIncludedDeleted();
            if (!user_Country_UserType_AddUpdate.userType.Any())
            {
                TempData["ResultMessage"] = "Add User Type to View User..";
                TempData["ResultMessageTitle"] = "Updation Failed !";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("AddUserType", "UserType");
            }
            user_Country_UserType_AddUpdate.UserInfoData = userInfoDAL.GetUserDataByUserName(id);
            if (user_Country_UserType_AddUpdate.UserInfoData == null)
            {
                TempData["ResultMessage"] = "Some thing went wrong while fetching data...";
                TempData["ResultMessageTitle"] = "Updation Failed !";
                TempData["ResultStatus"] = "fail";
                return RedirectToAction("DisplayUsers");

            }

            return View(user_Country_UserType_AddUpdate);
        }

    }



}