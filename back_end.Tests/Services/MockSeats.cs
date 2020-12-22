using back_end.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace back_end.Tests.Services
{
    class MockSeats
    {
        public List<Seat> Seats;

        public MockSeats()
        {
            Seats = new List<Seat>();
            Seats.Add(new Seat { Id = 1, Number = 1, IsFree = false, Price = 100, SessionId = 2 });
            Seats.Add(new Seat { Id = 2, Number = 2, IsFree = true, Price = 100, SessionId = 2 });
            Seats.Add(new Seat { Id = 3, Number = 3, IsFree = true, Price = 100, SessionId = 2 });
        }
    }
}
