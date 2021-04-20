using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComhaltasWebApi.Models
{
    public class CompetitionsModel
    {
        public int id { get; set; }
        public int competition_number { get; set; }
        public String competition_name { get; set; }
        public int age_group { get; set; }
        public DateTime competition_date { get; set; }

        public CompetitionsModel(int id, int num, String name, int age, DateTime date)
        {
            this.id = id;
            this.competition_number = num;
            this.competition_name = name;
            this.age_group = age;
            this.competition_date = date;
        }
    }
}