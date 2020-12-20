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
    public class SeatsController : ControllerBase
    {
        ApplicationContext db;
        public SeatsController(ApplicationContext context)
        {
            db = context;
            if (!db.Seats.Any())
            {
                db.Seats.Add(new Seat { Number = 5, SessionId = 7, Price = 100, IsFree = true });
                db.Seats.Add(new Seat { Number = 6, SessionId = 8, Price = 100, IsFree = false });
                db.Seats.Add(new Seat { Number = 6, SessionId = 8, Price = 100, IsFree = true });
                db.SaveChanges();
            }
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Seat>> Get()
        //{
        //    return db.Seats.ToList();
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Seat> GetById(Int32 id)
        //{
        //    Seat seat = db.Seats.FirstOrDefault(x => x.Id == id);
        //    if (seat == null)
        //        return NotFound();
        //    return new ObjectResult(seat);
        //}

        [HttpGet("bysession/{sessionId}")]
        public ActionResult<IEnumerable<Seat>> GetBySessionId(Int32 sessionId)
        {
            return db.Seats.ToList().FindAll(x => x.SessionId == sessionId);
        }

        //[HttpPost]
        //public ActionResult<Seat> AddSeat(Seat seat)
        //{
        //    db.Seats.Add(seat);
        //    db.SaveChanges();
        //    return new ObjectResult(seat);
        //}

        //[HttpDelete("{id}")]
        //public ActionResult<Seat> DeleteSeat(Int32 id)
        //{
        //    Seat seat = db.Seats.Find(id);
        //    if (seat == null)
        //        return NotFound();

        //    db.Seats.Remove(seat);
        //    db.SaveChanges();
        //    return new ObjectResult(seat);
        //}

        [HttpPut("{id}")]
        public ActionResult<Seat> Book(Int32 id)
        {
            Seat seat = db.Seats.Find(id);
            if (seat == null)
                return NotFound();

            seat.IsFree = false;
            db.SaveChanges();

            Booking booking = new Booking { SeatId = seat.Id };
            db.Bookings.Add(booking);
            db.SaveChanges();

            Booking book = db.Bookings.FirstOrDefault(x => x.SeatId == seat.Id);
            return new ObjectResult(book);
        }
    }
}
