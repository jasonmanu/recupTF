using System;

namespace Entities
{
    public class Order : Entity
    {
        public DateTime Date { get; set; }
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public float TotalPrice { get; set; }
    }
}
