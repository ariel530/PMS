using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class CustomerType
    {
        public int Id { get; set; }
        public string CustomerTypeName { get; set; }
        public string CustomerTypeDescription { get; set; }
        public string CustomerTypePoints { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string UserInfoUserName { get; set; }
        public CustomerType()
        {
        }

        public CustomerType(int id, string customerTypeName)
        {
            Id = id;
            CustomerTypeName = customerTypeName;
        }

        public CustomerType(int id, string customerTypeName, string customerTypeDescription, string customerTypePoints, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn , string userInfoUserName)
        {
            Id = id;
            CustomerTypeName = customerTypeName;
            CustomerTypeDescription = customerTypeDescription;
            CustomerTypePoints = customerTypePoints;
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