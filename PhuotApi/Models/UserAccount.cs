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
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string HashPassword { get; set; }

        [Required]
        public byte[] SaltPassword { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [Column(TypeName = "varchar")]
        public string EmailConfirmToken { get; set; }

        [Required]
        [ForeignKey("UserAccountStatus")]
        public int StatusId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual UserAccountStatus UserAccountStatus { get; set; }
    }
}