using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class UserPictureProfile
    {
        public UserPictureProfile()
        {
            
        }

        public int PictureId { get; set; }
        public byte[] PictureProfile { get; set; }

        public virtual UserProfile UserProfiles  { get; set; }
    }
}