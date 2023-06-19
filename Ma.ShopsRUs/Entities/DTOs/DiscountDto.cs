using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ma.ShopsRUs.Entities.DTOs
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Rate { get; set; }
        public bool IsRatePercentage { get; set; }

    }
}
