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
            if (film == null)
                throw new ArgumentNullException();

            db.Films.Add(film);
            db.SaveChanges();
            return film;
        }
        public Film Delete(Int32 id)
        {
            Film film = db.Films.FirstOrDefault(x => x.Id == id);
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
