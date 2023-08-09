using Entities.Enums;
using Newtonsoft.Json.Converters;
using System;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Offer : Entity
    {
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Discount { get; set; }
        public string Name { get; set; }
        public DiscountTypeEnum Type { get; set; }
        public string BrandId { get; set; }
        public string CategoryId { get; set; }
        public string ProductId { get; set; }
    }
}
