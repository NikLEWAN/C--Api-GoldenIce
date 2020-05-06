using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace GoldenIce.Models
{
    public class TableReservationContext : DbContext
    {
        public TableReservationContext(DbContextOptions<TableReservationContext> options)
            : base(options)
        {
        }

        public DbSet<TableReservation> TableReservations { get; set; }
    }
}