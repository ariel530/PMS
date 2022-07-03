using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class CustomerInfo
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerType { get; set; }
        public string ReferFrom { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string UserInfoUserName { get; set; }
        public CustomerInfo()
        {

        }
        public CustomerInfo(string userName)
        {
            UserName = userName;
        }



        public CustomerInfo(string userName, string email, string password, string firstName, string lastName, int customerType, string referFrom, string countryCode, string phoneNumber, string mobileNumber, string address, string imagePath, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn,string userInfoUserName)
        {
            UserName = userName;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            CustomerType = customerType;
            ReferFrom = referFrom;
            CountryCode = countryCode;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            Address = address;
            ImagePath = imagePath;
            IsDeleted = isDeleted;
            DeletedBy = deletedBy;
            DeletedOn = deletedOn;
            AddedBy = addedBy;
            AddedOn = addedOn;
            LastModifiedBy = lastModifiedBy;
            LastModifiedOn = lastModifiedOn;
            UserInfoUserName = userInfoUserName;
        }
    }
}