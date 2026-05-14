using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Data;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
    public DbSet<StockMovement> StockMovements => Set<StockMovement>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(x => x.Id);
        modelBuilder.Entity<Product>().Property(x => x.Sku).IsRequired();
        modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired();

        modelBuilder.Entity<Warehouse>().HasKey(x => x.Id);
        modelBuilder.Entity<Warehouse>().Property(x => x.Code).IsRequired();
        modelBuilder.Entity<Warehouse>().Property(x => x.Name).IsRequired();

        modelBuilder.Entity<InventoryItem>().HasKey(x => x.Id);

        modelBuilder.Entity<StockMovement>().HasKey(x => x.Id);
        modelBuilder.Entity<StockMovement>().Property(x => x.Reason).IsRequired();
    }
}