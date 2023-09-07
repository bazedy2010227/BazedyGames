using Bazedy_Games.Models;
using Microsoft.EntityFrameworkCore;

namespace Bazedy_Games.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; } 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Device> Devices { get; set; } 
        public DbSet<GameDevice> GameDevices { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameDevice>().HasKey(x => new { x.GameId, x.DeviceId });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category{Id=1,Name="Action"},
                new Category{Id=2,Name="Sports"},
                new Category{Id=3,Name="Racing"},
                new Category{Id=4,Name="Adventure"},
                new Category{Id=5,Name="Strategy"},
            });
            modelBuilder.Entity<Device>().HasData(new Device[]
            {
                new Device {Id=1,Name="PlayStation",Icon="bi bi-playstation"},
                new Device {Id=2,Name="Xbox",Icon="bi bi-xbox"},
                new Device {Id=3,Name="PC",Icon="bi bi-laptop"},
                new Device {Id=4,Name="Nintendo",Icon="bi bi-nintendo-switch"},
            });
        }
    }
}
