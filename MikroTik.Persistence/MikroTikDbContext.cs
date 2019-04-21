using Microsoft.EntityFrameworkCore;
using MikroTik.Domain.Entities;

namespace MikroTik.Persistence
{
    public class MikroTikDbContext : DbContext
    {
        public MikroTikDbContext(DbContextOptions<MikroTikDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Server>().HasData(new Server
            {
                Id = 1,
                Hostname = "150.0.0.1",
                Username = "mehaX",
                Password = "mehaX4164",
                Port = 8728
            });
        }

        public DbSet<Server> Servers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}
