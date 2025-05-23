using FastFood.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Product> Products => Set<Product>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clientes");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name).IsRequired();
                entity.Property(u => u.CPF).IsRequired();
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.Phone).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("produtos");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Code).IsRequired();
                entity.HasIndex(p => p.Code) .IsUnique();
                entity.Property(p => p.Name).IsRequired();
                entity.Property(p => p.Description);
                entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(p => p.Category).IsRequired().HasConversion<int>();
            });
        }
    }
}
