using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenIce.Models
{
    public class Weather
    {
        public long Id { get; set; }
        public decimal Degress { get; set; }
        public DateTime TimeNow { get; set; }
    }
}
