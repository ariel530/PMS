using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class TeamInfoMemberDetail
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string TeamMemberId  { get; set; }
        public int TeamMemberDesignationId { get; set; }
        public string TeamMemberDesignationType { get; set; }
        public string TeamMemberDeleteReason { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int CompanyId { get; set; }

        public TeamInfoMemberDetail()
        {
        }


        public TeamInfoMemberDetail(string teamMemberId, int teamMemberDesignationId, string teamMemberDesignationType, string addedBy, DateTime? addedOn, int companyId)
        {
            TeamMemberId = teamMemberId;
            TeamMemberDesignationId = teamMemberDesignationId;
            TeamMemberDesignationType = teamMemberDesignationType;
            AddedBy = addedBy;
            AddedOn = addedOn;
            CompanyId = companyId;
        }

        public TeamInfoMemberDetail(int id, int teamId, string teamMemberId, int teamMemberDesignationId, string teamMemberDesignationType, string teamMemberDeleteReason, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn, int companyId)
        {
            Id = id;
            TeamId = teamId;
            TeamMemberId = teamMemberId;
            TeamMemberDesignationId = teamMemberDesignationId;
            TeamMemberDesignationType = teamMemberDesignationType;
            TeamMemberDeleteReason = teamMemberDeleteReason;
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