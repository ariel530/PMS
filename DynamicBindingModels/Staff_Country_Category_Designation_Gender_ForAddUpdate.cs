using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class Staff_Country_Category_Designation_Gender_ForAddUpdate
    {
        public List<Gender> GendersData { get; set; }
        public List<StaffDesignation> StaffDesignationData { get; set; }
        public List<StaffCategory> StaffCategoryData { get; set; }
        public List<Country> CountryData { get; set; }

    }
}