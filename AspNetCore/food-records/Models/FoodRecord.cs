using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace food_records.Models
{
    public class FoodRecord
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public DateTime DateTime { get; set; }
    }
}