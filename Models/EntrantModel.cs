using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComhaltasWebApi.Models
{
    public class EntrantModel
    {
        public int id { get; set; }
        public String entrant_name { get; set; }
        public int branch { get; set; }
        public DateTime dob { get; set; }

        public EntrantModel(int id, String name, int branch, DateTime birth)
        {
            this.id = id;
            this.entrant_name = name;
            this.branch = branch;
            this.dob = birth;
        }
    }
}