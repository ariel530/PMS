using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class Staff_Enducation_ForSpecificView
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int UsersType { get; set; }
        public string ReferFrom { get; set; }
        public string GenderName { get; set; }
        public string CNICNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CountryName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string StaffPassportNumber { get; set; }
        public string StaffCardNumber { get; set; }
        public float StaffSalary { get; set; }
        public string StaffCategoryName { get; set; }
        public string StaffDesignationName { get; set; }
        public int Age { get; set; }

        public List<EducationRecord> EducationRecordsData { get; set; }

        public Staff_Enducation_ForSpecificView(string userName, string email, string password, string firstName, string lastName, string fatherName, int usersType, string referFrom, string genderName, string cNICNumber, DateTime dateOfBirth, string countryName, string phoneNumber, string mobileNumber, string address, string imagePath, string staffPassportNumber, string staffCardNumber, float staffSalary, string staffCategoryName, string staffDesignationName)
        {
            UserName = userName;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            UsersType = usersType;
            ReferFrom = referFrom;
            GenderName = genderName;
            CNICNumber = cNICNumber;
            DateOfBirth = dateOfBirth;
            CountryName = countryName;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            Address = address;
            ImagePath = imagePath;
            StaffPassportNumber = staffPassportNumber;
            StaffCardNumber = staffCardNumber;
            StaffSalary = staffSalary;
            StaffCategoryName = staffCategoryName;
            StaffDesignationName = staffDesignationName;

            Age = DateTime.Now.Year - dateOfBirth.Year;
        }

        public Staff_Enducation_ForSpecificView()
        {
        }
    }
}