using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class EducationRecord
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Degree { get; set; }
        public int Year { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int CompanyId { get; set; }
        public EducationRecord()
        {
        }

        public EducationRecord(string degree, int year)
        {
            Degree = degree;
            Year = year;
        }

        public EducationRecord(string userId, string degree, int year, int companyId)
        {
            UserId = userId;
            Degree = degree;
            Year = year;
            CompanyId = companyId;
        }

        public EducationRecord(int id, string userId, string degree, int year, int companyId)
        {
            Id = id;
            UserId = userId;
            Degree = degree;
            Year = year;
            CompanyId = companyId;
        }

        public EducationRecord(string userId, string degree, int year, string addedBy, int companyId) : this(userId, degree, year, addedBy)
        {
            CompanyId = companyId;
        }

        public EducationRecord(string userId, string degree, int year, string addedBy)
        {
            UserId = userId;
            Degree = degree;
            Year = year;
            AddedBy = addedBy;
        }

        public EducationRecord(int id, string userId, string degree, int year, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, int companyId)
        {
            Id = id;
            UserId = userId;
            Degree = degree;
            Year = year;
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