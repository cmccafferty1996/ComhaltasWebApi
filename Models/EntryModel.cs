using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComhaltasWebApi.Models
{
    public class EntryModel
    {
        public int id { get; set; }
        public int competition { get; set; }
        public int entrant { get; set; }
        public string entrantName { get; set; }
        public string instrumentList { get; set; }
        public bool registered { get; set; }

        public EntryModel(int id, int comp, int e, string names, string instr, bool reg)
        {
            this.id = id;
            competition = comp;
            entrant = e;
            entrantName = names;
            instrumentList = instr;
            registered = reg;
        }
    }
}