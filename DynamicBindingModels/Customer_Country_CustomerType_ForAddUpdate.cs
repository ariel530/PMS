using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class Customer_Country_CustomerType_ForAddUpdate
    {
        public CustomerInfo CustomerInfoData { get; set; }
        public List<Country> CountryData { get; set; }
        public List<CustomerType> CustomerTypeData { get; set; }

        public Customer_Country_CustomerType_ForAddUpdate()
        {
        }

        public Customer_Country_CustomerType_ForAddUpdate(CustomerInfo customerInfoData, List<Country> countryData, List<CustomerType> customerTypeData)
        {
            CustomerInfoData = customerInfoData;
            CountryData = countryData;
            CustomerTypeData = customerTypeData;
        }
    }
}