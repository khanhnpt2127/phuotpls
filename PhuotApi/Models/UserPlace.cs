using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class UserPlace
    {
        public UserPlace()
        {
            this.Media = new HashSet<Media>();
        }

        [Key]
        [Column(TypeName = "uniqueidentifier", Order = 1)]
        public Guid UserId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PlaceId { get; set; }

        public virtual ICollection<Media> Media { get; set; }
    }
}