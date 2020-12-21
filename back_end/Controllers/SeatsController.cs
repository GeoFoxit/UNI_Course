using back_end.models;
using back_end.Services;
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
        IService<Seat> service;
        IService<Booking> bookingService;
        public SeatsController(ApplicationContext context)
        {
            service = new SeatsService(context);
            bookingService = new BookingService(context);
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
            return new ActionResult<IEnumerable<Seat>>(service.GetListById(sessionId));
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
            Seat seat = service.Update(id);
            if (seat == null)
                return NotFound();

            Booking booking = new Booking { SeatId = seat.Id };
            bookingService.Add(booking);

            Booking savedBooking = bookingService.GetById(seat.Id);
            return new ObjectResult(savedBooking);
        }
    }
}
