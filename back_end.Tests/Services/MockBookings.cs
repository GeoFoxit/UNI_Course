using back_end.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace back_end.Tests.Services
{
    class MockBookings
    {
        public List<Booking> Bookings;

        public MockBookings()
        {
            Bookings = new List<Booking>();
            Bookings.Add(new Booking { Id = 1, SeatId = 1});
        }
    }
}
