using Microsoft.EntityFrameworkCore;
using GoldenIce.Models;

namespace GoldenIce.Models
{
    public class IceCreamOrderContext : DbContext
    {
        public IceCreamOrderContext(DbContextOptions<IceCreamOrderContext> options)
            : base(options)
        {
        }
        //
        public DbSet<IceCreamOrder> IceCreamOrders { get; set; }

    }
}