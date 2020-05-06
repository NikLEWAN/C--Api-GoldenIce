using Microsoft.EntityFrameworkCore;
using GoldenIce.Models;

namespace GoldenIce.Models
{
    public class IceCreamContext : DbContext
    {
        public IceCreamContext(DbContextOptions<IceCreamContext> options)
            : base(options)
        {
        }

        public DbSet<IceCream> IceCreams { get; set; }

        public DbSet<GoldenIce.Models.TableReservation> TableReservation { get; set; }
    }
}