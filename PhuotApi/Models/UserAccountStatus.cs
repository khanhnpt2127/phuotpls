using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class UserAccountStatus
    {
        public UserAccountStatus()
        {
            this.UserAccounts = new HashSet<UserAccount>();
        }

        [Key]
        public int StatusId { get; set; }
        public string Status { get; set; }
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}