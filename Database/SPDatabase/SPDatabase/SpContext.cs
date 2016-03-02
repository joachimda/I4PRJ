using System.Data.Entity;

namespace SPDatabase
{
    public class SpContext : DbContext
    {
        public DbSet<UserEntity> UsersInDatabase { get; set; }
        //public DbSet<Pool> Pools { get; set; }
        public DbSet<RealName> RealNames { get; set; }
        //public DbSet<MonitorUnit> MonitorUnits { get; set; }
    }
}