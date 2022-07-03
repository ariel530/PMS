using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class User_Country_UserType_AddUpdate
    {
        public IEnumerable<UserType> userType { get; set; }
        public IEnumerable<Country> country { get; set; }
        public UserInfo UserInfoData { get; set; }


    }
}