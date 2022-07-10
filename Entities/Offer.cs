using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum DiscountType
    {
        Amount,
        Percentage
    }

    public class Offer : Entity
    {
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Discount { get; set; }
        public string Name { get; set; }
        public DiscountType Type { get; set; }
    }
}
