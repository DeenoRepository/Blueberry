using Microsoft.EntityFrameworkCore;

namespace Blueberry.API.Data
{
    public class BlueberryAPIContext : DbContext
    {
        public BlueberryAPIContext(DbContextOptions<BlueberryAPIContext> options)
            : base(options) { }

        public DbSet<Blueberry.API.Models.StockItem> StockItem { get; set; } = default!;
    }
}
