using Microsoft.EntityFrameworkCore;
using Wild.Sloth.Domain.Orders;
using WILD.SLOTH.Domain.catalog;

namespace WILD.SLOTH.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
    { }

    public DbSet<Item> Items { get; set; }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        DbInitializer.Initialize(builder);
    }
    }
}


