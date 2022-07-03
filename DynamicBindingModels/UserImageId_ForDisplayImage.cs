using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.DynamicBindingModels
{
    public class UserImageId_ForDisplayImage
    {
        public string UserId { get; set; }
        public string ImagePath { get; set; }

        public UserImageId_ForDisplayImage()
        {
        }

        public UserImageId_ForDisplayImage(string imagePathId)
        {
            string[] data = imagePathId.Split(':');
            ImagePath = data[0].Trim();
            UserId = data[1].Trim();
        }

        public UserImageId_ForDisplayImage(string userId, string imagePath)
        {
            UserId = userId;
            ImagePath = imagePath;
        }
    }
}