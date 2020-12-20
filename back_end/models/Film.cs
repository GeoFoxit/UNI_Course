using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.models
{
    public class Film
    {
        public Int32 Id { get; set; }
        public String Naming { get; set; }
        public String Genre { get; set; }
        public Int16 Rate { get; set; }
    }
}
