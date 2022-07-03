using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class User_Country_UserType_ForDIsplayUsersInfo
    {
        public UserInfo UserInfoData { get; set; }
        public string CountryName { get; set; }
        public string UserTypeName { get; set; }

        public User_Country_UserType_ForDIsplayUsersInfo()
        {

        }
        public User_Country_UserType_ForDIsplayUsersInfo(UserInfo userInfoData, string countryName, string userTypeName)
        {
            UserInfoData = userInfoData;
            CountryName = countryName;
            UserTypeName = userTypeName;
        }
    }
}