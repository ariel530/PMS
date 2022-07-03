using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class Project_Country_Priority_ForDisplay
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCustomerId { get; set; }
        public string ProjectSearchingKeywords { get; set; }
        public string ProjectPath { get; set; }
        public string ProjectCountryCode { get; set; }
        public double ProjectEstimatedBudget { get; set; }
        public double ProjectTotalAmountSpent { get; set; }
        public string ProjectStatusName { get; set; }
        public string ProjectPriorityName { get; set; }
        public string ProjectTypeName { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ProjectDeliveredDate { get; set; }
        public DateTime? ProjectStartDate { get; set; }

        public Project_Country_Priority_ForDisplay()
        {
        }

        public Project_Country_Priority_ForDisplay(int id, string projectName, string projectCustomerId, string projectSearchingKeywords, string projectPath, string projectCountryCode, double projectEstimatedBudget, double projectTotalAmountSpent, string projectStatusName, string projectPriorityName, string projectTypeName, string lastModifiedBy, DateTime? lastModifiedOn, string addedBy, DateTime? addedOn, DateTime? projectDeliveredDate, DateTime? projectStartDate)
        {
            Id = id;
            ProjectName = projectName;
            ProjectCustomerId = projectCustomerId;
            ProjectSearchingKeywords = projectSearchingKeywords;
            ProjectPath = projectPath;
            ProjectCountryCode = projectCountryCode;
            ProjectEstimatedBudget = projectEstimatedBudget;
            ProjectTotalAmountSpent = projectTotalAmountSpent;
            ProjectStatusName = projectStatusName;
            ProjectPriorityName = projectPriorityName;
            ProjectTypeName = projectTypeName;
            LastModifiedBy = lastModifiedBy;
            LastModifiedOn = lastModifiedOn;
            AddedBy = addedBy;
            AddedOn = addedOn;
            ProjectDeliveredDate = projectDeliveredDate;
            ProjectStartDate = projectStartDate;
        }
    }
}