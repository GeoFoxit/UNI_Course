using back_end.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Services
{
    public class SessionsService : IService<Session>
    {
        IApplicationContext db;
        public SessionsService(IApplicationContext context)
        {
            this.db = context;
            if (!db.Sessions.Any())
            {
                db.Sessions.Add(new Session { DateTime = new DateTime(2020, 12, 12, 20, 0, 0), FilmId = 1 });
                db.Sessions.Add(new Session { DateTime = new DateTime(2020, 10, 10, 18, 0, 0), FilmId = 1 });
                db.SaveChanges();
            }
        }
        public List<Session> GetAll()
        {
            return db.Sessions.ToList();
        }
        public List<Session> GetListById(Int32 filmId)
        {
            return db.Sessions.ToList().FindAll(x => x.FilmId == filmId);
        }
        public Session Add(Session session)
        {
            db.Sessions.Add(session);
            db.SaveChanges();

            for (Int16 c = 1; c < 37; c++)
            {
                Seat seat = new Seat { IsFree = true, Number = c, Price = 120, SessionId = session.Id };
                db.Seats.Add(seat);
            }

            db.SaveChanges();

            return session;
        }
        public Session Delete(Int32 id)
        {
            Session session = db.Sessions.Find(id);
            if (session == null)
                return session;

            db.Sessions.Remove(session);
            db.SaveChanges();
            return session;
        }
        public Session GetById(Int32 id)
        {
            throw new NotImplementedException();
        }
        public Session Update(Int32 id)
        {
            throw new NotImplementedException();
        }
        public Session GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
