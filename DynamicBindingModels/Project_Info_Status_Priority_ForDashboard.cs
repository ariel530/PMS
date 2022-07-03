using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class Project_Info_Status_Priority_ForDashboard
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCustomerId { get; set; }
        public double ProjectEstimatedBudget { get; set; }
        public DateTime? ProjectDeliveredDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime? ProjectEndTime { get; set; }
        public string ProjectStatusName { get; set; }
        public string ProjectStatusBackGroundColor { get; set; }
        public string ProjectStatusTextColor { get; set; }
        public string ProjectPriorityName { get; set; }
        public string ProjectPriorityBackGroundColor { get; set; }
        public string ProjectPriorityTextColor { get; set; }
        public DateTime? ActualDeliveryDateTime { get; set; }

        public Project_Info_Status_Priority_ForDashboard()
        {

        }
        public Project_Info_Status_Priority_ForDashboard(int id, string projectName, string projectCustomerId, double projectEstimatedBudget, DateTime? projectDeliveredDate, DateTime? projectEndTime, string projectStatusName, string projectStatusBackGroundColor, string projectStatusTextColor, string projectPriorityName, string projectPriorityBackGroundColor, string projectPriorityTextColor)
        {
            Id = id;
            ProjectName = projectName;
            ProjectCustomerId = projectCustomerId;
            ProjectEstimatedBudget = projectEstimatedBudget;
            ProjectDeliveredDate = projectDeliveredDate;
            ProjectEndTime = projectEndTime;
            ProjectStatusName = projectStatusName;
            ProjectStatusBackGroundColor = projectStatusBackGroundColor;
            ProjectStatusTextColor = projectStatusTextColor;
            ProjectPriorityName = projectPriorityName;
            ProjectPriorityBackGroundColor = projectPriorityBackGroundColor;
            ProjectPriorityTextColor = projectPriorityTextColor;
            if (projectDeliveredDate.HasValue && projectEndTime.HasValue)
            {
                ActualDeliveryDateTime = new DateTime(projectDeliveredDate.Value.Year, projectDeliveredDate.Value.Month
                    , projectDeliveredDate.Value.Day, projectEndTime.Value.Hour, projectEndTime.Value.Minute, projectEndTime.Value.Second);

            }
            else if (projectDeliveredDate.HasValue)
            {

                ActualDeliveryDateTime = new DateTime(projectDeliveredDate.Value.Year, projectDeliveredDate.Value.Month
                     , projectDeliveredDate.Value.Day, 0, 0, 0);

            }
            else if (projectEndTime.HasValue)
            {
                DateTime temp = DateTime.Now;
                ActualDeliveryDateTime = new DateTime(temp.Year, temp.Month
                    , temp.Day, projectEndTime.Value.Hour, projectEndTime.Value.Minute, projectEndTime.Value.Second);

            }
            else
            {
                ActualDeliveryDateTime = null;
            }
        }
    }
} 