using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class StaffCategory
    {

        public int Id { get; set; }
        public string StaffCategoryName { get; set; }
        public string StaffCategoryDescription { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int CompanyId { get; set; }

        public StaffCategory()
        {

        }

        public StaffCategory(int id, string staffCategoryName)
        {
            Id = id;
            StaffCategoryName = staffCategoryName;
        }

        public StaffCategory(int id, string staffCategoryName, string staffCategoryDescription, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, int companyId) : this(id, staffCategoryName)
        {
            StaffCategoryDescription = staffCategoryDescription;
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