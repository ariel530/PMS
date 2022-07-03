using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class ProjectType
    {
        public int Id { get; set; }
        public string ProjectTypeName { get; set; }
        public string ProjectTypeDescription { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string UserInfoUserName { get; set; }
        public ProjectType()
        {

        }

        public ProjectType(int id, string projectTypeName)
        {
            Id = id;
            ProjectTypeName = projectTypeName;
        }

        public ProjectType(int id, string projectTypeName, string projectTypeDescription, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, string userInfoUserName)
        {
            Id = id;
            ProjectTypeName = projectTypeName;
            ProjectTypeDescription = projectTypeDescription;
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