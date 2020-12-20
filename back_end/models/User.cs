using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.models
{
    public class User
    {
        public Int32 Id { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
    }
}
