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
                db.Seats.Add(new Seat { Number = 1, IsFree = false, Price = 100, SessionId = 1 });
                db.Seats.Add(new Seat { Number = 2, IsFree = true, Price = 100, SessionId = 1 });
                db.Seats.Add(new Seat { Number = 3, IsFree = true, Price = 100, SessionId = 1 });
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
            Seat seat = db.Seats.FirstOrDefault(x => x.Id == id);
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
