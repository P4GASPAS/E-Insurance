using Microsoft.EntityFrameworkCore;
using home_insurance.Models;

namespace home_insurance.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Agent)
                .WithMany(a => a.Clients)
                .HasForeignKey(u => u.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<House>()
                .HasOne(h => h.Owner)
                .WithMany()
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Insurance>()
                .HasOne(i => i.House)
                .WithMany()
                .HasForeignKey(i => i.HouseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Insurance>()
                .HasOne(i => i.Policy)
                .WithMany()
                .HasForeignKey(i => i.PolicyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Insurance)
                .WithMany()
                .HasForeignKey(p => p.InsuranceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Claim>()
                .HasOne(c => c.Insurance)
                .WithMany()
                .HasForeignKey(c => c.InsuranceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
