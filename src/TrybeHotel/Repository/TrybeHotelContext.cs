using Microsoft.EntityFrameworkCore;
using TrybeHotel.Models;

namespace TrybeHotel.Repository;
public class TrybeHotelContext : DbContext, ITrybeHotelContext
{
    public TrybeHotelContext(DbContextOptions<TrybeHotelContext> options) : base(options)
    {
        Seeder.SeedUserAdmin(this);
    }
    public TrybeHotelContext() { }
    public DbSet<City> Cities { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Server=localhost;Database=TrybeHotel;User=SA;Password=TrybeHotel12!;TrustServerCertificate=True";

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }

}