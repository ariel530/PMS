using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string GenderName { get; set; }
        public string GenderDescription { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int CompanyId { get; set; }

        public Gender()
        {

        }

        public Gender(int id, string genderName)
        {
            Id = id;
            GenderName = genderName;
        }

        public Gender(int id, string genderName, string genderDescription, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, int companyId) : this(id, genderName)
        {
            GenderDescription = genderDescription;
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