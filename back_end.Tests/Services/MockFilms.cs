using back_end.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace back_end.Tests.Services
{
    class MockFilms
    {
        public List<Film> Films;

        public MockFilms()
        {
            Films = new List<Film>();
            Films.Add(new Film { Id = 1, Genre = "Action", Naming = "Star Wars", Rate = 4 });
            Films.Add(new Film { Id = 2, Genre = "Horror", Naming = "The Conjuring", Rate = 5 });
        }
    }
}
