using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class UserAccount
    {
        public UserAccount()
        {

        }

        [Key, ForeignKey("UserProfile")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string UserName { get; set; }

        [Required]
        public string HashPassword { get; set; }

        [Required]
        public string SaltPassword { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [Required]
        public string EmailConfirmToken { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual UserAccountStatus UserAccountStatus { get; set; }
    }
}