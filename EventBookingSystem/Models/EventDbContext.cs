using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Models
{
    public class EventDbContext : DbContext
    {
        //constructor
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {

        }
        public EventDbContext()
        { }

        public DbSet<User> Users { get; set; }
       
        public DbSet<MarriageHall> MarriageHalls { get; set; }
        public DbSet<Services> Servicess { get; set; }
        public DbSet<MarriageHallServices> MarriageHallServices { get; set; }
        public DbSet<Order> Orders { get; set; }
        
    }
}
