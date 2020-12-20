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
                db.Seats.Add(new Seat { Number = 5, SessionId = 1, Price = 100, IsFree = true });
                db.Seats.Add(new Seat { Number = 6, SessionId = 1, Price = 100, IsFree = false });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Seat>> Get()
        {
            return db.Seats.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Seat> GetById(Int32 id)
        {
            Seat seat = db.Seats.FirstOrDefault(x => x.Id == id);
            if (seat == null)
                return NotFound();
            return new ObjectResult(seat);
        }
    }
}
