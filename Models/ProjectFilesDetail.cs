using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class ProjectFilesDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FilePath { get; set; }
        public int ProjectId { get; set; }

        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public ProjectFilesDetail()
        {
        }

        public ProjectFilesDetail(int id, string title, string fileName, string fileSize, string filePath, int projectId, bool isDeleted, string deletedBy, DateTime? deletedOn, string addedBy, DateTime? addedOn, string lastModifiedBy, DateTime? lastModifiedOn)
        {
            Id = id;
            Title = title;
            FileName = fileName;
            FileSize = fileSize;
            FilePath = filePath;
            ProjectId = projectId;
            IsDeleted = isDeleted;
            DeletedBy = deletedBy;
            DeletedOn = deletedOn;
            AddedBy = addedBy;
            AddedOn = addedOn;
            LastModifiedBy = lastModifiedBy;
            LastModifiedOn = lastModifiedOn;
        }
    }
}