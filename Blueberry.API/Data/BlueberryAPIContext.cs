using Microsoft.EntityFrameworkCore;

namespace Blueberry.API.Data
{
    public class BlueberryAPIContext : DbContext
    {
        public BlueberryAPIContext(DbContextOptions<BlueberryAPIContext> options)
            : base(options) { }
    }
}
