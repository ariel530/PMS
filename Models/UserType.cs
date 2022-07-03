using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class UserType
    {
        public int Id { get; set; }
        public string UserTypeName { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public UserType()
        {
        }

        public UserType(int id, string userTypeName,  bool isDeleted = false, string deletedBy = "", DateTime? deletedOn = null, string addedBy = "", DateTime? addedOn = null, string lastModifiedBy = "", DateTime? lastModifiedOn = null)
        {
            Id = id;
            UserTypeName = userTypeName;
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