using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class UserPictureProfile
    {
        public UserPictureProfile()
        {
            
        }

        [Key, ForeignKey("UserProfile")]
        public int PictureId { get; set; }
        public byte[] PictureProfile { get; set; }

        public virtual UserProfile UserProfile  { get; set; }
    }
}