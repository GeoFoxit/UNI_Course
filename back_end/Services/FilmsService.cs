using back_end.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Services
{
    public class FilmsService : IService<Film>
    {
        IApplicationContext db;
        public FilmsService(IApplicationContext context)
        {
            this.db = context;
            if (!db.Films.Any())
            {
                db.Films.Add(new Film { Naming = "Star Wars", Genre = "Action", Rate = 4 });
                db.Films.Add(new Film { Naming = "Star Wars 2", Genre = "Action", Rate = 5 });
                db.Films.Add(new Film { Naming = "Star Wars 4", Genre = "Action", Rate = 2 });
                db.SaveChanges();
            }
        }
        public List<Film> GetAll()
        {
            return db.Films.ToList();
        }
        public Film GetById(Int32 id)
        {
            return db.Films.FirstOrDefault(x => x.Id == id);
        }
        public Film Add(Film film)
        {
            db.Films.Add(film);
            db.SaveChanges();
            return film;
        }
        public Film Delete(Int32 id)
        {
            Film film = db.Films.Find(id);
            if (film == null)
                return film;

            db.Films.Remove(film);
            db.SaveChanges();
            return film;
        }

        public List<Film> GetListById(Int32 id)
        {
            throw new NotImplementedException();
        }
        public Film Update(Int32 id)
        {
            throw new NotImplementedException();
        }
        public Film GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
