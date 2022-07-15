using System;

namespace Entities
{
    public class Order : Entity
    {
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public float TotalPrice { get; set; }
    }
}
