using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class Project_Country_ProjectType_ProjectStatus_ProjectPriority_ForAddUpdate
    {
        public List<ProjectPriority> ProjectPriorityData { get; set; }
        public List<ProjectStatus> ProjectStatusData { get; set; }
        public List<ProjectType> ProjectTypeData { get; set; }
        public List<CustomerInfo> CustomerInfoData { get; set; }
        public List<Country> CountryData { get; set; }
        public List<ProjectFilesDetail> ProjectFilesDetails { get; set; }
        public ProjectInfo ProjectInfoData { get; set; }
    }
}