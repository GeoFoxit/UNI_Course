using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.models
{
    public class Session
    {
        public Int32 Id { get; set; }
        public DateTime DateTime { get; set; }
        public Int32 FilmId { get; set; }
    }
}
