using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ComhaltasWebApi.Models
{
    public class BranchModel
    {
        public int id { get; set; }
        public String branch_name { get; set; }

        public BranchModel (int id, String name)
        {
            this.id = id;
            this.branch_name = name;
        }
    }
}