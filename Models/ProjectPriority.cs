using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class ProjectPriority
    {
        public int Id { get; set; }
        public string ProjectPriorityName { get; set; }
        public string ProjectPriorityBackGroundColor { get; set; }
        public string ProjectPriorityTextColor { get; set; }
        public string ProjectPriorityDescription { get; set; }
        public int ProjectPriorityPoints { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string UserInfoUserName { get; set; }
        public ProjectPriority()
        {

        }
        public ProjectPriority(int id, string projectPriorityName)
        {
            Id = id;
            ProjectPriorityName = projectPriorityName;

        }
        public ProjectPriority(int id, string projectPriorityName, string projectPriorityBackGroundColor, string projectPriorityTextColor, string projectPriorityDescription, int projectPriorityPoints, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn,string userInfoUserName)
        {
            Id = id;
            ProjectPriorityName = projectPriorityName;
            ProjectPriorityBackGroundColor = projectPriorityBackGroundColor;
            ProjectPriorityTextColor = projectPriorityTextColor;
            ProjectPriorityDescription = projectPriorityDescription;
            ProjectPriorityPoints = projectPriorityPoints;
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