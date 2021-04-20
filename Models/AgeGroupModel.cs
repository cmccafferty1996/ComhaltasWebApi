using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComhaltasWebApi.Models
{
    public class AgeGroupModel
    {
        public int id { get; set; }
        public String category { get; set; }
        public String age_group { get; set; }

        public AgeGroupModel(int id, String cat, String age)
        {
            this.id = id;
            this.category = cat;
            this.age_group = age;
        }
    }
}