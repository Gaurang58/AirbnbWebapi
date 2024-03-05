
using Airbnb.Models;
using Microsoft.EntityFrameworkCore;
 
namespace Airbnb.Models
{
    public class AirbnbContext: DbContext
    {
        public AirbnbContext(DbContextOptions<AirbnbContext> options) : base(options)
        {
        }
 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Tariff> Pricings { get; set; }
       
        public DbSet<RoomModel> RoomModels { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
 
            modelBuilder.Entity<Tariff>()
                .HasOne(p => p.RoomModel)
                .WithMany(v => v.Tariffs)
                .HasForeignKey(p => p.RoomModelId);
                modelBuilder.Entity<Tariff>()
                .HasKey(p => new {p.PriceId});
 
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.CustomerId)
                .IsUnique();
            modelBuilder.Entity<OrderConfirmation>()
            .HasKey(o => o.OrderId);
 
            modelBuilder.Entity<RoomModel>()
                .HasKey(op => new { op.RoomModelId });
 
            modelBuilder.Entity<OrderConfirmation>()
                .HasOne(op => op.Customer)
                .WithMany()
                .HasForeignKey(op => op.CustomerId);
 
            modelBuilder.Entity<OrderConfirmation>()
                .HasOne(op => op.RoomModel)
                .WithMany()
                .HasForeignKey(op => op.RoomModelId);
        }
        public DbSet<Airbnb.Models.OrderConfirmation> OrderConfirmation { get; set; } = default!;
    }
}