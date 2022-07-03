using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class TeamMemberOverview_Detail_ForViewUpdate
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public List<TeamMemberDetail_ForViewUpdate> TeamMemberDetails { get; set; }

        public TeamMemberOverview_Detail_ForViewUpdate()
        {
            TeamMemberDetails = new List<TeamMemberDetail_ForViewUpdate>();
        }

        public TeamMemberOverview_Detail_ForViewUpdate(int id, string teamName, string teamDescription)
        {
            Id = id;
            TeamName = teamName;
            TeamDescription = teamDescription;
            TeamMemberDetails = new List<TeamMemberDetail_ForViewUpdate>();
        }

        public TeamMemberOverview_Detail_ForViewUpdate(int id, string teamName, string teamDescription, List<TeamMemberDetail_ForViewUpdate> teamMemberDetails)
        {
            Id = id;
            TeamName = teamName;
            TeamDescription = teamDescription;
            TeamMemberDetails = teamMemberDetails;
        }
    }
}