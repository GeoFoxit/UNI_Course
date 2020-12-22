using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.models
{
    public interface IApplicationContext
    {
        DbSet<Film> Films { get; set; }
        DbSet<Session> Sessions { get; set; }
        DbSet<Seat> Seats { get; set; }
        DbSet<Booking> Bookings { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
