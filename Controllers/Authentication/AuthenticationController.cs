using PMS.DAL;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PMS.Controllers.Authentication
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            if (Session["User"] == null)
            {
                ViewBag.ReturnUrl = Request["ReturnUrl"];
                return View();
            }
            else
            {
                return RedirectToAction("LockScreen");
            }
        }
        public ActionResult ValidateLogin()
        {
            string userName = Request["UserName"];
            string password = Request["Password"];
            string loginType = Request["LoginType"];
            string customerSeller = Request["customerseller"];
            string returnUrl = Request["returnUrl"];
            //   AdminInfo adminInfo = adminInfoDAL.GetAdminInfoDetail(userName, password);
            Session["CompanyId"] = "1";
            if (loginType == "admin")
            {
                AdminInfo userInfo = new AdminInfoDAL().GetAdminInfoDetail(userName, password);
                if (userInfo == null)
                {
                    return Redirect("Login");
                }
                else
                {

                    FormsAuthentication.SetAuthCookie(userInfo.UserName.ToUpper(), false);
                    Session["UserName"] = userInfo.UserName;
                    Session["LoginType"] = loginType;
                    Session["customerseller"] = customerSeller;
                    Session["returnUrl"] = returnUrl;
                    Session["User"] = userInfo;
                    Session["CurrentName"] = userName.ToUpper();
                    Session["Image"] = "UserImages/" + userInfo.ImagePath;
                    if (returnUrl != null && returnUrl != "")
                    {


                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("DisplayUsers", "Users");
                    }
                }

            }
            else if (loginType == "user")
            {
                UserInfo userInfo = new UserInfoDAL().GetUserInfoDetail(userName, password);
                if (userInfo == null)
                {
                    return Redirect("Login");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(userInfo.UserName, false);
                    Session["UserName"] = userInfo.UserName;
                    Session["LoginType"] = loginType;
                    Session["customerseller"] = customerSeller;
                    Session["returnUrl"] = returnUrl;
                    Session["User"] = userInfo;
                    Session["CurrentName"] = userName.ToUpper();
                    Session["Image"] = "UserImages/" + userInfo.ImagePath;

                    if (returnUrl != null && returnUrl != "")
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "ClientDashboard");
                    }
                }

            }
            else if (loginType == "customer")
            {

            }

            return null;
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["UserName"] = null;
            Session["LoginType"] = null;
            Session["customerseller"] = null;
            Session["returnUrl"] = null;
            Session["User"] = null;
            Session["CurrentName"] = null;
            Session["Image"] = null;

            return RedirectToAction("Login");
        }
        public ActionResult LockScreen()
        {
            FormsAuthentication.SignOut();
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public JsonResult ValidateLockScreenUsingAjax(string password)
        {
            Session["CompanyId"] = "1";
            if (Session["User"] != null)
            {
                string userName = Session["UserName"].ToString();
                string loginType = Session["LoginType"].ToString();
                string customerSeller = Session["customerseller"].ToString();
                string returnUrl = Session["returnUrl"].ToString();
                //   AdminInfo adminInfo = adminInfoDAL.GetAdminInfoDetail(userName, password);

                if (loginType == "admin")
                {
                    AdminInfo userInfo = new AdminInfoDAL().GetAdminInfoDetail(userName, password);
                    if (userInfo == null)
                    {
                        return Json(false);
                    }
                    else
                    {

                        FormsAuthentication.SetAuthCookie(userInfo.UserName, false);
                        if (returnUrl != null && returnUrl != "")
                        {

                            return Json(returnUrl);

                        }
                        else
                        {
                            return Json("/Users/DisplayUser");
                        }
                    }

                }
                else if (loginType == "user")
                {
                    UserInfo userInfo = new UserInfoDAL().GetUserInfoDetail(userName, password);
                    if (userInfo == null)
                    {
                        return Json(false);
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(userInfo.UserName, false);

                        if (returnUrl != null && returnUrl != "")
                        {
                            return Json(returnUrl);
                        }
                        else
                        {
                            return Json("/Customer/DisplayCustomerType");

                        }
                    }

                }
                else if (loginType == "customer")
                {
                    CustomerInfo userInfo = new CustomerInfoDAL().GetCustomerInfoDetail(userName, password, customerSeller);

                    if (userInfo == null)
                    {
                        return Json(false);
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(userInfo.UserName, false);
                        if (returnUrl != null && returnUrl != "")
                        {
                            return Json(returnUrl);
                        }
                        else
                        {
                            return Json("/CustomerMessages/ChatBox");

                        }
                    }
                }


                return Json(false);

            }
            else
            {
                return Json("/Authentication/Login");
            }

        }

        public JsonResult ValidateLoginUsingAjax(string username, string password, string logintype, string customerseller, string returnurl)

        {

            Session["CompanyId"] = "1";
            customerseller = customerseller.ToUpper();
            username = username.ToUpper();
            //   AdminInfo adminInfo = adminInfoDAL.GetAdminInfoDetail(userName, password);

            if (logintype == "admin")
            {
                AdminInfo userInfo = new AdminInfoDAL().GetAdminInfoDetail(username, password);
             
                if (userInfo == null)
                {
                    return Json(false);
                }
                else
                {
                    Session["UserName"] = userInfo.UserName.ToUpper();
                    Session["LoginType"] = logintype;
                    Session["customerseller"] = customerseller;
                    Session["returnUrl"] = returnurl;
                    Session["User"] = userInfo;
                    Session["CurrentName"] = username.ToUpper();
                    Session["Image"] = "UserImages/" + userInfo.ImagePath;
                    FormsAuthentication.SetAuthCookie(userInfo.UserName.ToUpper(), false);
                    if (returnurl != null && returnurl != "")
                    {

                        return Json(returnurl);

                    }
                    else
                    {
                        return Json("/Users/DisplayUsers");
                    }
                }

            }
            else if (logintype == "user")
            {
                UserInfo userInfo = new UserInfoDAL().GetUserInfoDetail(username, password);

                if (userInfo == null)
                {
                    return Json(false);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(userInfo.UserName.ToUpper(), false);
                    Session["UserName"] = userInfo.UserName.ToUpper();
                    Session["LoginType"] = logintype;
                    Session["customerseller"] = customerseller;
                    Session["returnUrl"] = returnurl;
                    Session["User"] = userInfo;
                    Session["CurrentName"] = username.ToUpper();
                    Session["Image"] = "UserImages/" + userInfo.ImagePath;
                    PMS.Utility.DBConnection.userName = userInfo.UserName.ToUpper();
                   // new PMS.DAL.NotificationsDAL().GetMessagesNotification();

                    if (returnurl != null && returnurl != "")
                    {
                        return Json(returnurl);
                    }
                    else
                    {
                        return Json("/ClientDashboard/Index");

                    }
                }

            }
            else if (logintype == "customer")
            {
                CustomerInfo userInfo = new CustomerInfoDAL().GetCustomerInfoDetail(username.ToUpper(), password, customerseller.ToUpper());

                if (userInfo == null)
                {
                    return Json(false);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(userInfo.UserName.ToUpper(), false);
                    Session["UserName"] = userInfo.UserName;
                    Session["LoginType"] = logintype;
                    Session["customerseller"] = customerseller;
                    Session["returnUrl"] = returnurl;
                    Session["User"] = userInfo;
                    Session["CurrentName"] = username.ToUpper();
                    Session["Image"] = "CustomerImages/" + userInfo.ImagePath;
                    if (returnurl != null && returnurl != "")
                    {
                        return Json(returnurl);
                    }
                    else
                    {
                        return Json("/CustomerMessages/ChatBox");

                    }
                }

            }
            return Json(false);
        }

    }
}