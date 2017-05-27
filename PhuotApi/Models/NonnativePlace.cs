using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class NonnativePlace
    {
        [Key]
        public int NonnativePlaceId { get; set; }
        public string NonnativePlaceName { get; set; }

        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
    }
}