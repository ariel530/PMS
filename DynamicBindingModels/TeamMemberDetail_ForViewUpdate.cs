using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class TeamMemberDetail_ForViewUpdate
    {
        public int Id { get; set; }
        public string TeamMemberUserName { get; set; }
        public string TeamMemberFullName { get; set; }
        public string TeamMemberImagePath { get; set; }
        public int TeamMemberDesignationId { get; set; }
        public string TeamMemberDesignationName { get; set; }
        public string TeamMemberDesignationType { get; set; }
        public int TeamMemberCategoryId { get; set; }
        public string TeamMemberCategoryName { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public TeamMemberDetail_ForViewUpdate()
        {
        }

        public TeamMemberDetail_ForViewUpdate(int id, string teamMemberUserName, string teamMemberFullName, string teamMemberImagePath, int teamMemberDesignationId, string teamMemberDesignationName, string teamMemberDesignationType, int teamMemberCategoryId, string teamMemberCategoryName, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn)
        {
            Id = id;
            TeamMemberUserName = teamMemberUserName;
            TeamMemberFullName = teamMemberFullName;
            TeamMemberImagePath = teamMemberImagePath;
            TeamMemberDesignationId = teamMemberDesignationId;
            TeamMemberDesignationName = teamMemberDesignationName;
            TeamMemberDesignationType = teamMemberDesignationType;
            TeamMemberCategoryId = teamMemberCategoryId;
            TeamMemberCategoryName = teamMemberCategoryName;
            AddedBy = addedBy;
            AddedOn = addedOn;
            LastModifiedBy = lastModifiedBy;
            LastModifiedOn = lastModifiedOn;
        }
    }
}