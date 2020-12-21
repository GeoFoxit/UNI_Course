using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.models
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public ApplicationContext()
            : base()
        {
        }
    }
}
