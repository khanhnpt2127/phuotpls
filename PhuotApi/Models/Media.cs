using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class Media
    {
        [Key]
        public int MediaId { get; set; }
        public string MediaUrl { get; set; }

        //[ForeignKey("UserPlace")]
        //public int UserId { get; set; }
        //[ForeignKey("UserPlace")]
        //public int PlaceId { get; set; }
        public virtual UserPlace UserPlace { get; set; }
    }
}