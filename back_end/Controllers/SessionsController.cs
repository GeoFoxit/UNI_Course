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
    public class SessionsController : ControllerBase
    {
        ApplicationContext db;
        public SessionsController(ApplicationContext context)
        {
            db = context;
            if (!db.Sessions.Any())
            {
                //db.Sessions.Add(new Session { DateTime = new DateTime(2020, 12, 12, 20, 0, 0), FilmId = 2});
                //db.Sessions.Add(new Session { DateTime = new DateTime(2020, 10, 10, 18, 0, 0), FilmId = 2 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Session>> Get()
        {
            return db.Sessions.ToList();
        }

        //[HttpGet("{id}")]
        //public ActionResult<Session> GetById(Int32 id)
        //{
        //    Session seans = db.Sessions.FirstOrDefault(x => x.Id == id);
        //    if (seans == null)
        //        return NotFound();
        //    return new ObjectResult(seans);
        //}

        [HttpGet("byfilm/{filmId}")]
        public ActionResult<IEnumerable<Session>> GetByFilmId(Int32 filmId)
        {
            return db.Sessions.ToList().FindAll(x => x.FilmId == filmId);
        }

        [HttpPost]
        public ActionResult<Session> AddSession(Session session)
        {
            db.Sessions.Add(session);
            db.SaveChanges();

            for (Int16 c = 1; c < 37; c++)
            {
                Seat seat = new Seat { IsFree = true, Number = c, Price = 100, SessionId = session.Id };
                db.Seats.Add(seat);
            }
            
            db.SaveChanges();
            return new ObjectResult(session);
        }

        [HttpDelete("{id}")]
        public ActionResult<Session> DeleteSession(Int32 id)
        {
            Session session = db.Sessions.Find(id);
            if (session == null)
                return NotFound();

            db.Sessions.Remove(session);
            db.SaveChanges();
            return new ObjectResult(session);
        }
    }
}
