using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class TeamInfoOverview
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public int TeamTotalMember { get; set; }
        public bool TeamIsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int CompanyId { get; set; }

        public TeamInfoOverview()
        {
        }

        public TeamInfoOverview(string teamName, string teamDescription, int teamTotalMember, string addedBy, DateTime? addedOn, int companyId)
        {
            TeamName = teamName;
            TeamDescription = teamDescription;
            TeamTotalMember = teamTotalMember;
            AddedBy = addedBy;
            AddedOn = addedOn;
            CompanyId = companyId;
        }

        public TeamInfoOverview(int id, string teamName, string teamDescription, int teamTotalMember, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, int companyId)
        {
            Id = id;
            TeamName = teamName;
            TeamDescription = teamDescription;
            TeamTotalMember = teamTotalMember;
            IsDeleted = isDeleted;
            DeletedBy = deletedBy;
            DeletedOn = deletedOn;
            AddedBy = addedBy;
            AddedOn = addedOn;
            LastModifiedBy = lastModifiedBy;
            LastModifiedOn = lastModifiedOn;
            CompanyId = companyId;
        }
    }
}