using back_end.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmsController : ControllerBase
    {
        ApplicationContext db;
        public FilmsController(ApplicationContext context)
        {
            db = context;
            if (!db.Films.Any())
            {
                db.Films.Add(new Film { Naming= "The Dark Knight", Genre= "Триллер", Rate=5 });
                db.Films.Add(new Film { Naming= "The Godfather", Genre= "Драма", Rate=4 });
                db.Films.Add(new Film { Naming= "The Shawshank Redemption", Genre= "Драма", Rate=4 });
                db.Films.Add(new Film { Naming= "Star Wars", Genre= "Фентезі", Rate=1 });
                db.Films.Add(new Film { Naming= "Sonic", Genre= "Фентезі", Rate=2 });
                db.Films.Add(new Film { Naming= "Megaladon", Genre= "Екшин", Rate=3 });
                db.Films.Add(new Film { Naming= "Joe", Genre= "Комедія", Rate=5 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Film>> Get()
        {
            return db.Films.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Film> GetById(Int32 id)
        {
            Film film = db.Films.FirstOrDefault(x => x.Id == id);
            if (film == null)
                return NotFound();
            return new ObjectResult(film);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Film> AddFilm(Film film)
        {
            db.Films.Add(film);
            db.SaveChanges();
            return new ObjectResult(film);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<Film> DeleteFilm(Int32 id)
        {
            Film film = db.Films.Find(id);
            if (film == null)
                return NotFound();

            db.Films.Remove(film);
            db.SaveChanges();
            return new ObjectResult(film);
        }
    }
}
