using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComhaltasWebApi.Models
{
    public class InstrumentModel
    {
        public int id { get; set; }
        public String instrument_name { get; set; }
        public int competition_type { get; set; }

        public InstrumentModel (int id, String name, int type)
        {
            this.id = id;
            instrument_name = name;
            competition_type = type;
        }
    }
}