using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class TripPlace
    {
        [Key]
        [Column(Order = 1)]
        public int TripId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PlaceId { get; set; }
        public float FromPlace { get; set; }
        public float ToPlace { get; set; }
        public int MarkRoute { get; set; }


    }
}