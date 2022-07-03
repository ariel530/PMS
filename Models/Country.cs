using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Country
    {
        public string  CountryCode { get; set; }
        public string CountryName { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }


        public Country()
        {
            CountryCode = "";
            CountryName = "";
            IsDeleted = false ;
            DeletedBy = null;
            DeletedOn = null;
            AddedBy = null;
            AddedOn = null;
            LastModifiedBy = null;
            LastModifiedOn = null ;
        }

        public Country(string countryCode, string countryName, bool isDeleted = false, string deletedBy = "", DateTime? deletedOn = null, string addedBy = "", DateTime? addedOn = null, string lastModifiedBy = "", DateTime? lastModifiedOn = null)
        {
            CountryCode = countryCode;
            CountryName = countryName;
            IsDeleted = isDeleted;
            DeletedBy = deletedBy;
            DeletedOn = deletedOn;
            AddedBy = addedBy;
            AddedOn = addedOn;
            LastModifiedBy = lastModifiedBy;
            LastModifiedOn = lastModifiedOn;
        }
    }
}