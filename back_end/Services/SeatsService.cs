using back_end.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Services
{
    public class SeatsService : IService<Seat>
    {
        IApplicationContext db;
        public SeatsService(IApplicationContext context)
        {
            this.db = context;
            if (!db.Seats.Any())
            {
                db.Seats.Add(new Seat { Number = 5, SessionId = 7, Price = 100, IsFree = true });
                db.Seats.Add(new Seat { Number = 6, SessionId = 8, Price = 100, IsFree = false });
                db.Seats.Add(new Seat { Number = 7, SessionId = 8, Price = 100, IsFree = true });
                db.SaveChanges();
            }
        }

        public List<Seat> GetAll()
        {
            throw new NotImplementedException();
        }

        public Seat GetById(Int32 id)
        {
            throw new NotImplementedException();
        }
        public List<Seat> GetListById(Int32 sessionId)
        {
            return db.Seats.ToList().FindAll(x => x.SessionId == sessionId);
        }
        public Seat Add(Seat seat)
        {
            throw new NotImplementedException();
        }
        public Seat Delete(Int32 id)
        {
            throw new NotImplementedException();
        }

        public Seat Update(Int32 id)
        {
            Seat seat = db.Seats.Find(id);
            if (seat == null)
                return seat;

            seat.IsFree = false;
            db.SaveChanges();
            return seat;
        }

        public Seat GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
