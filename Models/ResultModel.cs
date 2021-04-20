using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComhaltasWebApi.Models
{
    public class ResultModel
    {
        public int id { get; set; }
        public int competition { get; set; }
        public int first { get; set; }
        public Nullable<int> second { get; set; }
        public Nullable<int> third { get; set; }
        public Nullable<int> recommended { get; set; }

        public ResultModel (int id, int comp, int first, int sec, int third, int rec)
        {
            this.id = id;
            this.competition = comp;
            this.first = first;
            this.second = sec;
            this.third = third;
            this.recommended = rec;
        }
    }
}