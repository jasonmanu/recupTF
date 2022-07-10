using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SuggestedOffer : Entity
    {
        public string Reason { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Discount { get; set; }
        public string Name { get; set; }
        public DiscountTypeEnum Type { get; set; }
        //public int CategoryId { get; set; }
        //public int BrandId { get; set; }
        //public int ProductId { get; set; }
    }
}
