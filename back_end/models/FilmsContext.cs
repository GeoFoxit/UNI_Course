using back_end.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end
{
    public class FilmsContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public FilmsContext(DbContextOptions<FilmsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
