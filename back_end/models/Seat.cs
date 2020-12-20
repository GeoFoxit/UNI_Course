using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.models
{
    public class Seat
    {
        public Int32 Id { get; set; }
        public Int16 Number { get; set; }
        public Int32 SessionId { get; set; }
        public Int32 Price { get; set; }
        public Boolean IsFree { get; set; }
    }
}
