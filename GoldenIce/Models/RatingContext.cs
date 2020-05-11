using Microsoft.EntityFrameworkCore;
using GoldenIce.Models;

namespace GoldenIce.Models
{
    public class RatingContext : DbContext
    {
        public RatingContext(DbContextOptions<RatingContext> options)
            : base(options)
        {
        }

        public DbSet<Rating> Ratings { get; set; }

    }
}