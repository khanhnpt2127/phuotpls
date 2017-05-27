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
        [Column(TypeName = "uniqueidentifier")]
        public Guid PictureId { get; set; }
        public string PictureProfile { get; set; }

        public virtual UserProfile UserProfile  { get; set; }
    }
}