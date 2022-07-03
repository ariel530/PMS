using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class Project_Country_Status_DetailsForView
    {
        public ProjectInfo ProjectInfoData { get; set; }
        public string ProjectStatusName { get; set; }
        public string ProjectPriorityName { get; set; }
        public string ProjectTypeName { get; set; }
        public string ProjectCountryName { get; set; }

        public List<ProjectFilesDetail> ProjectFilesDetails { get; set; }


    }
}