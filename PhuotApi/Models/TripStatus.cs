using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class TripStatus
    {
        public TripStatus()
        {
            this.Trip = new HashSet<Trip>();
        }
        [Key]
        public int TripStatusId { get; set; }
        public string TripStatusName { get; set; }
        public virtual ICollection<Trip> Trip { get; set; }
    }
}