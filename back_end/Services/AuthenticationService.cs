using back_end.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Services
{
    public class AuthenticationService : IService<User>
    {
        IApplicationContext db;
        public AuthenticationService(IApplicationContext context)
        {
            this.db = context;
            if (!db.Users.Any())
            {
                db.Users.Add(new User { Login = "adminn", Password = "password" });
                db.SaveChanges();
            }
        }

        public User GetUser(string username, string password)
        {
            return db.Users.FirstOrDefault(x => x.Login == username && x.Password == password);
        }

        public User GetById(int id) 
        {
            User user = db.Users.Find(id);
            return user;
        }

        public User Add(User t)
        {
            throw new NotImplementedException();
        }

        public User Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }      

        public List<User> GetListById(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
