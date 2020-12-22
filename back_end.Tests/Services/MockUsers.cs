using back_end.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace back_end.Tests.Services
{
    class MockUsers
    {
        public List<User> Users;

        public MockUsers()
        {
            Users = new List<User>();
            Users.Add(new User { Id = 1, Login = "admin", Password = "password" });
        }
    }
}
