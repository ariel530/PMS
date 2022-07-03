using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class ProjectInfo
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public int ProjectStatusId { get; set; }
        public string ProjectClientCompany { get; set; }
        public int ProjectTypeId { get; set; }
        public int ProjectPriorityId { get; set; }
        public string ProjectSearchingKeywords { get; set; }
        public string ProjectPath { get; set; }
        public string ProjectCustomerId { get; set; }
        public string ProjectCountryCode { get; set; }
        public double ProjectEstimatedBudget { get; set; }
        public double ProjectTotalAmountSpent { get; set; }
        public int ProjectEstimatedDuration { get; set; }
        public DateTime? ProjectReceivedDate { get; set; }
        public DateTime? ProjectDeliveredDate { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectSubmitDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime? ProjectStartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime? ProjectEndTime { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string UserInfoUserName { get; set; }
        public ProjectInfo()
        {
        }

        public ProjectInfo(int id, string projectName, string projectDescription, int projectStatusId, string projectClientCompany, int projectTypeId, int projectPriorityId, string projectSearchingKeywords, string projectPath, string projectCustomerId, string projectCountryCode, double projectEstimatedBudget, double projectTotalAmountSpent, int projectEstimatedDuration, DateTime? projectReceivedDate, DateTime? projectDeliveredDate, DateTime? projectStartDate, DateTime? projectSubmitDate, DateTime? projectStartTime, DateTime? projectEndTime, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, string userInfoUserName)
        {
            Id = id;
            ProjectName = projectName;
            ProjectDescription = projectDescription;
            ProjectStatusId = projectStatusId;
            ProjectClientCompany = projectClientCompany;
            ProjectTypeId = projectTypeId;
            ProjectPriorityId = projectPriorityId;
            ProjectSearchingKeywords = projectSearchingKeywords;
            ProjectPath = projectPath;
            ProjectCustomerId = projectCustomerId;
            ProjectCountryCode = projectCountryCode;
            ProjectEstimatedBudget = projectEstimatedBudget;
            ProjectTotalAmountSpent = projectTotalAmountSpent;
            ProjectEstimatedDuration = projectEstimatedDuration;
            ProjectReceivedDate = projectReceivedDate;
            ProjectDeliveredDate = projectDeliveredDate;
            ProjectStartDate = projectStartDate;
            ProjectSubmitDate = projectSubmitDate;
            ProjectStartTime = projectStartTime;
            ProjectEndTime = projectEndTime;
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