using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhuotApi.Models
{
    public class UserInfo
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int statusId { get; set; } = 2;

    }
}