using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class TeamWiseDesignation_StaffCategory_ForTeamInsertion
    {
        public  List<StaffCategory> StaffCategories { get; set; }
        public List<TeamWiseStaffDesignation> TeamWiseStaffDesignations { get; set; }

    }
}