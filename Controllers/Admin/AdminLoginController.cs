using PMS.DAL;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PMS.Controllers.Admin
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        AdminInfoDAL adminInfoDAL;

        public AdminLoginController()
        {
            adminInfoDAL = new AdminInfoDAL();
        }

        public ActionResult Login()
        {
            ViewBag.ReturnUrl = Request["ReturnUrl"];
            return View();
        }

        public ActionResult ValidateLogin()
        {
            string userName = Request["UserName"];
            string password = Request["Password"];
            string loginType = Request["LoginType"];
            string customerSeller = Request["customerseller"];
            string returnUrl = Request["returnUrl"];
            //   AdminInfo adminInfo = adminInfoDAL.GetAdminInfoDetail(userName, password);

            if (loginType == "admin")
            {
                AdminInfo userInfo = new AdminInfoDAL().GetAdminInfoDetail(userName, password);
                if (userInfo == null)
                {
                    return Redirect("Login");
                }
                else
                {

                    FormsAuthentication.SetAuthCookie(userInfo.UserName, false);
                    Session["Info"] = userInfo;
                    if (returnUrl != null && returnUrl != "")
                    {


                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("DisplayUser", "Users");
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
                    Session["Info"] = userInfo;
                    if (returnUrl != null && returnUrl != "")
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("DisplayCustomerType", "CustomerType");
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

            return View();
        }

    }
}