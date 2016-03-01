using System.Data.Entity;

namespace SPDatabase
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}