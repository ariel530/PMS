using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class StaffDesignation
    {
        public int Id { get; set; }
        public string StaffDesignationName { get; set; }
        public string StaffDesignationDescription { get; set; }
        public int StaffDesignationRank { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int CompanyId { get; set; }

        public StaffDesignation()
        {

        }

        public StaffDesignation(int id, string staffDesignationName)
        {
            Id = id;
            StaffDesignationName = staffDesignationName;
        }

        public StaffDesignation(int id, string staffDesignationName, int staffDesignationRank)
        {
            Id = id;
            StaffDesignationName = staffDesignationName;
             StaffDesignationRank = staffDesignationRank;
        }

        public StaffDesignation(int id, string staffDesignationName, int staffDesignationRank,string staffDesignationDescription,bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, int companyId) : this(id, staffDesignationName,staffDesignationRank)
        {
            StaffDesignationDescription = staffDesignationDescription;
           
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