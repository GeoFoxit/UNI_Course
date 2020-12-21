using back_end.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace back_end.Tests.Services
{
    class MockSessions
    {
        public List<Session> Sessions;

        public MockSessions()
        {
            Sessions = new List<Session>();
            Sessions.Add(new Session { Id = 1, DateTime = DateTime.Now, FilmId = 1 });
            Sessions.Add(new Session { Id = 2, DateTime = DateTime.Now, FilmId = 2 });
            Sessions.Add(new Session { Id = 3, DateTime = DateTime.Now, FilmId = 2 });
        }
    }
}
