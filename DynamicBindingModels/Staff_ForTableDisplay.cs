using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class Staff_ForTableDisplay
    {
        public string  UserName { get; set; }
        public string Email { get; set; }
        public string StaffCardNumber { get; set; }
        public string  Password { get; set; }
        public string StaffCategoryName { get; set; }
        public string  StaffDesignationName { get; set; }
        public string GenderName { get; set; }
        public string CountryName { get; set; }
        public string MobileNumber { get; set; }
        public string ImagePath { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public Staff_ForTableDisplay()
        {
        }

        public Staff_ForTableDisplay(string userName, string email, string staffCardNumber, string password, string staffCategoryName, string staffDesignationName, string genderName, string countryName, string mobileNumber, string imagePath, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn)
        {
            UserName = userName;
            Email = email;
            StaffCardNumber = staffCardNumber;
            Password = password;
            StaffCategoryName = staffCategoryName;
            StaffDesignationName = staffDesignationName;
            GenderName = genderName;
            CountryName = countryName;
            MobileNumber = mobileNumber;
            ImagePath = imagePath;
            AddedBy = addedBy;
            AddedOn = addedOn;
            LastModifiedBy = lastModifiedBy;
            LastModifiedOn = lastModifiedOn;
        }
    }
}