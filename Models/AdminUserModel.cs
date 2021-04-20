using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComhaltasWebApi.Models
{
    public class AdminUserModel
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime last_logon { get; set; }

        public AdminUserModel (int id, string first, string sur, string user, string pass, DateTime logon)
        {
            this.id = id;
            first_name = first;
            surname = sur;
            username = user;
            password = pass;
            last_logon = logon;
        }
    }
}