using back_end.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Services
{
    public class BookingsService : IService<Booking>
    {
        IApplicationContext db;
        public BookingsService(IApplicationContext context)
        {
            this.db = context;
            if (!db.Bookings.Any())
            {
                db.Bookings.Add(new Booking { SeatId = 15 });
                db.SaveChanges();
            }
        }

        public Booking Add(Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
            return booking;
        }

        public Booking GetById(int seatId)
        {
            return db.Bookings.FirstOrDefault(x => x.SeatId == seatId);
        }

        public Booking Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetListById(int id)
        {
            throw new NotImplementedException();
        }

        public Booking Update(int id)
        {
            throw new NotImplementedException();
        }
        public Booking GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
