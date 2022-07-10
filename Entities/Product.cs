using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product : Entity
    {
        //public Product(string name, string description, float price)
        //{
        //    Name = name;
        //    Description = description;
        //    Price = price;
        //}
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public int MarcaId { get; set; }
    }
}
