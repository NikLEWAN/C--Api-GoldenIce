using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenIce.Models
{
    public class TableReservation
    {
        public long Id { get; set; }
        public bool Available { get; set; }
        public DateTime Beginning { get; set; }
    }
}
