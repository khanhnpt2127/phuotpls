using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class PlaceType
    {
        public PlaceType()
        {
            this.Place = new HashSet<Place>();
        }

        [Key]
        public int TypeId { get; set; }

        public string TypeName { get; set; }

        public virtual ICollection<Place> Place { get; set; }
    }
}