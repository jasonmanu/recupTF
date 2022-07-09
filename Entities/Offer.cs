using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum DiscountType
    {
        Percentage,
        Money
    }

    public class Offer : Entity
    {
        public int Discount { get; set; }
        public DiscountType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
