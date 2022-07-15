using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductDto : Product
    {
        public string BrandName { get; set; }
        public float PriceDiscount { get; set; }
    }
}
