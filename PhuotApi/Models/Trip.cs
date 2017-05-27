using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class Trip
    {
        public Trip()
        {
            this.TripPlace = new HashSet<TripPlace>();
        }
        [Key]
        public int TripId { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime Date { get; set; }

        [ForeignKey("TripStatus")]
        public int TripStatusId { get; set; }

        public virtual TripStatus TripStatus { get; set; }
        public virtual ICollection<TripPlace> TripPlace { get; set; }
    }
}