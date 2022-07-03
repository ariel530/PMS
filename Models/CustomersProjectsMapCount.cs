using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class CustomersProjectsMapCount
    {
        public string CountryCode { get; set; }

        public string CountryName { get; set; }
        public int  CustomersCount { get; set; }
        public int  ProjectsCount { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string UserInfoUserName { get; set; }
        public CustomersProjectsMapCount()
        {

        }

        public CustomersProjectsMapCount( string countryCode ,string countryName, int customersCount, int projectsCount)
        {
            CountryCode = countryCode;
            CountryName = countryName;
            CustomersCount = customersCount;
            ProjectsCount = projectsCount;
        }

        public CustomersProjectsMapCount(string countryCode, int customersCount, int projectsCount, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, string userInfoUserName)
        {
            CountryCode = countryCode;
            CustomersCount = customersCount;
            ProjectsCount = projectsCount;
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