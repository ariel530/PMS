using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class StaffDetail
    {
       

        public int Id { get; set; }
        public string StaffInfoId { get; set; }
        public  string StaffPassportNumber { get; set; }
        public string StaffCardNumber { get; set; }
        public float StaffSalary { get; set; }
        public int StaffCategoryId { get; set; }
        public int StaffDesignationId { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int CompanyId { get; set; }

        public StaffDetail()
        {
        }

        public StaffDetail(int id, string staffInfoId, string staffPassportNumber, string staffCardNumber, float staffSalary, int staffCategoryId, int staffDesignationId, string addedBy, DateTime? addedOn, int companyId)
        {
            Id = id;
            StaffInfoId = staffInfoId;
            StaffPassportNumber = staffPassportNumber;
            StaffCardNumber = staffCardNumber;
            StaffSalary = staffSalary;
            StaffCategoryId = staffCategoryId;
            StaffDesignationId = staffDesignationId;
            AddedBy = addedBy;
            AddedOn = addedOn;
            CompanyId = companyId;
        }

        public StaffDetail(int id, string staffInfoId, string staffPassportNumber, string staffCardNumber, float staffSalary, int staffCategoryId, int staffDesignationId, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, int companyId)
        {
            Id = id;
            StaffInfoId = staffInfoId;
            StaffPassportNumber = staffPassportNumber;
            StaffCardNumber = staffCardNumber;
            StaffSalary = staffSalary;
            StaffCategoryId = staffCategoryId;
            StaffDesignationId = staffDesignationId;
            IsDeleted = isDeleted;
            DeletedBy = deletedBy;
            DeletedOn = deletedOn;
            AddedBy = addedBy;
            AddedOn = addedOn;
            LastModifiedBy = lastModifiedBy;
            LastModifiedOn = lastModifiedOn;
            CompanyId = companyId;
        }

        public StaffDetail(string staffInfoId, string staffPassportNumber, string staffCardNumber, float staffSalary, int staffCategoryId, int staffDesignationId, string addedBy, int companyId)
        {
            StaffInfoId = staffInfoId;
            StaffPassportNumber = staffPassportNumber;
            StaffCardNumber = staffCardNumber;
            StaffSalary = staffSalary;
            StaffCategoryId = staffCategoryId;
            StaffDesignationId = staffDesignationId;
            AddedBy = addedBy;
            CompanyId = companyId;
        }
    }
}