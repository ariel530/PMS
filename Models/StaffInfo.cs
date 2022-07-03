using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class StaffInfo
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int UsersType { get; set; }
        public string ReferFrom { get; set; }
        public int Gender { get; set; }
        public string CNICNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
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
        public int CompanyId { get; set; }

        public StaffInfo()
        {
        }

        public StaffInfo(string userName, string email, string password, string firstName, string lastName, string fatherName, int usersType, string referFrom, int gender, string cNICNumber, DateTime dateOfBirth, string countryCode, string phoneNumber, string mobileNumber, string address, int companyId)
        {
            UserName = userName;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            UsersType = usersType;
            ReferFrom = referFrom;
            Gender = gender;
            CNICNumber = cNICNumber;
            DateOfBirth = dateOfBirth;
            CountryCode = countryCode;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            Address = address;
            CompanyId = companyId;
        }

        public StaffInfo(string userName, string email, string password, string firstName, string lastName, string fatherName, int usersType, string referFrom, int gender, string cNICNumber, DateTime dateOfBirth, string countryCode, string phoneNumber, string mobileNumber, string address, string imagePath, int companyId)
        {
            UserName = userName;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            UsersType = usersType;
            ReferFrom = referFrom;
            Gender = gender;
            CNICNumber = cNICNumber;
            DateOfBirth = dateOfBirth;
            CountryCode = countryCode;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            Address = address;
            ImagePath = imagePath;
            CompanyId = companyId;
        }

        public StaffInfo(string userName, string email, string password, string firstName, string lastName, string fatherName, int usersType, string referFrom, int gender, string cNICNumber, DateTime dateOfBirth, string countryCode, string phoneNumber, string mobileNumber, string address, string imagePath, string addedBy, DateTime? addedOn, int companyId)
        {
            UserName = userName;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            UsersType = usersType;
            ReferFrom = referFrom;
            Gender = gender;
            CNICNumber = cNICNumber;
            DateOfBirth = dateOfBirth;
            CountryCode = countryCode;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            Address = address;
            ImagePath = imagePath;
            AddedBy = addedBy;
            AddedOn = addedOn;
            CompanyId = companyId;
        }

        public StaffInfo(string userName, string email, string password, string firstName, string lastName, string fatherName, int usersType, string referFrom, int gender, string cNICNumber, DateTime dateOfBirth, string countryCode, string phoneNumber, string mobileNumber, string address, string imagePath, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, int companyId)
        {
            UserName = userName;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            UsersType = usersType;
            ReferFrom = referFrom;
            Gender = gender;
            CNICNumber = cNICNumber;
            DateOfBirth = dateOfBirth;
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
            CompanyId = companyId;
        }
    }
}