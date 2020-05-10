using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenIce.Models
{
    public class IceCream
    {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string imgUrl { get; set; }
            public decimal Price { get; set; }
            public string Size { get; set; }
    }
}
