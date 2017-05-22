using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class UserProfile
    {
        public UserProfile()
        {
            
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(300)]
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }

        //Each user only has one picture profile
        //Foreign key
        public virtual UserPictureProfile UserPictureProfile { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}