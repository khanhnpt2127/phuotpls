using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class UserAccount
    {
        public UserAccount()
        {
            
        }

        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string HashPassword { get; set; }
        public string SaltPassword { get; set; }
        public string Email { get; set; }
        public string EmailConfirmToken { get; set; }
        public int AccountStatusId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual UserAccountStatus UserAccountStatus { get; set; }
    }
}