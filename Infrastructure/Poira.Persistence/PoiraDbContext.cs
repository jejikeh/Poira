using Microsoft.EntityFrameworkCore;
using Poira.Domain.Models;
using Poira.Persistence.Configuration;

namespace Poira.Persistence;

public class PoiraDbContext : DbContext
{
    public DbSet<Fridge> Fridges { get; set; }
    public DbSet<FridgeModel> FridgeModels { get; set; }

    public PoiraDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FridgeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}