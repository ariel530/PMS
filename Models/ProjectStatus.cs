using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class ProjectStatus
    {
        public int Id { get; set; }
        public string ProjectStatusName { get; set; }
        public string ProjectStatusBackGroundColor { get; set; }
        public string ProjectStatusTextColor { get; set; }
        public string ProjectStatusDescription { get; set; }
        public bool ProjectStatusShowInList { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string UserInfoUserName { get; set; }
        public ProjectStatus()
        {

        }

        public ProjectStatus(int id, string projectStatusName)
        {
            Id = id;
            ProjectStatusName = projectStatusName;
        }

        public ProjectStatus(int id, string projectStatusName, string projectStatusBackGroundColor, string projectStatusTextColor, string projectStatusDescription, bool projectStatusShowInList, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn,string userInfoUserName)
        {
            Id = id;
            ProjectStatusName = projectStatusName;
            ProjectStatusBackGroundColor = projectStatusBackGroundColor;
            ProjectStatusTextColor = projectStatusTextColor;
            ProjectStatusDescription = projectStatusDescription;
            ProjectStatusShowInList = projectStatusShowInList;
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