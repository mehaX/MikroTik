using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                Port = 9959
            });
        }

//        public MikroTikDbContext()
//        {
//            
//        }
//
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MikroTik;Integrated Security=True");
//        }

        public DbSet<Server> Servers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}
