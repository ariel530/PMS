using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class TeamWiseStaffDesignation
    {
        public int Id { get; set; }
        public string TeamWiseStaffDesignationName { get; set; }
        public string TeamWiseStaffDesignationDescription { get; set; }
        public int TeamWiseStaffDesignationRank { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int CompanyId { get; set; }

        public TeamWiseStaffDesignation()
        {

        }

        public TeamWiseStaffDesignation(int id, string staffDesignationName)
        {
            Id = id;
            TeamWiseStaffDesignationName = staffDesignationName;
        }

        public TeamWiseStaffDesignation(int id, string staffDesignationName, int staffDesignationRank)
        {
            Id = id;
            TeamWiseStaffDesignationName = staffDesignationName;
            TeamWiseStaffDesignationRank = staffDesignationRank;
        }

        public TeamWiseStaffDesignation(int id, string staffDesignationName, int staffDesignationRank, string staffDesignationDescription, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, int companyId) : this(id, staffDesignationName, staffDesignationRank)
        {
            TeamWiseStaffDesignationDescription = staffDesignationDescription;

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