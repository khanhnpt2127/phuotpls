using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class Place
    {
        public Place()
        {
            this.NonnativePlace = new HashSet<NonnativePlace>();
            this.TripPlace = new HashSet<TripPlace>();
        }
        [Key]
        public int PlaceId { get; set; }
        public string Longtitude { get; set; }
        public string Attitude { get; set; }
        public string PlaceName { get; set; }

        [ForeignKey("PlaceType")]
        public int TypeId { get; set; }
        public virtual ICollection<NonnativePlace> NonnativePlace { get; set; }
        public virtual PlaceType PlaceType { get; set; }
        public virtual ICollection<TripPlace> TripPlace { get; set; }
    }
}