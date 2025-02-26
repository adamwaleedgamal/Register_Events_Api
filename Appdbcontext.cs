using login.Models;
using Microsoft.EntityFrameworkCore;

namespace login
{
    public class Appdbcontext : DbContext
    {
        public DbSet<User> Users { get; set; }  
        public DbSet<Event> Events { get; set; }
        public Appdbcontext(DbContextOptions options) : base(options)
        {
        }
    }
}
