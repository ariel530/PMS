using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class Customer_Country_CustomerType_ForDIsplayCustomersInfo
    {
        public CustomerInfo  CustomerInfoData   { get; set; }
        public string CountryName { get; set; }
        public string CustomerTypeName { get; set; }

        public Customer_Country_CustomerType_ForDIsplayCustomersInfo(CustomerInfo customerInfoData, string countryName, string customerTypeName)
        {
            CustomerInfoData = customerInfoData;
            CountryName = countryName;
            CustomerTypeName = customerTypeName;
        }
    }
}