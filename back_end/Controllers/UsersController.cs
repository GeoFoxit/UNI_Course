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
    public class UsersController : ControllerBase
    {
        ApplicationContext db;
        public UsersController(ApplicationContext context)
        {
            db = context;
            if (!db.Users.Any())
            {
                db.Users.Add(new User { Login = "adminn", Password = "password" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return db.Users.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(Int32 id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        [HttpPost]
        public ActionResult<User> AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return new ObjectResult(user);
        }

        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(Int32 id)
        {
            User user = db.Users.Find(id);
            if (user == null)
                return NotFound();

            db.Users.Remove(user);
            db.SaveChanges();
            return new ObjectResult(user);
        }
    }
}
