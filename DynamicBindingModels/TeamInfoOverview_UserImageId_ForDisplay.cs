using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class TeamInfoOverview_UserImageId_ForDisplay
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public int TeamTotalMember { get; set; }
        public bool IsActivated { get; set; }
        public List<UserImageId_ForDisplayImage> UserImagesRecord { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public TeamInfoOverview_UserImageId_ForDisplay(int id, string teamName, string teamDescription, int teamTotalMember, bool isActivated, string userImagesRecord, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn) : this(id, teamName, teamDescription, teamTotalMember, isActivated, userImagesRecord)
        {
            AddedBy = addedBy;
            AddedOn = addedOn;
            LastModifiedBy = lastModifiedBy;
            LastModifiedOn = lastModifiedOn;
        }

        public TeamInfoOverview_UserImageId_ForDisplay(int id, string teamName, string teamDescription, int teamTotalMember, bool isActivated,string userImages)
        {
            Id = id;
            TeamName = teamName;
            TeamDescription = teamDescription;
            TeamTotalMember = teamTotalMember;
            IsActivated = isActivated;
            string[] data = userImages.Split(';');
            UserImagesRecord = new List<UserImageId_ForDisplayImage>();
            foreach (string _temp in data)
            {
                UserImagesRecord.Add(new UserImageId_ForDisplayImage(_temp));
            }
        }

        public TeamInfoOverview_UserImageId_ForDisplay(int id, string teamName, string teamDescription, int teamTotalMember, bool isActivated, List<UserImageId_ForDisplayImage> userImagesRecord)
        {
            Id = id;
            TeamName = teamName;
            TeamDescription = teamDescription;
            TeamTotalMember = teamTotalMember;
            IsActivated = isActivated;
            UserImagesRecord = userImagesRecord;
        }
    }
}