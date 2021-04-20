using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComhaltasWebApi.Models
{
    public class ResultsTableRow
    {
        public string place { get; set; }
        public string name { get; set; }
        public string instruments { get; set; }
        public string branch { get; set; }

        public ResultsTableRow (string place, string name, string instr, string branch)
        {
            this.place = place;
            this.name = name;
            this.instruments = instr;
            this.branch = branch;
        }
    }
}