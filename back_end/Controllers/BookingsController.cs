using back_end.models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        ApplicationContext db;
        public BookingsController(ApplicationContext context)
        {
            db = context;
            //if (!db.Bookings.Any())
            //{
            //    db.Bookings.Add(new Booking { SeatId = 1 });
            //    db.SaveChanges();
            //}
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Booking>> Get()
        //{
        //    return db.Bookings.ToList();
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Booking> GetById(Int32 id)
        //{
        //    Booking booking = db.Bookings.FirstOrDefault(x => x.Id == id);
        //    if (booking == null)
        //        return NotFound();
        //    return new ObjectResult(booking);
        //}

        //[HttpPost]
        //public ActionResult<Booking> AddBooking(Booking booking)
        //{
        //    Seat seat = db.Seats.Find(booking.SeatId);
        //    if (seat == null)
        //        return NotFound();

        //    seat.IsFree = false;
        //    db.SaveChanges();

        //    db.Bookings.Add(booking);
        //    db.SaveChanges();
        //    return new ObjectResult(booking);
        //}

        //[HttpDelete("{id}")]
        //public ActionResult<Booking> DeleteBooking(Int32 id)
        //{
        //    Booking booking = db.Bookings.Find(id);
        //    if (booking == null)
        //        return NotFound();

        //    db.Bookings.Remove(booking);
        //    db.SaveChanges();
        //    return new ObjectResult(booking);
        //}
    }
}
