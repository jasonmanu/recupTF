using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductOffer
    {
        public int ProductId { get; set; }
        public int OfferId { get; set; }
        public bool AppliesForAllProducts { get; set; }
    }
}
